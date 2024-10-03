namespace Solutions.Integrative_Solutions
{
    class Solution4
    {
        //- Separation of Responsibilities: Split the LibraryManager into three classes: BookInventory for managing book details,
        // LoanManager for handling loans, and LibraryManager for coordinating operations.
        //- Encapsulation: Changed the properties in Book and Loan classes to private, providing methods(SetAvailability, MarkAsReturned, etc.)
        // for controlled state changes.
        //- Error Handling: Improved error handling within the LoanManager and BookInventory classes, adding methods to manage inventory
        // and loan-related logic.
        //- Magic Numbers: Introduced constants (LOAN_PERIOD_DAYS, DAILY_FINE) in the Loan class to avoid using magic numbers directly in the code.
        //- Use of Methods and Properties: Added methods in Book (SetAvailability) and Loan (CalculateOverdueFine) to encapsulate logic
        // within their respective classes, reducing the overall complexity.
        public static void Main()
        {
            var bookInventory = new BookInventory();
            var loanManager = new LoanManager();
            var libraryManager = new LibraryManager(bookInventory, loanManager);

            libraryManager.AddBook("1984", "George Orwell", 1949);
            libraryManager.LoanBook("1984", "John Doe", DateTime.Now);
            libraryManager.ReturnBook("1984", DateTime.Now.AddDays(20));
            var fine = libraryManager.CalculateFine("1984", DateTime.Now.AddDays(20));
            Console.WriteLine($"Fine for '1984': ${fine}");
        }
        public class LibraryManager
        {
            private readonly BookInventory _bookInventory;
            private readonly LoanManager _loanManager;

            public LibraryManager(BookInventory bookInventory, LoanManager loanManager)
            {
                _bookInventory = bookInventory;
                _loanManager = loanManager;
            }

            public void AddBook(string title, string author, int year)
            {
                _bookInventory.AddBook(new Book(title, author, year));
            }

            public void LoanBook(string title, string borrower, DateTime loanDate)
            {
                _loanManager.LoanBook(title, borrower, loanDate, _bookInventory);
            }

            public void ReturnBook(string title, DateTime returnDate)
            {
                _loanManager.ReturnBook(title, returnDate, _bookInventory);
            }

            public double CalculateFine(string title, DateTime currentDate)
            {
                return _loanManager.CalculateFine(title, currentDate);
            }
        }

        public class BookInventory
        {
            private List<Book> _books = new List<Book>();

            public void AddBook(Book book)
            {
                if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author) || book.Year <= 0)
                {
                    Console.WriteLine("Invalid book details.");
                    return;
                }

                _books.Add(book);
                Console.WriteLine($"Book '{book.Title}' added to the inventory.");
            }

            public Book GetAvailableBook(string title)
            {
                return _books.FirstOrDefault(b => b.Title == title && b.IsAvailable);
            }

            public void UpdateBookAvailability(string title, bool isAvailable)
            {
                var book = _books.FirstOrDefault(b => b.Title == title);
                if (book != null)
                {
                    book.SetAvailability(isAvailable);
                }
            }

            public void DisplayInventory()
            {
                Console.WriteLine("Library Inventory:");
                foreach (var book in _books)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} ({book.Year}) - {(book.IsAvailable ? "Available" : "Not Available")}");
                }
            }
        }

        public class LoanManager
        {
            private List<Loan> _loans = new List<Loan>();

            public void LoanBook(string title, string borrower, DateTime loanDate, BookInventory bookInventory)
            {
                var book = bookInventory.GetAvailableBook(title);
                if (book == null)
                {
                    Console.WriteLine("Book is not available.");
                    return;
                }

                var loan = new Loan(title, borrower, loanDate);
                bookInventory.UpdateBookAvailability(title, false);
                _loans.Add(loan);

                Console.WriteLine($"Book '{title}' loaned to {borrower} on {loanDate.ToShortDateString()}.");
            }

            public void ReturnBook(string title, DateTime returnDate, BookInventory bookInventory)
            {
                var loan = _loans.FirstOrDefault(l => l.BookTitle == title && l.ReturnDate == null);
                if (loan == null)
                {
                    Console.WriteLine("Loan not found.");
                    return;
                }

                loan.MarkAsReturned(returnDate);
                bookInventory.UpdateBookAvailability(title, true);

                Console.WriteLine($"Book '{title}' returned on {returnDate.ToShortDateString()}.");
            }

            public double CalculateFine(string title, DateTime currentDate)
            {
                var loan = _loans.FirstOrDefault(l => l.BookTitle == title && l.ReturnDate == null);
                if (loan == null)
                {
                    Console.WriteLine("Loan not found.");
                    return 0;
                }

                return loan.CalculateOverdueFine(currentDate);
            }
        }

        public class Book
        {
            public string Title { get; private set; }
            public string Author { get; private set; }
            public int Year { get; private set; }
            public bool IsAvailable { get; private set; }

            public Book(string title, string author, int year)
            {
                Title = title;
                Author = author;
                Year = year;
                IsAvailable = true;
            }

            public void SetAvailability(bool isAvailable)
            {
                IsAvailable = isAvailable;
            }
        }

        public class Loan
        {
            public string BookTitle { get; private set; }
            public string Borrower { get; private set; }
            public DateTime LoanDate { get; private set; }
            public DateTime? ReturnDate { get; private set; }
            private const int LOAN_PERIOD_DAYS = 14;
            private const double DAILY_FINE = 0.5;

            public Loan(string bookTitle, string borrower, DateTime loanDate)
            {
                BookTitle = bookTitle;
                Borrower = borrower;
                LoanDate = loanDate;
            }

            public void MarkAsReturned(DateTime returnDate)
            {
                ReturnDate = returnDate;
            }

            public double CalculateOverdueFine(DateTime currentDate)
            {
                var daysOverdue = (currentDate - LoanDate).Days - LOAN_PERIOD_DAYS;
                return daysOverdue > 0 ? daysOverdue * DAILY_FINE : 0;
            }
        }
    }
}
