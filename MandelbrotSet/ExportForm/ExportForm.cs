using System;
using System.Drawing;
using System.Windows.Forms;

namespace MandelbrotSet.ExportForm
{
    public partial class ExportForm : Form, IForm
    {
        public ExportForm()
        {
            InitializeComponent();
        }

        public Size BitmapSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long Magnification { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PointD FocusPoint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string FileName => throw new NotImplementedException();

        public string Directory => throw new NotImplementedException();

        public Bitmap Preview { set => throw new NotImplementedException(); }

        private void MandelbrotSetParams_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
