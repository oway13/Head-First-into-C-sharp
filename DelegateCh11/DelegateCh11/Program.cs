using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCh11
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertsIntToString someMethod = new ConvertsIntToString(HiThere);
            string message = someMethod(5);
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private static string HiThere(int i)
        {
            return "Hi there! #" + i * 100;
        }
    }
}
