using AliNino.Core.Enums;
using AliNino.Core.Helper;
using AliNino.Core.Models;
using AliNino.Data.Repositories.BookWriterRepos;
using AliNino.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AliNino.Service.Implementations
{
    public class BookService : IBookService
    {
        private readonly BookWriterRepository _repository = new BookWriterRepository();
        public async Task<string> CreateAsync(int id,string name, double price, double discountprice, BookCategory category, bool instock)
        {
            Console.ForegroundColor= ConsoleColor.DarkRed;

            BookWriter bookWriter = await _repository.GetAsync(x => x.Id == id);
            if (bookWriter==null)
                return "Book Writer not found ";
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid Name";
            if (price <= 0)
                return "Add valid price";
            if (discountprice>price || discountprice<=0)
                return "Add valid discount price";


            Book book = new Book(name, price, discountprice, category,instock,bookWriter);

            bookWriter.Books.Add(book);

            Console.ForegroundColor = ConsoleColor.Green;

            return "Book Successfully created";






        }
        public async Task<string> DeleteAsync(int Writerid, int Bookid)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            BookWriter bookWriter = await _repository.GetAsync(x => x.Id == Writerid);
            if (bookWriter == null)
                return "Book Writer not found ";

            Book book = bookWriter.Books.FirstOrDefault(b => b.Id == Bookid);

            if (book==null)
                return "Book not found";
            
            bookWriter.Books.Remove(book);

            Console.ForegroundColor = ConsoleColor.Red;

            return "Book deleted";



        }
        public async Task<Book> ShowAsync(int Writerid, int Bookid)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            BookWriter bookWriter = await _repository.GetAsync(x => x.Id == Writerid);
            if (bookWriter == null)
            {
                Console.WriteLine("Book Writer not found ");
                return null;
            }

            Book book = bookWriter.Books.FirstOrDefault(b => b.Id == Bookid);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;

            return book;

        }
        public async Task<string> UpdateAsync(int Writerid, int Bookid, string name, double price, double discountprice, BookCategory category, bool instock)
        {
            
            Console.ForegroundColor = ConsoleColor.DarkRed;

                BookWriter bookWriter = await _repository.GetAsync(x => x.Id == Writerid);
                if (bookWriter == null)
                    return "Book Writer not found ";

                Book book = bookWriter.Books.FirstOrDefault(b => b.Id == Bookid);

                if (book==null)
                    return "Book not found";

            if (bookWriter == null)
                return "Book Writer not found ";

            if (string.IsNullOrWhiteSpace(name))
                return "Add valid Name";

            if (price <= 0)
                return "Add valid price";

            if (discountprice > price || discountprice <= 0)
                return "Add valid discount price";



            book.Name=name;
            book.Price=price;
            book.DiscountPrice=discountprice;
            book.Category=category;
            book.inStock=instock;

            return "Book updated";


        }
        public async Task<string> BuyBook(int Writerid, int Bookid)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            BookWriter bookWriter = await _repository.GetAsync(x => x.Id == Writerid);
            if (bookWriter == null)
                return "Book Writer not found ";

            Book book = bookWriter.Books.FirstOrDefault(b => b.Id == Bookid);

            if (book == null)
                return "Book not found";
            Console.ForegroundColor = ConsoleColor.Green;


            if (book.inStock)
            {
                return $"{book.Name} sold  ";
            }
            return "There is not book in stock";

        }
        public async Task ShowAllAsync()
        {
            foreach (var item in await _repository.GetAllAsync() )
            {
                foreach (var prod in item.Books)
                {
                    HelperColor.PrintLine(ConsoleColor.Cyan, item);
                }
            }
        }


    }
}
