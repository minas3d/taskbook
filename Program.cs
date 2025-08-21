namespace taskbook
{
    class Book
    {
        public string titel { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public bool avilabilty { get; set; } = true;

        public Book(string titel, string ISBN, string Author, bool avilabilty = true)
        {
            this.titel = titel;
            this.ISBN = ISBN;
            this.Author = Author;
            this.avilabilty = avilabilty;
        }
        public string getvalue()
        {
            return $"Title: {titel}, Author: {Author}, ISBN: {ISBN}, Available: {avilabilty}";
        }

    }
    class Library
    {
        private List<Book> Books = new List<Book>();
        public void AddBook(Book b)
        {
            Books.Add(b);

        }
        public string print()
        {
            string result = "";
            for (int i = 0; i < Books.Count; i++)
            {


                result += Books[i].getvalue() + "\n";
            }
            return result;
        }
        public Book SearchBook(string tatile)
        {

            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].titel == tatile)
                {
                    return Books[i];

                }
            }

            return null;
        }
        public void BorrowBook(Book book)
        {
            if (book != null && book.avilabilty)
            {
                book.avilabilty = false;
            }


        }
        public void ReturnBook(Book book)
        {
            if (book != null && !book.avilabilty)
            {
                book.avilabilty = true;
            }


        }

    }
    internal class Program
    {

        static void Main(string[] args)
        {

            Library library = new Library();
            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "9780743273565", "F. Scott Fitzgerald"));
            library.AddBook(new Book("To Kill a Mockingbird", "9780061120084", "Harper Lee"));
            library.AddBook(new Book("1984", "9780451524935", "George Orwell"));
            Console.WriteLine(library.print());
            Console.WriteLine("================================================================");


            Console.WriteLine("Please enter (S) to search, or press any other key to skip ");
            char key = Convert.ToChar(Console.ReadLine());
            if (key == 'S')
            {
                Console.WriteLine(" Please enter title to search");
                string title = Console.ReadLine();


                Book found2 = library.SearchBook(title);
                if (found2 != null)
                {
                    Console.WriteLine($" the book  is found ");
                }
                else
                {
                    Console.WriteLine("not found ");
                }
            }




            Console.WriteLine("================================================================");

            // Searching and borrowing books
            Console.WriteLine("After borrowing ");
            Console.WriteLine("Searching and borrowing books...");
            Book found;
            found = library.SearchBook("The Great Gatsby");
            library.BorrowBook(found);
            found = library.SearchBook("1984");
            library.BorrowBook(found);
            found = library.SearchBook("To Kill a Mockingbird");
            library.BorrowBook(found);
            Console.WriteLine(library.print());

            // Returning books
            Console.WriteLine("================================================================");
            found = library.SearchBook("To Kill a Mockingbird");
            library.ReturnBook(found);
            found = library.SearchBook("The Great Gatsby");
            library.ReturnBook(found);
            Console.WriteLine("After returning:");
            Console.WriteLine("Returning books...");
            Console.WriteLine(library.print());
            Console.ReadLine();
        }
    }
}