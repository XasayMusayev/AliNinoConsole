using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliNino.Core.Helper
{
    public class HelperColor
    {
        public static void PrintLine(ConsoleColor color,object text)
        {
            Console.ForegroundColor= color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
