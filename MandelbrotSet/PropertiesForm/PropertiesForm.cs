using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace MandelbrotSet.PropertiesForm
{
    public partial class PropertiesForm : Form, IForm, IProgressBar, IExportImage
    {
        public Size BitmapSize => new Size((int)numUpDownWidth.Value, (int)numUpDownHeight.Value);

        public double Magnification
        {
            get => (double)numUpDownMagnification.Value;
            set => numUpDownMagnification.Value = (decimal)value;
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

        public string Folder
        {
            get => labelFolder.Text;
            set => labelFolder.Text = value;
        }

        public IProgressBar ProgressBar => this;

        public IExportImage iExportImage => this;

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

            if (String.IsNullOrWhiteSpace(Folder))
            {
                MessageBox.Show("Must choose a directory!");
                return false;
            }

            if (String.IsNullOrWhiteSpace(FileName))
            {
                MessageBox.Show("Must create a file name!");
                return false;
            }

            if (!Directory.Exists(Folder))
            {
                MessageBox.Show("Folder doesn't exist!");
                return false;
            }

            return true;
        }

        private void PropertiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            presenter.ShowPreview();
        }

        private void ButtonChooseFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    Folder = dialog.SelectedPath;
                }
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            presenter.Export();
        }

        private void ButtonDebug_Click(object sender, EventArgs e)
        {
            Folder = "A:\\Seth\\Pictures\\MandelbrotSets";
            textBoxFileName.Text = "test";
        }

        public void OnProgress(int percent)
        {
            //to prevent the progressBar from being accessed on a different thread
            //it was created on
            this.Invoke(new MethodInvoker(delegate
            {
                labelProgress.Text = $"Drawn {percent}%";
                progressBar.Value = percent;
            }));
        }

        public void OnExportFinished(string path)
        {
            //to prevent the progressBar from being accessed on a different thread
            //it was created on
            this.Invoke(new MethodInvoker(delegate
            {
                progressBar.Value = 0;
                labelProgress.Text = "";

                MessageBox.Show(
                this,
                text: path,
                caption: "Export Finished"
                );
            }));
        }

        public void OnSaveStart()
        {
            Console.WriteLine("onsavestart");
            this.Invoke(new MethodInvoker(delegate
            {
                labelProgress.Text = "Saving to disk... This will take a long time depending on the resolution of the image";
            }));
        }
    }
}