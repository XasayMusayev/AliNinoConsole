using AliNino.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliNino.Core.Models
{
    public class BookWriter:BaseModel
    {
        private static int _id;
        public string Surname{ get; set; }
        public int Age { get; set; }
        public List<Book> Books;

        public BookWriter(string name, string surname, int age)
        {
            _id++;
            Id=_id;
            Name=name;
            Surname = surname;
            Age = age;
            Books = new List<Book>();
            CreatedDate = DateTime.UtcNow.AddHours(4);
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            return $"Book Writer --> id - {Id} , Name - {Name} , Surname - {Surname} , Age - {Age} , Created Date - {CreatedDate} , Update Date - {UpdatedDate}";
        }
    }
}
