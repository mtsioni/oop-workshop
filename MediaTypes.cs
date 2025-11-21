namespace DomainLayer
{
    public abstract class MediaItem
    {
        public string Title { get; set; }
        public bool Borrowed { get; set;}
        public int Ratings { get; private set; }
        public double AverageRating { get; private set; }
        public string Details { get; set; }
        public MediaItem(string title, string details)
        {
            Title = title;
            Details = details;
            AverageRating = 0;
            Ratings = 0;
        }
        public void Borrow()
        {
            if (!Borrowed)
                Borrowed = true;
        }
        public void Rate(int score)
        {
            AverageRating = (AverageRating + score)/2;
            Ratings++;
        }
    }
    public class App : MediaItem, IDownloadable, IExecutable
    {
        public string Publisher { get; set;}
        public string Platform { get; set; }
        public string Version { get; set;}
        public int FilesizeMB { get; set; }
        public App(string title, string details, string platform, string version, string filesizeMB) : base(title, details)
        {
            Platform = platform;
            Version = version;
            FilesizeMB = filesizeMB;
        }
        public void Download()
        {
            Console.Write("Dowloading not implemented");
        }
        public void Execute()
        {
            Console.Write("Execution not implemented");
        }
    }
    public class Ebook : MediaItem, IDownloadable, IReadable, IViewable
    {
        public string Author { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public int YearOfPublication { get; set; }
        public Ebook(string title, string details, string author, string language, string isbn, int pages, int yearOfPublication) : base(title, details)
        {
            Author = author;
            Language = language;
            ISBN = isbn;
            Pages = pages;
            YearOfPublication = yearOfPublication;
        }
        public void Download()
        {
            Console.Write("Dowloading not implemented");
        }
        public void Read()
        {
            Console.Write("Reading not implemented");
        }
        public void View()
        {
            Console.Write("Viewing not implemented");
        }
    }
    public class Image : MediaItem, IDownloadable, IViewable
    {
        public string Resolution { get; set; }
        public string FileFormat { get; set; }
        public int FilesizeMB { get; set; }
        public DateTime DateTaken { get; set; }
        public Image(string title, string details, string resolution, string fileFormat, int fileSizeMB, DateTime dateTaken) : base(title, details)
        {
            Resolution = resolution;
            FileFormat = fileFormat;
            FilesizeMB = fileSizeMB;
            DateTaken = dateTaken;
        }
        public void Download()
        {
            Console.Write("Dowloading not implemented");
        }
        public void View()
        {
            Console.Write("Viewing not implemented");
        }
    }
    public class Movie : MediaItem, IDownloadable, IPlayable
    {
        public string Director { get; set; }
        public string Genre { get; set; }
        public string FileType { get; set; }
        public string Language { get; set; }
        public int DurationMinutes { get; set; }
        public Movie (string title, string details, string director, string genre, string filetype, string language, int durationMinutes) : base(title, details)
        {
            Director = director;
            Genre = genre;
            FileType = filetype;
            Language = language;
            DurationMinutes = durationMinutes;
        }
        public void Download()
        {
            Console.Write("Dowloading not implemented");
        }
        public void Play()
        {
            Console.Write("Playing not implemented");
        }
    }
    public class Song : MediaItem, IDownloadable, IPlayable
    {
        public string Composer { get; set; }
        public string Singer { get; set; }
        public string Genre { get; set; }
        public string FileType { get; set; }
        public string Language { get; set; }
        public int DurationSeconds { get; set; }
        public Song(string title, string details, string composer, string singer, string genre, string fileType, string language, int durationSeconds) : base(title, details)
        {
            Composer = composer;
            Singer = singer;
            Genre = genre;
            FileType = fileType;
            Language = language;
            DurationSeconds = durationSeconds;
        }
        public void Download()
        {
            Console.Write("Dowloading not implemented");
        }
        public void Play()
        {
            Console.Write("Playing not implemented");
        }
    }
    public class Podcast : MediaItem, IDownloadable, ICompletable, IPlayable
    {
        public int ReleaseYear { get; set; }
        public string[] Hosts {get; set; }
        public string[] Guests {get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Language { get; set; }
        public double CompletionProgress { get; set; }
        public bool Completed { get; set; }
        public Podcast(string title, string details, int releaseYear, string[] hosts, string[] guests, int numberOfEpisodes, string language) : base(title, details)
        {
            ReleaseYear = releaseYear;
            Hosts = hosts;
            Guests = guests;
            NumberOfEpisodes = numberOfEpisodes;
            Language = language;
            CompletionProgress = 0;
            Completed = false;
        }
        public void Download()
        {
            Console.Write("Dowloading not implemented");
        }
        public void Complete(double newProgress)
        {
            CompletionProgress += newProgress;
            if (CompletionProgress >= 1)
                Completed = true;
        }
        public void Play()
        {
            Console.Write("Playing not implemented");
        }
    }
    public class VideoGame : MediaItem, IDownloadable, ICompletable, IPlayable
    {
        public string Publisher { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
        public int YearOfRelease { get; set; }
        public double CompletionProgress { get; set; }
        public bool Completed { get; set; }
        public VideoGame(string title, string details, string publisher, string platform, string genre, int yearOfRelease) : base (title, details)
        {
            Publisher = publisher;
            Platform = platform;
            Genre = genre;
            YearOfRelease = yearOfRelease;
            CompletionProgress = 0;
            Completed = false;
        }
        public void Download()
        {
            Console.Write("Dowloading not implemented");
        }
        public void Complete(double newProgress)
        {
            CompletionProgress += newProgress;
            if (CompletionProgress >= 1)
                Completed = true;
        }
        public void Play()
        {
            Console.Write("Playing not implemented");
        }
    }
}