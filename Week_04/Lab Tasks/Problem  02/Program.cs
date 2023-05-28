using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem__02.BL;

namespace Problem__02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*-------------- Adding Book --------------*/
            Console.Write("Enter Author Name: ");
            string author= Console.ReadLine();
            Console.Write("Enter Total Number of Pages: ");
            int pages = int.Parse(Console.ReadLine());

            Book b1 = new Book(author,pages);
            b1.addChapter("Chapter 1: Introduction to OOP");
            b1.addChapter("Chapter 2: Basic of OOP");

            // Taking Input For Chapter Number 
            Console.WriteLine("Enter Chapter Number(1/2): ");
            int chapterNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(b1.getChapter(chapterNumber));

            /*-------------- Printing Book Mark --------------*/
            Console.Write("Enter page number for bookmark: ");
            int bookMark = int.Parse(Console.ReadLine());
            b1.setBookMark(bookMark);
            Console.WriteLine("Book Marks is: " + b1.getBookMark());

            /*-------------- Printing Price --------------*/
            Console.Write("Enter Price: ");
            int price = int.Parse(Console.ReadLine());
            b1.setBookPrice(price);
            Console.WriteLine("Book Price is: " + b1.getBookPrice());
            Console.ReadKey();
        }
    }
}
