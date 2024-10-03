namespace Exercises.Integrative_Exercise
{
    internal class Exercise4
    {
        // You are building a simple library management system. The library needs to manage books, handle book loans, and calculate overdue fines.
        // The current code is a single class that tries to handle all of these responsibilities.
        // Analyze the code to identify areas that need improvement.
        public static void Main()
        {
            var libraryManager = new LibraryManager();
            libraryManager.AddBook("1984", "George Orwell", 1949);
            libraryManager.LoanBook("1984", "John Doe", DateTime.Now);
            libraryManager.ReturnBook("1984", DateTime.Now.AddDays(20));
            var fine = libraryManager.CalculateFine("1984", DateTime.Now.AddDays(20));
            Console.WriteLine($"Fine for '1984': ${fine}");
        }

        public class LibraryManager
        {
            public List<Book> Books { get; set; } = new List<Book>();
            public List<Loan> Loans { get; set; } = new List<Loan>();

            public void AddBook(string title, string author, int year)
            {
                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || year <= 0)
                {
                    Console.WriteLine("Invalid book details.");
                    return;
                }

                var book = new Book { Title = title, Author = author, Year = year, IsAvailable = true };
                Books.Add(book);
                Console.WriteLine($"Book '{title}' added to the library.");
            }

            public void LoanBook(string title, string borrower, DateTime loanDate)
            {
                var book = Books.FirstOrDefault(b => b.Title == title && b.IsAvailable);
                if (book == null)
                {
                    Console.WriteLine("Book is not available.");
                    return;
                }

                var loan = new Loan { BookTitle = title, Borrower = borrower, LoanDate = loanDate, ReturnDate = null };
                book.IsAvailable = false;
                Loans.Add(loan);

                Console.WriteLine($"Book '{title}' loaned to {borrower} on {loanDate.ToShortDateString()}.");
            }

            public void ReturnBook(string title, DateTime returnDate)
            {
                var loan = Loans.FirstOrDefault(l => l.BookTitle == title && l.ReturnDate == null);
                if (loan == null)
                {
                    Console.WriteLine("Loan not found.");
                    return;
                }

                loan.ReturnDate = returnDate;

                var book = Books.FirstOrDefault(b => b.Title == title);
                if (book != null)
                {
                    book.IsAvailable = true;
                }

                Console.WriteLine($"Book '{title}' returned on {returnDate.ToShortDateString()}.");
            }

            public double CalculateFine(string title, DateTime currentDate)
            {
                var loan = Loans.FirstOrDefault(l => l.BookTitle == title && l.ReturnDate == null);
                if (loan == null)
                {
                    Console.WriteLine("Loan not found.");
                    return 0;
                }

                var daysOverdue = (currentDate - loan.LoanDate).Days - 14; // Assuming a 14-day loan period
                if (daysOverdue > 0)
                {
                    return daysOverdue * 0.5; // $0.5 fine per day
                }

                return 0;
            }
        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
            public bool IsAvailable { get; set; }
        }

        public class Loan
        {
            public string BookTitle { get; set; }
            public string Borrower { get; set; }
            public DateTime LoanDate { get; set; }
            public DateTime? ReturnDate { get; set; }
        }
    }
}
