namespace Solutions.Integrative_Solutions
{
    internal class Solution6
    {
        //- Encapsulation with Methods:
        // Although the properties are public, the primary actions(Borrow and Return) are still managed through methods.
        // This demonstrates the importance of maintaining control over certain state changes.
        // For example, the Borrow method checks if the book is already borrowed before assigning a new value to CurrentBorrower.
        //- Orchestrator Methods in Library: The methods in the Library class (BorrowBook, ReturnBook, AddBook, GetBook, DisplayInventory) now act as
        // orchestrators. They do not delegate everything to a single class but instead combine multiple internal calls to complete more complex tasks.
        //- Use of Constants to Avoid "Magic Numbers": Replaced "magic numbers" with constants (LOAN_PERIOD_DAYS and DAILY_FINE) in the Book class.
        // This not only improves the readability of the code but also makes it easier to change business rules in the future since these values are
        // centralized.
        //- Centralized Error Handling: Introduced a custom exception, LibraryOperationException, for known errors.
        // A single try-catch block in the Exercise method now handles both specific exceptions and general errors.
        // This centralizes error handling, making the code cleaner and more maintainable.
        public void Main()
        {
            var library = new Library();
            var libraryManager = new LibraryManager(library);

            try
            {
                library.AddBook(new Book("Clean Code", "Robert C. Martin"));
                libraryManager.BorrowBook("Clean Code", "Alice");
                libraryManager.DisplayBookDetails("Clean Code");
                libraryManager.ReturnBook("Clean Code");
                var fee = libraryManager.CalculateLateFee("Clean Code");
                Console.WriteLine($"Late fee: ${fee}");
            }
            catch (LibraryOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public class LibraryOperationException : Exception
        {
            public LibraryOperationException(string message) : base(message) { }
        }

        public class Library
        {
            private BookCatalog _catalog = new();

            public void AddBook(Book book)
            {
                _catalog.AddBook(book);
            }

            public void BorrowBook(string title, string borrowerName)
            {
                var book = GetBook(title);
                book.Borrow(borrowerName);
            }

            public void ReturnBook(string title)
            {
                var book = GetBook(title);
                book.Return();
            }

            public Book GetBook(string title)
            {
                Book book = _catalog.GetBookByTitle(title);
                return book ?? throw new LibraryOperationException($"Book '{title}' not found in the catalog.");
            }

            public void DisplayInventory()
            {
                Console.WriteLine("Library Inventory:");
                foreach (var book in _catalog.GetAllBooks())
                {
                    book.DisplayDetails();
                }
            }
        }

        public class BookCatalog
        {
            private List<Book> _books = new();

            public void AddBook(Book book)
            {
                _books.Add(book);
            }

            public Book GetBookByTitle(string title)
            {
                return _books.FirstOrDefault(b => b.Title == title);
            }

            public List<Book> GetAllBooks()
            {
                return _books;
            }
        }

        public class Book
        {
            private const int LOAN_PERIOD_DAYS = 14;
            private const double DAILY_FINE = 0.5;

            public string Title { get; set; }
            public string Author { get; set; }
            public Borrower? CurrentBorrower { get; set; }

            public Book(string title, string author)
            {
                Title = title;
                Author = author;
            }

            public bool IsBorrowed()
            {
                return CurrentBorrower != null;
            }

            public void Borrow(string borrowerName)
            {
                if (IsBorrowed())
                {
                    throw new LibraryOperationException("Book is already borrowed.");
                }

                CurrentBorrower = new Borrower(borrowerName);
            }

            public void Return()
            {
                if (!IsBorrowed())
                {
                    throw new LibraryOperationException("Book is not currently borrowed.");
                }

                CurrentBorrower = null;
            }

            public double CalculateLateFee()
            {
                if (!IsBorrowed())
                {
                    return 0;
                }

                var daysBorrowed = (DateTime.Now - CurrentBorrower.LoanDate).Days;
                return daysBorrowed > LOAN_PERIOD_DAYS ? (daysBorrowed - LOAN_PERIOD_DAYS) * DAILY_FINE : 0;
            }

            public void DisplayDetails()
            {
                Console.WriteLine($"Title: {Title}, Author: {Author}, Borrowed: {IsBorrowed()}");
            }
        }

        public class Borrower
        {
            public string Name { get; set; }
            public DateTime LoanDate { get; set; }

            public Borrower(string name)
            {
                Name = name;
                LoanDate = DateTime.Now;
            }
        }

        public class LibraryManager
        {
            private Library _library;

            public LibraryManager(Library library)
            {
                _library = library;
            }

            public void BorrowBook(string bookTitle, string borrowerName)
            {
                _library.BorrowBook(bookTitle, borrowerName);
                Console.WriteLine($"Book '{bookTitle}' borrowed by {borrowerName}.");
            }

            public void ReturnBook(string bookTitle)
            {
                _library.ReturnBook(bookTitle);
                Console.WriteLine($"Book '{bookTitle}' returned.");
            }

            public void DisplayBookDetails(string bookTitle)
            {
                var book = _library.GetBook(bookTitle);
                book.DisplayDetails();
            }

            public void DisplayInventory()
            {
                _library.DisplayInventory();
            }

            public double CalculateLateFee(string bookTitle)
            {
                var book = _library.GetBook(bookTitle);
                return book.CalculateLateFee();
            }
        }
    }
}
