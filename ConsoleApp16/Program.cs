// See https://aka.ms/new-console-template for more information

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
}

public class Library
{
    private List<Book> _books;

    public Library()
    {
        _books = new List<Book>();
    }

    public int Count
    {
        get { return _books.Count; }
    }

    public void PrintBooks()
    {
        if (_books.Count == 0)
        {
            Console.WriteLine("The library has no books.");
            return;
        }


        foreach (var book in _books)
        {
            Console.WriteLine($"Title: {book.Title} : Author: {book.Author}");
        }
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
        Console.WriteLine($"Book '{book.Title}' has been successfully added.");
    }

    public bool RemoveBook(string title)
    {
        bool isRemoved = false;
        for (int i = 0; i < _books.Count; i++)
        {
            if (_books[i].Title == title)
            {
                _books.RemoveAt(i);
                Console.WriteLine($"Book '{title}' has been successfully removed.");
                isRemoved = true;
                break;
            }
        }

        if (!isRemoved)
        {
            Console.WriteLine($"Book with title '{title}' was not found.");
        }

        return isRemoved;
    }

    public List<Book> FindBook(string title)
    {
        List<Book> foundBooks = new List<Book>();
        for (int i = 0; i < _books.Count; i++)
        {
            if (_books[i].Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            {
                foundBooks.Add(_books[i]);
            }
        }
        return foundBooks;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new Book("Vepkhvistqaosani", "Shota Rustaveli", 1200));
        library.AddBook(new Book("didostatis marjvena", "Konstantine Gamsakhurdia", 1939));
        library.AddBook(new Book("Datha Tutashkhia", "Chabua Amirejibi", 1975));
        library.AddBook(new Book("Vepkhvistqaosani (Modern Edition)", "Shota Rustaveli", 2020));

        Console.WriteLine("\nTotal number of books: " + library.Count);

        Console.WriteLine("\n all books:");
        library.PrintBooks();

        Console.WriteLine("\nSearching for 'Vepkhvistqaosani':");
        var foundBooks = library.FindBook("Vepkhvistqaosani");
        foreach (var book in foundBooks)
        {
            Console.WriteLine($"Found: {book.Title} - {book.Author} ({book.Year})");
        }

        Console.WriteLine("\nRemoving a book:");
        library.RemoveBook("Datha Tutashkhia");

        Console.WriteLine("\nFinal list:");
        library.PrintBooks();
    }
}
