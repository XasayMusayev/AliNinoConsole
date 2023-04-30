using AliNino.Core.Enums;
using AliNino.Core.Helper;
using AliNino.Core.Models;
using AliNino.Service.Implementations;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliNino.Service.Service
{
    public class MenuService
    {

        public bool IsAdmin=false;
        private User[] Users = { new User {UserName="admin",Password="admin" } };


        private BookWriterService bookWriterService=new BookWriterService();
        private BookService BookService=new BookService();

        public async Task<bool> Login()
        {
            HelperColor.PrintLine(ConsoleColor.DarkBlue, "Add Username");
            string username = Console.ReadLine();
            HelperColor.PrintLine(ConsoleColor.DarkBlue, "Add password");
            string password = Console.ReadLine();
            if (Users.Any(x => x.UserName == username && x.Password == password))
            {
                IsAdmin = true;
            }
            else
            {
                HelperColor.PrintLine(ConsoleColor.DarkRed,"   -_-     Username or Password incorrect     -_-   ");
                IsAdmin=false;
            }
            return IsAdmin;


        }
        public async Task ShowMenuAdmin()
        {
            
            HelperColor.PrintLine(ConsoleColor.Cyan, " *_- Wellcome Ali Nino book app _Admin *_- ");
            Console.WriteLine();

            HelperColor.PrintLine(ConsoleColor.DarkBlue, "0. --> Close App <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "1. --> Create Book Writer <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "2. --> Show Book Writer <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "3. --> Show Book Writer by id <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "4. --> Show Book Writer's books <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "5. --> Update Book Writer <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "6. --> Remove Book Writer <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "7. --> Create Book <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "8. --> Update Book <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "9. --> Get Book by Book Writer <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "10. --> Remove Book <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "11. --> Show all Books <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "12. --> Buy Book <-- ");

            string command = Console.ReadLine();

            while(command != "0")
            {
                switch (command)
                {
                    case "1":
                        await CreateBookWriter();
                        break;
                    case "2":
                        await ShowBookWriters();
                        break;
                    case "3":
                        await ShowBookWriterbyid();
                        break;
                    case "4":
                        await ShowBookWriterbooks();
                        break;
                    case "5":
                        await UpdateBookWriter();
                        break;
                    case "6":
                        await RemoveBookWriter();
                        break;
                    case "7":
                        await CreateBook();
                        break;
                    case "8":
                        await UpdateBook();
                        break;
                    case "9":
                        await GetBookbyWriter();
                        break;
                    case "10":
                        await RemoveBook();
                        break;
                    case "11":
                        await ShowAllBooks();
                        break;
                    case "12":
                        await BuyBook();
                        break;

                    default:
                        HelperColor.PrintLine(ConsoleColor.Red, "Choosse valid option");
                        break;


                }



                HelperColor.PrintLine(ConsoleColor.DarkBlue, "0. --> Close App <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "1. --> Create Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "2. --> Show Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "3. --> Show Book Writer by id <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "4. --> Show Book Writer's books <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "5. --> Update Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "6. --> Remove Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "7. --> Create Book <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "8. --> Update Book <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "9. --> Get Book by Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "10. --> Remove Book <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "11. --> Show all Books <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "12. --> Buy Book <-- ");
                 command = Console.ReadLine();
            }




        }

        public async Task ShowMenuUser()
        {
            HelperColor.PrintLine(ConsoleColor.Cyan, " ^_^ Wellcome Ali Nino book app for User  ^_^  ");
            Console.WriteLine();

            HelperColor.PrintLine(ConsoleColor.DarkBlue, "0. --> Close App <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "1. --> Show Book Writer <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "2. --> Show Book Writer by id <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "3. --> Show Book Writer's books <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "4. --> Get Book by Book Writer <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "5. --> Show all Books <-- ");
            HelperColor.PrintLine(ConsoleColor.Blue, "6. --> Buy Book <-- ");

            string command = Console.ReadLine();

            while (command != "0")
            {
                switch (command)
                {
                    
                    case "1":
                        await ShowBookWriters();
                        break;
                    case "2":
                        await ShowBookWriterbyid();
                        break;
                    case "3":
                        await ShowBookWriterbooks();
                        break;
                    ;
                    case "4":
                        await GetBookbyWriter();
                        break;
                    
                    case "5":
                        await ShowAllBooks();
                        break;
                    case "6":
                        await BuyBook();
                        break;

                    default:
                        HelperColor.PrintLine(ConsoleColor.Red, "Choosse valid option");
                        break;


                }



                HelperColor.PrintLine(ConsoleColor.DarkBlue, "0. --> Close App <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "1. --> Create Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "2. --> Show Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "3. --> Show Book Writer by id <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "4. --> Show Book Writer's books <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "5. --> Update Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "6. --> Remove Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "7. --> Create Book <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "8. --> Update Book <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "9. --> Get Book by Book Writer <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "10. --> Remove Book <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "11. --> Show all Books <-- ");
                HelperColor.PrintLine(ConsoleColor.Blue, "12. --> Buy Book <-- ");
                command = Console.ReadLine();
            }
        }


        private async Task CreateBookWriter()
        {
            Console.WriteLine("Add Name");
            string name = Console.ReadLine();
            Console.WriteLine("Add Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Add Age");
            int.TryParse(Console.ReadLine(),out int age);

            string message = await bookWriterService.CreateAsync(name, surname, age);
            Console.WriteLine(message);
        }
        private async Task ShowBookWriters()
        {
            await bookWriterService.ShowAllAsync();
        }
        private async Task ShowBookWriterbyid()
        {
            await bookWriterService.ShowAllid();

            Console.WriteLine("Add id");
            Console.WriteLine();
            Console.WriteLine("  ~ID~");
            int.TryParse(Console.ReadLine(), out int id);
            BookWriter bookWriter= await bookWriterService.ShowAsync(id);
            if (bookWriter!=null)
            {
                Console.WriteLine(bookWriter);
            }
        }
        private async Task ShowBookWriterbooks()
        {
            Console.WriteLine("Add id");
            await bookWriterService.ShowAllAsync();

            int.TryParse(Console.ReadLine(), out int id);
            List<Book> books =await bookWriterService.ShowBooksAsync(id);
            if (books!=null)
            {
                foreach (var item in books)
                {
                    Console.WriteLine(item);
                }
            }
        }
        private async Task UpdateBookWriter()
        {
            await bookWriterService.ShowAllAsync();

            Console.WriteLine("Add id");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Add Name");
            string name = Console.ReadLine();
            Console.WriteLine("Add Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Add Age");
            int.TryParse(Console.ReadLine(), out int age); 

            string result = await bookWriterService.UpdateAsync(id,name,surname,age);

            if (result!=null)
            {
                Console.WriteLine(result);
            }
        }
        private async Task RemoveBookWriter()
        {
            Console.WriteLine("Add id");
            int.TryParse(Console.ReadLine(), out int id);
            string result = await bookWriterService.DeleteAsync(id);
            Console.WriteLine(result);
            
        }
        private async Task CreateBook()
        {
            await bookWriterService.ShowAllAsync();
            Console.WriteLine("Add Book Writer with id");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("Add Name");
            string name = Console.ReadLine();
            Console.WriteLine("Add Price");
            double.TryParse(Console.ReadLine(), out double price);
            Console.WriteLine($"Add Discount Price -- {price} -- > =  ");
            double.TryParse(Console.ReadLine(), out double discountprice);
            INSTOCK:
            Console.WriteLine("Add Book in stock -yes or no-");
            bool instockresult;
            string stockin = Console.ReadLine();

            
            if (stockin == "yes")
            {
                 instockresult = true;

            }
            else if (stockin == "no")
            {
                instockresult = false;

            }
            else
            {
                goto INSTOCK;   
            }



            BookCategory category;
            Console.WriteLine("Choose Book's Category");
            foreach (var item in Enum.GetValues(typeof(BookCategory)))
            {
                HelperColor.PrintLine(ConsoleColor.Yellow,(int)item+" - "+ item);
            }
            int.TryParse(Console.ReadLine(), out int categoryindex);
            bool catresult = Enum.IsDefined(typeof(BookCategory), categoryindex);
            while (!catresult)
            {
                Console.WriteLine("Choose Valid Category");
                int.TryParse(Console.ReadLine(), out categoryindex);
                catresult = Enum.IsDefined(typeof(BookCategory), categoryindex);
            }
            category = (BookCategory)categoryindex;

            string message = await BookService.CreateAsync(id,name,price,discountprice,category, instockresult);
            Console.WriteLine(message);
            

        }
        private async Task UpdateBook()
        {
            Console.WriteLine("Add Book Writer with id");
            await bookWriterService.ShowAllAsync();
            int.TryParse(Console.ReadLine(), out int writerid);
            List<Book> books = await bookWriterService.ShowBooksAsync(writerid);
            if (books != null)
            {
                foreach (var item in books)
                {
                    Console.WriteLine(item);
                }
            }
            HelperColor.PrintLine(ConsoleColor.White,"Add Book with id");
            int.TryParse(Console.ReadLine(), out int bookid);
            Console.WriteLine("Add Name");
            string name = Console.ReadLine();
            Console.WriteLine("Add Price");
            double.TryParse(Console.ReadLine(), out double price);
            Console.WriteLine($"Add Discount Price -- {price} -- > =   ");
            double.TryParse(Console.ReadLine(), out double discountprice);
            INSTOCK:
            Console.WriteLine("Add Book in stock -yes or no-");
            bool instockresult;
            string stockin = Console.ReadLine();


            if (stockin == "yes")
            {
                instockresult = true;

            }
            else if (stockin == "no")
            {
                instockresult = false;

            }
            else
            {
                goto INSTOCK;
            }
            BookCategory category;
            Console.WriteLine("Choose Book's Category");
            foreach (var item in Enum.GetValues(typeof(BookCategory)))
            {
                Console.WriteLine((int)item + " " + item);
            }
            int.TryParse(Console.ReadLine(), out int categoryindex);
            bool catresult = Enum.IsDefined(typeof(BookCategory), categoryindex);
            while (!catresult)
            {
                Console.WriteLine("Choose Valid Category");
                int.TryParse(Console.ReadLine(), out categoryindex);
                catresult = Enum.IsDefined(typeof(BookCategory), categoryindex);
            }
            category = (BookCategory)categoryindex;

            string message = await BookService.UpdateAsync(writerid,bookid,name,price,discountprice,category,instockresult);
            Console.WriteLine(message);
        }
        private async Task GetBookbyWriter()
        {
            Console.WriteLine("Add Book Writer with id");
            await bookWriterService.ShowAllAsync();
            int.TryParse(Console.ReadLine(), out int writerid);
            List<Book> books = await bookWriterService.ShowBooksAsync(writerid);
            if (books != null)
            {
                foreach (var item in books)
                {
                    Console.WriteLine(item.Id);
                }
            }
            Console.WriteLine("Add Book with id");
            int.TryParse(Console.ReadLine(), out int bookid);

            Book book = await BookService.ShowAsync(writerid, bookid);
            if (book!=null)
            {
                Console.WriteLine(book);
            }
        }
        private async Task RemoveBook()
        {
            Console.WriteLine("Add Book Writer with id");
            await bookWriterService.ShowAllAsync();
            int.TryParse(Console.ReadLine(), out int writerid);
            Console.WriteLine("Add Book with id");
            int.TryParse(Console.ReadLine(), out int bookid);

            string message = await BookService.DeleteAsync(writerid, bookid);
            
            Console.WriteLine(message);
            
        }
        private async Task ShowAllBooks()
        {
            await BookService.ShowAllAsync();
        }
        private async Task BuyBook()
        {
            Console.WriteLine("Add Book Writer with id");
            Console.WriteLine();
            await bookWriterService.ShowAllAsync();

            int.TryParse(Console.ReadLine(), out int writerid);
            Console.WriteLine("Add Book with id");
            Console.WriteLine();
            List<Book> books = await bookWriterService.ShowBooksAsync(writerid);
            if (books != null)
            {
                foreach (var item in books)
                {
                    Console.WriteLine(item);
                }
            }

            int.TryParse(Console.ReadLine(), out int bookid);

            Book book = await BookService.ShowAsync(writerid, bookid);
            if (book != null)
            {
                if (book.inStock)
                {
                    Console.WriteLine("sold :) ");
                    await BookService.DeleteAsync(writerid, bookid);


                }
                else
                {
                    Console.WriteLine("This book is not in stock -_- ");
                }
                
            }
        }







    }
}
