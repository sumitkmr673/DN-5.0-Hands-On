using System;

namespace LibraryManagementSystem
{
    public class Book
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string id, string title, string author)
        {
            BookId = id;
            Title = title;
            Author = author;
        }
    }

    public class LibraryCatalog
    {
        public Book? LinearSearchByTitle(Book[] books, string targetTitle)
        {
            foreach (var book in books)
            {
                if (book.Title.Equals(targetTitle, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }

        public Book? BinarySearchByTitle(Book[] books, string targetTitle)
        {
            int left = 0;
            int right = books.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                int comparison = string.Compare(books[mid].Title, targetTitle, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    return books[mid];
                }
                if (comparison < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return null;
        }
    }
}