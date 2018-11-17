using System;

namespace BinarySearchTreeTests.Models
{
    public class Book: IComparable<Book>
    {
        public Book(int price) => Price = price;

        public int Price { get; set; }

        public int CompareTo(Book other) => Price.CompareTo(other.Price);
    }
}
