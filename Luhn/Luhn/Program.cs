using Microsoft.Win32.SafeHandles;
using System;
using System.Globalization;

namespace Luhn
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = "5422 0148 5514";
            Program start = new Program();
            Console.WriteLine(start.validate(n));
        }

        public bool validate(string n)
        {
            string withoutSpaces = n.Replace(" ", "");
            int[] numbersList = new int[withoutSpaces.Length];
            for (int i = 0; i < withoutSpaces.Length; i++)
            {
                numbersList[i] = int.Parse(withoutSpaces[i].ToString());
            }

            int sum = 0;

            for (int i = numbersList.Length - 1; i >= 0; i--)
            {
                int position = numbersList.Length - i;
                int doubled = numbersList[i] * 2;

                if (position % 2 == 0)
                {
                    if (doubled > 9)
                        sum += doubled % 10 + 1;
                    else
                        sum += doubled;
                }
                else
                {
                    sum += numbersList[i];
                }
            }
            return sum % 10 == 0;
        }
    }
}