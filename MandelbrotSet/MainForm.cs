using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotSet
{
    /// <summary>
    /// The main Form. Uses MVP pattern.
    /// </summary>
    public partial class MainForm : Form, IForm
    {
        /// <summary>
        /// Amount to change the size of the <see cref="selectionRectangle"/> by in pixels.
        /// </summary>
        private const int RECT_SIZE_STEP_PX = 10;

        /// <summary>
        /// Inherited from <see cref="IForm"/>. When it is assigned, it sets the image of
        /// <see cref="pictureBox"/>.
        /// </summary>
        public Bitmap MandelbrotSet { set => pictureBox.Image = value; }

        /// <summary>
        /// Inherited from <see cref="IForm"/>. When assigned, sets the text of
        /// <see cref="labelTime"/>.
        /// </summary>
        long IForm.CalculationTime { set => labelTime.Text = $"{value} ms"; }

        /// <summary>
        /// Inherited from <see cref="IForm"/>. Output the width of the axis.
        /// </summary>
        double IForm.Width { set => labelWidth.Text = $"Width: {value}"; }

        /// <summary>
        /// Inherited from <see cref="IForm"/>. Output the height of the axis.
        /// </summary>
        double IForm.Height { set => labelHeight.Text = $"Height: {value}"; }

        /// <summary>
        /// Calculates the aspect-ratio of <see cref="pictureBox"/> 
        /// </summary>
        private double AspectRatio => (double)pictureBox.Width / pictureBox.Height;

        /// <summary>
        /// The rectangle which follows the cursor. It is used to select where the user wants to
        /// zoom into next.
        /// </summary>
        private Rectangle selectionRectangle;

        /// <summary>
        /// Stores the coordinates of the cursor
        /// </summary>
        private Point cursorLocation;

        /// <summary>
        /// Stores whether the form is currently being resized.
        /// </summary>
        private bool IsResizing = false;

        private IPresenter presenter;

        public MainForm()
        {
            InitializeComponent();

            presenter = new Presenter(this);

            selectionRectangle = new Rectangle(
                location: new Point(0, 0),
                size: new Size(pictureBox.Width / 10, pictureBox.Height / 10));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            presenter.DrawInitialMandelbrotSet(pictureBox.Size);
            labelVersion.Text = $"Version: {Properties.Resources.Version}";
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            IsResizing = true;
            SetRectangleSizeToAspectRatio();
        }

        /// <summary>
        /// Triggered when the form has stopped being resized by dragging the edges and corners
        /// with the mouse.
        /// </summary>
        private void MainForm_OnResizeEnd(object sender, EventArgs e)
        {
            IsResizing = false;
            presenter.Resize(pictureBox.Size);
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            cursorLocation = e.Location;
            MoveRectangleToCursor();
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ///if the mouse wheel is scrolled up, increase the size of
            ///<see cref="selectionRectangle"/>
            if (e.Delta > 0)
            {
                ChangeRectangleSize(RECT_SIZE_STEP_PX);
            }
            ///if the mouse wheel is scrolled down, decrease the size of
            ///<see cref="selectionRectangle"/>
            else
            {
                ChangeRectangleSize(-RECT_SIZE_STEP_PX);
            }

            //since the size of the rectangle has changed, it must be centred over the cursor
            MoveRectangleToCursor();
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    presenter.ZoomToSelectedArea(
                        pictureBox.Size,
                        selectionRectangle.Size,
                        cursorLocation);
                    break;

                case MouseButtons.Right:
                    presenter.ShowPreviousPlane(pictureBox.Size);
                    break;
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            //draw the rectangle onto the pictureBox
            e.Graphics.DrawRectangle(new Pen(Color.White), selectionRectangle);
        }

        /// <summary>
        /// when the cursor enters <see cref="pictureBox"/> change the cursor to a cross"/>
        /// </summary>
        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
        }

        /// <summary>
        /// when the cursor leaves <see cref="pictureBox"/> change the cursor to the default icon"/>
        /// </summary>
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Triggered when the size of <see cref="pictureBox"/> changes. It changes the size of
        /// the Mandelbrot Set.
        /// </summary>
        private void PictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (!IsResizing)
            {
                presenter.Resize(pictureBox.Size);
            }
        }

        /// <summary>
        /// Change dimensions of the rectangle to have the same aspect-ratio as the window
        /// </summary>
        private void SetRectangleSizeToAspectRatio()
        {
            selectionRectangle.Height = (int)Math.Round(selectionRectangle.Width / AspectRatio);
        }

        /// <summary>
        /// Change the size of the rectangle.
        /// </summary>
        /// <param name="sizeIncrease">How many pixels to change the rectangle size by</param>
        private void ChangeRectangleSize(int sizeIncrease)
        {
            selectionRectangle.Width += sizeIncrease;
            selectionRectangle.Height = (int)Math.Round(selectionRectangle.Width / AspectRatio);
        }

        /// <summary>
        /// Calculates new coordinates for the rectangle so it is centered around the cursor
        /// </summary>
        private void MoveRectangleToCursor()
        {
            int newX = cursorLocation.X - selectionRectangle.Width / 2;
            int newY = cursorLocation.Y - selectionRectangle.Height / 2;

            selectionRectangle.Location = new Point(newX, newY);

            //redraw the PictureBox so the rectangle is drawn in the new position
            pictureBox.Refresh();
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            new ExportForm().ShowDialog();
        }
    }
}
