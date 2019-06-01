using System;


class Book : IComparable<Book>
{
    //private book attributes
    public string title;
    public string author;
    public string description;
    public string genre;
    public int year;
    public float rating;

    //declaring constructor
    public Book(string title, string author, 
                string description, string genre,
                int year, float rating)
    {
        this.title = title;
        this.author = author;
        this.description = description;
        this.genre = genre;
        this.year = year;
        this.rating = rating;
    }

    //sorting books first by title
    public int CompareTo(Book b1)
    {
        {
            return this.title.CompareTo(b1.title);
        }

    }

        //Getters and setters declarations
        public string GetTitle() { return title; }

        public void SetTitle(string title) { this.title = title; }

        public string GetAuthor() { return author; }

        public void SetAuthor(string author) { this.author = author; }

        public string GetDescription() { return description; }

        public void SetDescription(string description) { this.description = description; }

        public string GetGenre() { return genre; }

        public void SetGenre(string genre) { this.genre = genre; }

        public int GetYear() { return year; }

        public void SetYear(int year) { this.year = year; }

        public float GetRating() { return rating; }

        public void SetRating(float rating) { this.rating = rating; }

    //will print out our books in the specified order
    public override string ToString()
    {
        return "Title: " + title + " - Author: " + author + " - Description: " + description + 
                " - Genre: " + genre + " - Year: " + year + " - Rating: " + rating;
    }
}

