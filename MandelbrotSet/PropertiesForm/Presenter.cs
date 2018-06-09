using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotSet.PropertiesForm
{
    /// <summary>
    /// The Presenter for <see cref="PropertiesForm"/>
    /// </summary>
    public class Presenter : IPresenter
    {
        private readonly IForm form;
        private readonly MainForm.IPresenter mainFormPresenter;

        /// <param name="form">Implentation of <see cref="IForm"/></param>
        public Presenter(IForm form, MainForm.IPresenter mainFormPresenter)
        {
            this.form = form;
            this.mainFormPresenter = mainFormPresenter;

            ShowPreview();
        }

        public void Export()
        {
            if (form.AreOptionsValid())
            {
            }
        }

        public void ShowPreview()
        {
            try
            {
                var axisLengths = CalculateAxisLengths(form.Magnification);
                var imageInfo = new ImageInfo(axisLengths, form.FocusPoint);

                mainFormPresenter.DrawImageAsync(mainFormPresenter.CurrentBitmapSize, imageInfo, true);
            }
            catch (Exception) { }
        }

        private AxisLengths CalculateAxisLengths(double magnification)
        {
            double width = ImageInfo.DEFAULT_AXIS_LENGTHS.X / magnification;
            double height = ImageInfo.DEFAULT_AXIS_LENGTHS.Y / magnification;

            return new AxisLengths(width, height);
        }
    }
}
