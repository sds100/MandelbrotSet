namespace MandelbrotSet
{
    public interface IExportImage
    {
        IProgressBar ProgressBar { get; }

        /// <summary>
        /// When the image has started being saved to disk.
        /// </summary>
        void OnSaveStart();
        void OnExportFinished(string path);
    }
}
