using System;
using System.Drawing;
using System.Windows.Forms;

namespace MandelbrotSet.PropertiesForm
{
    public partial class PropertiesForm : Form, IForm
    {
        public Size BitmapSize => new Size((int)numUpDownWidth.Value, (int)numUpDownHeight.Value);

        public double Magnification
        {
            get => (double)numUpDownMagnification.Value;
            set => numUpDownMagnification.Value = (decimal) value;
        }

        public PointD FocusPoint
        {
            get => new PointD(
                Double.Parse(textBoxPointX.Text),
                Double.Parse(textBoxPointY.Text)
                );
            set
            {
                textBoxPointX.Text = value.X.ToString();
                textBoxPointY.Text = value.Y.ToString();
            }
        }

        public string FileName => textBoxFileName.Text;

        public string Directory => labelDirectory.Text;

        private readonly IPresenter presenter;

        public PropertiesForm(MainForm.IPresenter mainFormPresenter)
        {
            InitializeComponent();

            presenter = new Presenter(this, mainFormPresenter);
        }

        /// <summary>
        /// Determines whether the current options chosen are valid.
        /// </summary>
        public bool AreOptionsValid()
        {
            try
            {
                Double.Parse(textBoxPointX.Text);
                Double.Parse(textBoxPointY.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid focus point!");
                return false;
            }

            if (labelDirectory.Text.Length == 0)
            {
                MessageBox.Show("Must choose a directory!");
                return false;
            }

            return true;
        }

        private void PropertiesForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                presenter.ShowPreview();
            }
        }

        private void PropertiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
