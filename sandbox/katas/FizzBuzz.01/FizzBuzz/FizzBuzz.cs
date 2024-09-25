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

            if ((currentNumber % 3 == 0 && currentNumber % 5 == 0) || (currentNumberString.Contains('3') && currentNumberString.Contains('5')))
            {
                Console.WriteLine("FizzBuzz");
                continue;
            }

            if (currentNumber % 3 == 0 || currentNumberString.Contains('3'))
            {
                Console.WriteLine("Fizz");
                continue;
            }

            if (currentNumber % 5 == 0 || currentNumberString.Contains('5'))
            {
                Console.WriteLine("Buzz");
                continue;
            }

            Console.WriteLine(currentNumber);
        }
    }
}
