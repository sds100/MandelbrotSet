using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MandelbrotSet.ExportForm
{
    /// <summary>
    /// The Presenter for <see cref="ExportForm"/>
    /// </summary>
    public class Presenter : IPresenter
    {
        /// <param name="form">Implentation of <see cref="IForm"/></param>
        public Presenter(IForm form)
        {

        }

        public void Export()
        {
            throw new NotImplementedException();
        }

        public void ShowPreview(Bitmap bitmap)
        {
            throw new NotImplementedException();
        }

        public void UseCurrentOptions()
        {
            throw new NotImplementedException();
        }
    }
}
