using System;
using System.Collections.Generic;

namespace Domain
{
    // Base abstract user class
    abstract class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string SSN { get; set; }

        public User(string name, int age, string ssn)
        {
            Name = name;
            Age = age;
            SSN = ssn;
        }

        public abstract string GetUserType();

        // Convert user to a string (similar to Item.Marshal)
        public virtual string Marshal()
        {
            return $"{GetUserType()} {Name} {Age} {SSN}";
        }
    }


    // -------------------------------
    // Borrower class
    // -------------------------------
    class Borrower : User
    {
        public Borrower(string name, int age, string ssn)
            : base(name, age, ssn) { }

        public override string GetUserType() => "Borrower";

        public void BorrowItem(MediaItem item)
        {
            Console.WriteLine($"{Name} borrowed {item.Title}");
        }

        public void RateItem(MediaItem item, int score)
        {
            Console.WriteLine($"{Name} rated {item.Title} with {score}/10");
        }
    }


    // -------------------------------
    // Employee class
    // -------------------------------
    class Employee : User
    {
        public Employee(string name, int age, string ssn)
            : base(name, age, ssn) { }

        public override string GetUserType() => "Employee";

        public void AddMedia(MediaItem item)
        {
            Console.WriteLine($"{Name} added media: {item.Title}");
        }

        public void RemoveMedia(MediaItem item)
        {
            Console.WriteLine($"{Name} removed media: {item.Title}");
        }
    }


    // -------------------------------
    // Admin class
    // -------------------------------
    class Admin : User
    {
        public Admin(string name, int age, string ssn)
            : base(name, age, ssn) { }

        public override string GetUserType() => "Admin";

        public void CreateUser(User user)
        {
            Console.WriteLine($"{Name} created user: {user.Name}");
        }

        public void DeleteUser(User user)
        {
            Console.WriteLine($"{Name} deleted user: {user.Name}");
        }
    }



    // ------------------------------------------------------
    // Dummy MediaItem class so the Borrower/Employee compile
    // (Replace this with the real MediaItem class)
    // ------------------------------------------------------
    class MediaItem
    {
        public string Title { get; set; }

        public MediaItem(string title)
        {
            Title = title;
        }
    }
}
