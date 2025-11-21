namespace DomainLayer
{
    public interface ICompletable
    {
        public bool Completed { get; set; }
        public double CompletionProgress { get; set; }
        public void Complete(double newProgress);
    }
    public interface IDownloadable
    {
        public void Download();
    }
    public interface IExecutable
    {
        public void Execute();
    }
    public interface IPlayable
    {
        public void Play();
    }
    public interface IReadable
    {
        public void Read();
    }
    public interface IViewable
    {
        public void View();
    }
}