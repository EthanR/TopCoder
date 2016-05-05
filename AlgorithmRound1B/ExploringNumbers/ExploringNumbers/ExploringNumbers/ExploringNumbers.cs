using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploringNumbers
{
    class ExploringNumbers
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(numberOfSteps(input));
        }

        public static int numberOfSteps(int n)
        {
            if (n == 1)
            {
                return -1;
            }

            if (n == 2 || n == 3)
            {
                return 1;
            }

            int vasaLimit = n;

            List<int> vasaSequence = new List<int> { n };
            bool foundPrime = IsPrime(n);
            while (!foundPrime)
            {
                if (vasaSequence.Count >= vasaLimit)
                {
                    return -1;
                }

                if (IsPrime(n))
                {
                    foundPrime = true;
                }
                else
                {
                    int nextElement = GetNextElement(n);
                    vasaSequence.Add(nextElement);
                }

                n = vasaSequence.Last();
            }

            return vasaSequence.Count;
        }

        public static bool IsPrime(int potentialPrime)
        {
            if (potentialPrime == 1)
            {
                return false;
            }

            if (potentialPrime % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i < Math.Sqrt(potentialPrime); i += 2)
            {
                if (potentialPrime % i == 0)
                {
                    return false;                    
                }
            }

            return true;
        }

        public static int GetNextElement(int currentElement)
        {            
            return currentElement.ToString().Sum(character => int.Parse(character.ToString()) * int.Parse(character.ToString()));
        }
    }
}
