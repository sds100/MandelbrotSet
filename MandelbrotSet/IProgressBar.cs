namespace MandelbrotSet
{
    public interface IProgressBar
    {
        void OnProgress(int percent);
        void OnProgressFinish();
    }
}
