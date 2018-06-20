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
