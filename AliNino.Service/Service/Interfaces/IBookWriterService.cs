using AliNino.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliNino.Service.Interfaces
{
    public interface IBookWriterService
    {
        public Task<string> CreateAsync(string name, string surname, int age);
        public Task ShowAllAsync(); 
        public Task<BookWriter> ShowAsync(int id);
        public Task<string> UpdateAsync(int id,string name, string surname, int age);
        public Task<string> DeleteAsync(int id);
        public Task<List<Book>> ShowBooksAsync(int id);

    }
}
