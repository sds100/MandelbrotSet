namespace MandelbrotSet
{
    public interface IExportImage
    {
        IProgressBar ProgressBar { get; }
        void OnExportFinished(string path);
    }
}
