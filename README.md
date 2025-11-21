# oop-workshop
OOP Workshop - 1st semester BSc Software Engineering - Digital Library

Group: "Compile Commandos"
Names: Maria Tsioni | Bianka Ptak | Pavel Seliavko

```mermaid
classDiagram
    namespace PresentationLayer {
        class ConsoleUI {
            +start()
            +displayMenu()
            +getUserInput()
        }
    }

    namespace DataAccessLayer {
        class FileHandler {
            +loadMedia()
            +saveMedia()
            +deleteMedia()
            +loadUsers()
            +saveUsers()
            +deleteUsers()
        }
    }

    namespace DomainLayer {
        %% ------------------------------------------------
        %% INTERFACES (Capabilities)
        %% ------------------------------------------------
        class IDownloadable {
            <<interface>>
            +Download()
        }
        class IPlayable {
            <<interface>>
            +Play()
        }
        class IReadable {
            <<interface>>
            +Read()
        }
        class IExecutable {
            <<interface>>
            +Execute()
        }
        class IViewable {
            <<interface>>
            +View()
        }
        class ICompletable{
            <<interface>>
            +bool Completed
            +double CompletionProgress
            +Complete (double newProgress)
        }

        %% ------------------------------------------------
        %% MEDIA HIERARCHY
        %% ------------------------------------------------
        class MediaItem {
            <<abstract>>
            +string Title
            +bool Borrowed
            +int Ratings
            +string Details
            +double AverageRating
            +Borrow()
            +Rate(int score)
        }

        class EBook {
            +string Author
            +string Language
            +string ISBN
            +int Pages
            +int YearOfPublication
        }

        class Movie {
            +string Director
            +string Genre
            +string FileType
            +string Language
            +int DurationMinutes
        }

        class Song {
            +string Composer
            +string Singer
            +string Genre
            +string FileType
            +string Language
            +int DurationSeconds
        }

        class VideoGame {
            +string Publisher
            +string Platform
            +string Genre
            +int YearOfRelease
            +boolean IsCompleted
        }
        
        class App {
            +string Publisher
            +string Version
            +string Platfrorm
            +int FilesizeMB
        }
        class Image {
            +string Resolution
            +string FileFormat
            +int FilesizeMB
            +DateTime DateTaken
        }
        class Podcast {
            +int ReleaseYear
            +string[] Hosts
            +string[] Guests
            +int EpisodeNumber
            +string Language
        }

        %% ------------------------------------------------
        %% USER HIERARCHY
        %% ------------------------------------------------
        class User {
            <<abstract>>
            +String name
            +int age
            +String ssn
        }

        class Borrower {
            +borrowItem(MediaItem item)
            +rateItem(MediaItem item, int score)
        }

        class Employee {
            +addMedia(MediaItem item)
            +removeMedia(MediaItem item)
        }

        class Admin {
            +createUser(User user)
            +deleteUser(User user)
        }

        %% ------------------------------------------------
        %% CONTROLLER / MANAGER
        %% ------------------------------------------------
        class LibrarySystem {
            -List~MediaItem~ inventory
            -List~User~ users
            +User currentUser
            +login(String role)
            +searchMedia(String query)
        }
    }

    %% ---------------------------------------------------------
    %% RELATIONSHIPS
    %% ---------------------------------------------------------

    %% Inheritance (Is-A)
    MediaItem <|-- EBook
    MediaItem <|-- Movie
    MediaItem <|-- Song
    MediaItem <|-- VideoGame
    MediaItem <|-- App
    MediaItem <|-- Image
    MediaItem <|-- Podcast

    User <|-- Borrower
    User <|-- Employee
    Employee <|-- Admin : Admin is an Employee

    %% Realization (Implements Interface)
    IDownloadable <|.. EBook
    IDownloadable <|.. Movie
    IDownloadable <|.. Song
    IDownloadable <|.. VideoGame
    IDownloadable <|.. App
    IDownloadable <|.. Podcast
    IDownloadable <|.. Image
    
    IReadable <|.. EBook
    IPlayable <|.. Movie
    IPlayable <|.. Song
    IPlayable <|.. VideoGame
    IPlayable <|.. Podcast
    IExecutable <|.. App
    IViewable <|.. EBook
    IViewable <|.. Image
    ICompletable <|.. Podcast
    ICompletable <|.. VideoGame

    %% Composition / Association
    LibrarySystem o-- MediaItem : manages
    LibrarySystem o-- User : manages
    ConsoleUI --> LibrarySystem : uses
    LibrarySystem --> FileHandler : uses
    ```