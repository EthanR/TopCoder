using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM690
{
    class DoubleString
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Check("HAHA"));
        }

        public static string Check(string potentialString)
        {
            if (potentialString.Length == 1)
            {
                return "not square";
            }

            string firstHalf = potentialString.Substring(0, (potentialString.Length / 2));
            string secondHalf = potentialString.Substring((potentialString.Length / 2));
            return firstHalf == secondHalf ? "square" : "not square";
        }
    }
}
