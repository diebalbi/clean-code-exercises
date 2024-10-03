namespace Exercises.Integrative_Exercise
{
    internal class Exercise6
    {
        // The following code models a simple library system where LibraryManager processes book loans and calculates late fees.
        // Each Library has a BookCatalog that contains a list of books, and each Book has a Borrower.
        // The LibraryManager class directly accesses nested objects, manages book loans, calculates fees, and displays book details,
        // leading to a complex and convoluted design.
        // Review the code and identify areas for improvement
        public void Exercise()
        {
            var library = new Library();
            var libraryManager = new LibraryManager();

            libraryManager.BorrowBook(library, "Clean Code", "Alice");
            libraryManager.DisplayBookDetails(library, "Clean Code");
            var fee = libraryManager.CalculateLateFee(library, "Clean Code");
            Console.WriteLine($"Late fee: ${fee}");
        }

        public class Library
        {
            public BookCatalog Catalog { get; set; } = new BookCatalog();

            public Library()
            {
                Catalog.AddBook(new Book("Clean Code", "Robert C. Martin"));
            }
        }

        public class BookCatalog
        {
            public List<Book> Books { get; private set; } = new List<Book>();

            public void AddBook(Book book)
            {
                Books.Add(book);
            }
        }

        public class Book
        {
            public string Title { get; private set; }
            public string Author { get; private set; }
            public Borrower CurrentBorrower { get; set; }

            public Book(string title, string author)
            {
                Title = title;
                Author = author;
            }

            public bool IsBorrowed()
            {
                return CurrentBorrower != null;
            }
        }

        public class Borrower
        {
            public string Name { get; private set; }
            public DateTime LoanDate { get; set; }

            public Borrower(string name)
            {
                Name = name;
                LoanDate = DateTime.Now;
            }
        }

        public class LibraryManager
        {
            public double CalculateLateFee(Library library, string bookTitle)
            {
                var book = library.Catalog.Books.FirstOrDefault(b => b.Title == bookTitle);
                if (book == null || !book.IsBorrowed())
                {
                    Console.WriteLine("Book is not borrowed or does not exist.");
                    return 0;
                }

                var daysBorrowed = (DateTime.Now - book.CurrentBorrower.LoanDate).Days;
                return daysBorrowed > 14 ? (daysBorrowed - 14) * 0.5 : 0;
            }

            public void DisplayBookDetails(Library library, string bookTitle)
            {
                var book = library.Catalog.Books.FirstOrDefault(b => b.Title == bookTitle);
                if (book != null)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Borrowed: {book.IsBorrowed()}");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }

            public void BorrowBook(Library library, string bookTitle, string borrowerName)
            {
                var book = library.Catalog.Books.FirstOrDefault(b => b.Title == bookTitle);
                if (book == null || book.IsBorrowed())
                {
                    Console.WriteLine("Book is not available for borrowing.");
                    return;
                }

                book.CurrentBorrower = new Borrower(borrowerName);
                Console.WriteLine($"Book '{book.Title}' borrowed by {borrowerName}.");
            }
        }
    }
}
