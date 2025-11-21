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
    public class Song : MediaItem
    {
        
    }
    public class Podcast : MediaItem
    {
        
    }
    public class VideoGame : MediaItem
    {
        
    }
}