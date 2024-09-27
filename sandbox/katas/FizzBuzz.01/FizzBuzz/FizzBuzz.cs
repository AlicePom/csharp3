using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
- Instead of numbers with a three in them, print "Fizz".
- Instead of numbers with a five in them, print "Buzz".
- Instead of numbers with a three and a five in them, print "FizzBuzz".
*/
public class FizzBuzz
{
    public void CountTo(int lastNumber)
    {
        for (int currentNumber = 1; currentNumber <= lastNumber; currentNumber++)
        {
            string currentNumberString = currentNumber.ToString();
            bool divisibleBy3 = currentNumber % 3 == 0;
            bool divisibleBy5 = currentNumber % 5 == 0;
            bool contains3 = currentNumberString.Contains('3');
            bool contains5 = currentNumberString.Contains('5');

            // original solution
            // if ((divisibleBy3 && divisibleBy5) || (contains3 && contains5))
            // {
            //     Console.WriteLine("FizzBuzz");
            //     continue;
            // }

            // improved solution (e.g. no 51 is divisible by 3 but contains '5' => FizzBuzz)
            if ((divisibleBy3 && divisibleBy5) || (contains3 && contains5) || (divisibleBy3 && contains5) || (divisibleBy5 && contains3))
            {
                Console.WriteLine("FizzBuzz");
                continue;
            }

            if (divisibleBy3 || contains3)
            {
                Console.WriteLine("Fizz");
                continue;
            }

            if (divisibleBy5 || contains5)
            {
                Console.WriteLine("Buzz");
                continue;
            }

            Console.WriteLine(currentNumber);
        }
    }
}
