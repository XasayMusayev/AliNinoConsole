using AliNino.Core.Enums;
using AliNino.Core.Helper;
using AliNino.Core.Models.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliNino.Core.Models
{
    public class Book:BaseModel
    {
        private static int _id;
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public BookWriter Bookwriter { get; set; }
        public BookCategory Category { get; set; }
        public bool inStock { get; set; }
        public Book(string name, double price, double discountprice,BookCategory category,bool instock, BookWriter bookWriter)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            DiscountPrice = discountprice;
            Bookwriter = bookWriter;
            Category = category;
            inStock = instock;
            CreatedDate = DateTime.UtcNow.AddHours(4);



        }

        public override string ToString()
        {
            if (DiscountPrice<Price)
            {
                if (inStock)
                {
                    Console.WriteLine();
                    HelperColor.PrintLine(ConsoleColor.Cyan, $"id = {Id} Book --> Name - {Name} , *Discount* *Price* - {DiscountPrice} $ , Category - {Category}");
                    Console.WriteLine("-------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return $" This book is in * Stock * ";

                }
                else
                {
                    HelperColor.PrintLine(ConsoleColor.Cyan, $"id = {Id} Book --> Name - {Name} , * Discount * * Price * - {DiscountPrice} $ , Category - {Category} ");
                    Console.WriteLine("-------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return $"This book is * not *  in Stock";
                }

            }
            else
            {
                if (inStock)
                {
                    Console.WriteLine();
                    HelperColor.PrintLine(ConsoleColor.Cyan, $"id = {Id} Book --> Name - {Name} , Price - {Price} $ , Category - {Category} ");
                    Console.WriteLine("-------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return $" This book is in * Stock *";

                }
                else
                {
                    HelperColor.PrintLine(ConsoleColor.Cyan, $"id =  {Id}  Book --> Name - {Name} , Price - {Price} $ , Category - {Category} ");
                    Console.WriteLine("-------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return $"This book is * not * in Stock";
                }


            }
        }


    }
}
