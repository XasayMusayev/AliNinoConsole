using AliNino.Core.Helper;
using AliNino.Core.Models;
using AliNino.Data.Repositories.BookWriterRepos;
using AliNino.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliNino.Service.Implementations
{
    public class BookWriterService : IBookWriterService
    {
        private readonly static BookWriterRepository _repository=new BookWriterRepository();    
        public async Task<string> CreateAsync(string name, string surname, int age)
        {
            Console.ForegroundColor=ConsoleColor.DarkRed;
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid Name";
            
            if (string.IsNullOrWhiteSpace(surname))
                return "Add valid Surname";

            if (age<=0)
                return "Add valid Age";
            

            Console.ForegroundColor=ConsoleColor.Green;   
            BookWriter bookWriter = new BookWriter(name,surname,age);
            await _repository.AddAsync(bookWriter);
             return "Successfully created Book Writer";
           
        }

        public async Task<string> DeleteAsync(int id)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            BookWriter bookWriter = await _repository.GetAsync(b=>b.Id == id);

            if (bookWriter==null)
                return "Book Writer not found";

            await _repository.RemoveAsync(bookWriter);

            Console.ForegroundColor = ConsoleColor.Red;

            return "Deleted Book Writer";
        }

        public async Task ShowAllAsync()
        {
            foreach (var item in  await _repository.GetAllAsync())
            {
                HelperColor.PrintLine(ConsoleColor.DarkMagenta, item);
            }
        }
        public async Task ShowAllid()
        {
            foreach (var item in await _repository.GetAllAsync())
            {
                HelperColor.PrintLine(ConsoleColor.DarkMagenta, item.Id);
            }
        }

        public async Task<BookWriter> ShowAsync(int id)
        {
            BookWriter bookWriter= await _repository.GetAsync(b=>b.Id == id);

            if (bookWriter==null)
            {
                HelperColor.PrintLine(ConsoleColor.DarkRed,"Book Writer not found");
                return null;

            }
            return bookWriter;


        }

        public async Task<List<Book>> ShowBooksAsync(int id)
        {
            BookWriter bookWriter=await _repository.GetAsync(b=>b.Id==id);

            if (bookWriter==null)
            {
                HelperColor.PrintLine(ConsoleColor.DarkRed,"Book Writer not found");
                return null;
            }
            if (bookWriter.Books.Count==0)
            {
                HelperColor.PrintLine(ConsoleColor.DarkRed, "This Book Writer does not have any book");
                return null;

            }
            Console.ForegroundColor = ConsoleColor.Cyan;

            return bookWriter.Books;


            
        }

        public async Task<string> UpdateAsync(int id,string name,string surname,int age)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid Name";

            if (string.IsNullOrWhiteSpace(surname))
                return "Add valid Surname";

            if (age <= 0)
                return "Add valid Age";


            BookWriter bookWriter = await _repository.GetAsync(x => x.Id == id);
            if (bookWriter==null)
            {
                return "Book Writer not found";
            }
            bookWriter.Name = name;
            bookWriter.Age = age;
            bookWriter.Surname = surname;

            Console.ForegroundColor = ConsoleColor.Green;

            return "Updated Book Writer";


        }
    }
}
