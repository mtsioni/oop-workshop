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
            +loadUsers()
            +saveUsers()
        }
    }

    namespace DomainLayer {
        %% ------------------------------------------------
        %% INTERFACES (Capabilities)
        %% ------------------------------------------------
        class IDownloadable {
            <<interface>>
            +download()
        }
        class IPlayable {
            <<interface>>
            +play()
        }
        class IReadable {
            <<interface>>
            +read()
        }
        class IWatchable {
            <<interface>>
            +watch()
        }
        class IExecutable {
            <<interface>>
            +execute()
        }

        %% ------------------------------------------------
        %% MEDIA HIERARCHY
        %% ------------------------------------------------
        class MediaItem {
            <<abstract>>
            +String title
            +double averageRating
            +borrow()
            +rate(int score)
            +getDetails() String
        }

        class EBook {
            +String author
            +String isbn
            +int pages
        }

        class Movie {
            +String director
            +int durationMinutes
        }

        class Song {
            +String artist
            +String fileType
        }

        class VideoGame {
            +String platform
            +boolean isCompleted
            +complete()
        }
        
        class App {
            +String version
            +String os
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

    User <|-- Borrower
    User <|-- Employee
    Employee <|-- Admin : Admin is an Employee

    %% Realization (Implements Interface)
    IDownloadable <|.. EBook
    IDownloadable <|.. Movie
    IDownloadable <|.. Song
    IDownloadable <|.. VideoGame
    
    IReadable <|.. EBook
    IWatchable <|.. Movie
    IPlayable <|.. Song
    IPlayable <|.. VideoGame
    IExecutable <|.. App

    %% Composition / Association
    LibrarySystem o-- MediaItem : manages
    LibrarySystem o-- User : manages
    ConsoleUI --> LibrarySystem : uses
    LibrarySystem --> FileHandler : uses
    ```