using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Library : IEnumerable<Book>
{
    public List<Book> Books { get; set; }

    public Library(params Book[] books)
    {
        this.Books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.Books);
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> _books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this._books = new List<Book>(books);
        }

        public Book Current
        {
            get { return this._books[this.currentIndex]; }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < _books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

    }
}
