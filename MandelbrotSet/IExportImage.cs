using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    public interface IExportImage
    {
        IProgressBar ProgressBar { get; }
        void OnExportFinished(string path);
    }
}
