using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Central Library Search System ---\n");

            Book[] catalog = new Book[]
            {
                new Book("LIB001", "A Fine Balance", "Rohinton Mistry"),
                new Book("LIB002", "Malgudi Days", "R.K. Narayan"),
                new Book("LIB003", "The God of Small Things", "Arundhati Roy"),
                new Book("LIB004", "The White Tiger", "Aravind Adiga"),
                new Book("LIB005", "Train to Pakistan", "Khushwant Singh")
            };

            LibraryCatalog library = new LibraryCatalog();

            Console.WriteLine("Executing Linear Search for 'Malgudi Days'...");
            Book? linearResult = library.LinearSearchByTitle(catalog, "Malgudi Days");
            if (linearResult != null)
            {
                Console.WriteLine($"[Linear Search Match] ID: {linearResult.BookId} | Title: {linearResult.Title} | Author: {linearResult.Author}");
            }

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("Executing Binary Search for 'The White Tiger'...");
            Book? binaryResult = library.BinarySearchByTitle(catalog, "The White Tiger");
            if (binaryResult != null)
            {
                Console.WriteLine($"[Binary Search Match] ID: {binaryResult.BookId} | Title: {binaryResult.Title} | Author: {binaryResult.Author}");
            }
        }
    }
}