using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem__02.BL
{
    internal class Book
    {
        /*-------------- Data Members --------------*/
        public string author;
        public int pages;
        public List<string> Chapters = new List<string>();
        public int bookMark;
        public int price;
        /*-------------- Parameterized Constructor --------------*/
        public Book(string author,int pages)
        {
            this.author= author;
            this.pages= pages;
        }
        /*-------------- Add Chapter Function --------------*/
        public void addChapter(string chapter)
        {
            Chapters.Add(chapter);
        }
        /*-------------- Get Chapter Function --------------*/
        public string getChapter(int chapterNumber)
        {
            return Chapters[chapterNumber-1];
        }
        /*-------------- Set Book Mark Function --------------*/
        public void  setBookMark(int pageNumber)
        {
            bookMark = pageNumber;
        }
        /*-------------- Get Book Mark Function --------------*/
        public int getBookMark()
        {
            return bookMark;
        }
        /*-------------- Set Book Price Function --------------*/
        public void setBookPrice(int bookPrice)
        {
            price = bookPrice;
        }
        /*-------------- Get Book Price Function --------------*/
        public int getBookPrice()
        {
            return price;
        }
    }
}
