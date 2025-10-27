using System;
using System.Globalization;

namespace Luhn
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = "8383 7332 3570 8514";
            Program start= new Program();
            Console.WriteLine(start.validate(n));
        }

        public bool validate(string n)
        {
            return false;
        }
    }
}