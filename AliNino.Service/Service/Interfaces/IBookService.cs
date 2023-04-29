using AliNino.Core.Enums;
using AliNino.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliNino.Service.Interfaces
{
    public interface IBookService
    {
        public Task<string> CreateAsync(int id,string name, double price, double discountprice, BookCategory category, bool instock);
        public Task<string> DeleteAsync(int Writerid, int Bookid);
        public Task<string> UpdateAsync(int Writerid, int Bookid, string name, double price, double discountprice, BookCategory category, bool instock);
        public Task<Book> ShowAsync(int Writerid,int Bookid);

        public Task<string> BuyBook(int Writerid,int Bookid);
        public Task ShowAllAsync();
    }
}
