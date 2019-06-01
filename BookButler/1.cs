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

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class BookButler
{
    struct BookLocation
    {
        public string codeLocation;
        public string houseLocation;
        public string shelfLocation;

    }

    static void Main(string[] args)
    {
        //variable declaration
        List<BookLocation> location = new List<BookLocation>();
        List<Book> books = new List<Book>();
        ArrayList historyBooks = new ArrayList();
        Dictionary<string, string> help = new Dictionary<string, string>();
        string option;


        try
        {
            do
            {
                Console.WriteLine("Book options: ");
                string[] menu = { "1.Add a book.", "2.Search a book.", "3.See all books.", "4.Edit a book.",
                                "5.Delete a book.", "6.Help.", "7.Book location", "E. Exit." };
                Console.WriteLine();
                foreach (string menuitem in menu)
                {
                    Console.WriteLine(menuitem);
                }
                Console.WriteLine();
                option = Console.ReadLine().ToUpper();

                switch (option)
                {
                    //exit case
                    case "E":
                        farewell();
                        break;

                    //Adding a book
                    case "1":
                        addingABook(books, historyBooks);
                        Console.WriteLine();
                        break;

                    //search a book either by title or author
                    case "2":
                        searchABook(books);
                        Console.WriteLine();
                        break;

                    //see all books
                    case "3":
                        seeAllBooks(books);
                        Console.WriteLine();
                        break;

                    //edit a book
                    case "4":
                        editABook(books);
                        Console.WriteLine();
                        break;

                    //delete a book
                    case "5":
                        deleteABook(books);
                        Console.WriteLine();
                        break;

                        //help section
                    case "6":
                        offeringHelp(help);
                        Console.WriteLine();
                        break;

                    //help section
                    case "7":
                        locatingABook(ref location);
                        Console.WriteLine();
                        break;

                    //wrong selection falls here
                    default:
                        wrongOption();
                        Console.WriteLine();
                        break;
                }

            } while (option != "E");
        }

        //exceptions block

        catch (IOException exc)
        {
            Console.WriteLine("I/O error: " + exc.Message );
            Console.WriteLine();
        }
        
        catch (Exception ex)
        {
            Console.WriteLine("Error message: " + ex.Message);
            Console.WriteLine();
        }
    }

    //add a book (option 1)
    public static void addingABook(List<Book> books, ArrayList historyBooks)
    {
        string title, author, description, genre, format="";
        int year;
        float rating;
        bool isElectronic = false;


        //file variables
        StreamWriter output;
        string fileName = "BooksDB.txt";

        //opening and appending to a file
        output = File.AppendText(fileName);

        //declaring current time
        int currentYear;
        currentYear = DateTime.Now.Year;

        //declaring year 1 of our era
        int year1 = new DateTime(0001, 01, 01).Year;

        do
        {
            Console.WriteLine("Title: ");
            title = Console.ReadLine();
            if (title == "")
            {
                Console.WriteLine("Do not leave title field empty");
            }
        } while (title == "");
        do
        {
            Console.WriteLine("Author: ");
            author = Console.ReadLine();
            if (author == "")
            {
                Console.WriteLine("Do not leave author field empty");
            }
        } while (author == "");
        do
        {
            Console.WriteLine("Description: ");
            description = Console.ReadLine();
            if (description == "")
            {
                Console.WriteLine("Do not leave description field empty");
            }

        } while (description == "");
        do
        {
            Console.WriteLine("Genre: ");
            genre = Console.ReadLine();
            if (genre == "")
            {
                Console.WriteLine("Do not leave genre field empty");
            }

        } while (genre == "");
        do
        {
            Console.WriteLine("Year: ");
            year = Convert.ToInt32(Console.ReadLine());
            if (year1 > year || year > currentYear)
            {
                Console.WriteLine("Publishing year must be between 1 and today");
            }
        } while (year1 > year || year > currentYear);

        do
        {
            Console.WriteLine("Rating: ");
            rating = Convert.ToSingle(Console.ReadLine());
            if (0.0 > rating || rating > 5.0)
            {
                Console.WriteLine("Ratings must be between 0 and 5 ");
            }
        } while (0.0 > rating || rating > 5.0);

        string isElec;

        do
        {

            Console.WriteLine("Is it electronic:?(y/n) ");
            isElec = Console.ReadLine().ToLower();

            if (isElec == "y")
            {
                isElectronic = true;
                format = "Electronic format book";
                Console.WriteLine(format);
            }
            else if (isElec == "n")
            {
                isElectronic = false;
                format = "Paper format book";
                Console.WriteLine(format);
            }
            else
            {
                Console.WriteLine("Please make sure to enter either 'y' or 'n' ");
            }

        } while (isElec != "y" && isElec != "n");

        Console.WriteLine("Is it a history or non history book(h/n)? ");
        char hisBook = Convert.ToChar(Console.ReadLine());
        
        if (hisBook == 'h')
        {
            Console.WriteLine("A history book it is.");
            historyBooks.Add(new HistoryBook(title, author, description, genre, year, rating, isElectronic));
            Console.WriteLine("History book added successfully.");
            Console.WriteLine("Number of history books stored: {0}", historyBooks.Count);
        }
        else if (hisBook == 'n')
        {
            Console.WriteLine("A non-history book it is");
            books.Add(new Book(title, author, description, genre, year, rating));
            Console.WriteLine("Book added successfuly");
            Console.WriteLine("Number of non-history books stored(by title-alphabetical order): {0}", books.Count);

        }
        else
        {
            Console.WriteLine("Please make sure to enter either \"h\" or \"n\"");
            Console.WriteLine("Is it a history or non history book(h/n)? ");
            hisBook = Convert.ToChar(Console.ReadLine());
        }
        
        Console.WriteLine();

        books.Sort();

        foreach (Book book in books)
        {
            Console.WriteLine("Book: " + book);
            output.WriteLine(DateTime.Now + " Non history book:" + book + " - " + format);
        }

        foreach (HistoryBook hb in historyBooks)
        {
            Console.WriteLine("History book: " + hb);
            output.WriteLine(DateTime.Now +  " History book: " + hb);
        }
        //closing writing file
        output.Close();
    }

    //search a book function(option 2 in main)
    public static void searchABook(List<Book> books)
    {
        string fileName = "BooksDB.txt";
        StreamReader reader = new StreamReader(fileName);
        string line;
        int countLines = 0;

        if (!File.Exists(fileName))
        {
            Console.WriteLine("Database does not exists!");
        }
        else
        {
            try
            {
                Console.WriteLine("What is the keyword to search: ");
                string search = Console.ReadLine().ToUpper();

                bool found = false;

                do
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        found = line.ToUpper().Contains(search);
                        countLines++;
                    }

                } while (line != null && !line.ToUpper().Contains(search));

                if (found)
                {
                    Console.WriteLine("Match found: " + line);
                    Console.WriteLine("Number of books found: " + countLines);
                }

                if (!found)
                {
                    Console.WriteLine("No matches found");
                }

                reader.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error in file: " + ex);
            }
            catch (Exception e)
            {
                Console.WriteLine("General error: " + e);
            }
        }
    }

    //see all books(option 3)

    public static void seeAllBooks(List<Book> books)
    {
        string fileName = "BooksDB.txt";
        StreamReader reader = new StreamReader(fileName);
        string line;
        int countLines = 0;

        Console.WriteLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("Database does not exists!");
        }
        else
        {
            try
            {
                do
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        countLines++;
                        Console.WriteLine(line);
                    }
                } while (line != null);

                Console.WriteLine("Number of books stored: " + countLines);

                reader.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error in file: " + ex);
            }
            catch (Exception e)
            {

                Console.WriteLine("General error: " + e);
            }

        }

        Console.WriteLine();
    }

    //edit a book function(option 4 in main)
    public static void editABook(List<Book> books)
    {
        Console.WriteLine("What book number would you like to edit(available for console session only): ");

        int bookPosition = Convert.ToInt32(Console.ReadLine()) - 1;
        if (bookPosition < 0 || bookPosition > books.Count - 1)
        {
            Console.WriteLine("Wrong position, try again");
        }

        Book bookEdited = books[bookPosition];

        Console.WriteLine("New title (it was {0}): ", bookEdited.title);
        string newBook = Console.ReadLine();

        if (newBook != "")
        {
            bookEdited.title = newBook;
        }

        else
        {
            Console.WriteLine("Book title has not been modififed");
        }

        Console.WriteLine("New author (it was {0}): ", bookEdited.author);
        newBook = Console.ReadLine();

        if (newBook != "")
        {
            bookEdited.author = newBook;
        }

        else
        {
            Console.WriteLine("Book author has not been modififed");
        }

        Console.WriteLine("New description (it was {0}): ", bookEdited.description);
        newBook = Console.ReadLine();

        if (newBook != "")
        {
            bookEdited.description = newBook;
        }

        else
        {
            Console.WriteLine("Book description has not been modififed");
        }

        Console.WriteLine("New genre (it was {0}): ", bookEdited.genre);
        newBook = Console.ReadLine();

        if (newBook != "")
        {
            bookEdited.genre = newBook;
        }

        else
        {
            Console.WriteLine("Book genre has not been modififed");
        }

        Console.WriteLine("New year (it was {0}): ", bookEdited.year);
        newBook = Console.ReadLine();

        if (newBook != "")
        {
            bookEdited.year = Convert.ToInt32(newBook);
        }

        else
        {
            Console.WriteLine("Book year has not been modififed");
        }

        Console.WriteLine("New rating (it was {0}): ", bookEdited.rating);
        newBook = Console.ReadLine();

        if (newBook != "")
        {
            bookEdited.rating = Convert.ToSingle(newBook);
        }

        else
        {
            Console.WriteLine("Book rating has not been modififed");
        }
    }

    //delete a book(option 5)
    public static void deleteABook(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("DataBase is empty");
        }

        Console.WriteLine("Enter index to delete(available for console session only): ");
        int posDelete = Convert.ToInt32(Console.ReadLine()) - 1;
        if (posDelete < 0 || posDelete > books.Count)
        {
            Console.WriteLine("Wrong number");
        }
        else
        {
            books.RemoveAt(posDelete);
            Console.WriteLine("Book {0} successfully deleted", posDelete+1);
        }
        
    }

    //user help/guide function(option 6 in main)
    public static void offeringHelp(Dictionary<string, string> dict)
    {
        Dictionary<string, string> help = new Dictionary<string, string>();
        string helpOptions;
        string nameOfFile = "guide.txt";

        if (!File.Exists(nameOfFile))
        {
            Console.WriteLine("File not found");
        }
        else
        {
            do
            {
                StreamWriter helpFileWriter;
                helpFileWriter = File.AppendText(nameOfFile);

                Console.WriteLine("What would you like help about: ");
                Console.WriteLine("1.How to add a book: ");
                Console.WriteLine("2.How to search a book: ");
                Console.WriteLine("3.See all books: ");
                Console.WriteLine("4.How to edit a book: ");
                Console.WriteLine("5.How to delete book: ");
                Console.WriteLine("Q.Quit");
                Console.WriteLine();
                helpOptions = Console.ReadLine().ToUpper();
                Console.WriteLine();

                switch (helpOptions)
                {
                    case "Q":
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You are going back to main menu");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                    case "1":
                        help.Add("Adding", "Comment: Feature to add books one by one to DB. All fields must be filled in.");
                        if (help.ContainsKey("Adding"))
                        {
                            Console.WriteLine(help["Adding"]);
                            helpFileWriter.WriteLine("Adding: " + help["Adding"]);
                        }

                        Console.WriteLine();
                        break;

                    case "2":
                        help.Add("Search", "Comment: Search a book either by title or author.");
                        if (help.ContainsKey("Search"))
                        {
                            Console.WriteLine(help["Search"]);
                            helpFileWriter.WriteLine("Search: " + help["Search"]);
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        help.Add("See", "Comment: See all books in DB so far.");
                        if (help.ContainsKey("See"))
                        {
                            Console.WriteLine(help["See"]);
                            helpFileWriter.WriteLine("See: " + help["See"]);
                        }

                        Console.WriteLine();
                        break;

                    case "4":
                        help.Add("Edit", "Comment: Edit a particular book of your chosing.");
                        if (help.ContainsKey("Edit"))
                        {
                            Console.WriteLine(help["Edit"]);
                            helpFileWriter.WriteLine("Edit: " + help["Edit"]);
                        }

                        Console.WriteLine();
                        break;

                    case "5":
                        help.Add("Delete", "Comment: Delete a particular book that you wish.");
                        if (help.ContainsKey("Delete"))
                        {
                            Console.WriteLine(help["Delete"]);
                            helpFileWriter.WriteLine("Delete: " + help["Delete"]);
                        }

                        Console.WriteLine();
                        break;

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Wrong option");
                        Console.WriteLine("Choose a number between 1 to 5.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                        break;
                }

                //closing files
                helpFileWriter.Close();
                
            } while (helpOptions != "Q");
        }
       
    }

    //locating a book , option 7
     static void locatingABook(ref List<BookLocation> location)
    {
        string fileLocation = "location.txt";

        if (!File.Exists(fileLocation))
        {
            Console.WriteLine("File can't be found");
        }
        else
        {
            try
            {
                StreamWriter writingLocation = File.AppendText(fileLocation);

                Console.WriteLine("What is the book's code location: ");
                string codeLoc = Console.ReadLine();
                if (codeLoc.Length > 20)
                {
                    Console.WriteLine("Do not write more than 20 characters");
                }
                writingLocation.Write(codeLoc);

                Console.WriteLine("What is the book's house location: ");
                string houseLoc = Console.ReadLine();
                if (houseLoc.Trim() == "")
                {
                    Console.WriteLine("Do not leave field empty");
                }
                writingLocation.Write(" - " + houseLoc + " - ");

                Console.WriteLine("What is the book's shelf location: ");
                string shelfLoc = Console.ReadLine();
                if (shelfLoc.Contains(";"))
                {
                    shelfLoc = shelfLoc.Replace(";", ",");
                }
                writingLocation.WriteLine(shelfLoc);

                //closing writing file so we can open reading file inmmediately afterwards
                writingLocation.Close();

                StreamReader readingLocation = File.OpenText(fileLocation);
                string linea;
                do
                {
                    linea = readingLocation.ReadLine();

                    if (linea != null)
                    {
                        Console.WriteLine(linea);
                    }
                } while (linea != null);

                readingLocation.Close();

            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            catch (Exception ex)
            {

                Console.WriteLine("General error: " + ex.Message);
            }
        }
    }

    //goodbye(option E)
    public static void farewell()
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Goodbye and thank your for your time");
    }

    //wrong input(Default option)
    public static void wrongOption()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Wrong option");
        Console.WriteLine("Choose a number between 1 to 5.");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine();
    }
}

﻿using System;
using System.Collections.Generic;

class HistoryBook : Book
{
    public bool isElectronic { get; set; }
    
    public HistoryBook(string title, string author,
                string description, string genre,
                int year, float rating, bool isElectronic)
                :base(title, author,
                description,  genre,
                year,  rating)
    {
        this.isElectronic = isElectronic;
    }

    public bool GetIsElectronic() { return isElectronic; }

    public void SetIsElectronic() { this.isElectronic = isElectronic; }
    
    //ternary operator to know book format
    public override string ToString()
    {
        return base.ToString() + (this.isElectronic ? " Electronic Format" : " Paper Format");
    }
}

