using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    public interface IProgressBar
    {
        /// <summary>
        /// When the image has started being saved to disk.
        /// </summary>
        void OnSaveStart();

        void OnProgress(int percent);
    }
}
