using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator_Library
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int sum = 0;
            List<char> defaultDelimiters = new List<char>();
            defaultDelimiters.Add(',');
            defaultDelimiters.Add('\n');

            if (!String.IsNullOrEmpty(numbers))
            {
                if (numbers.StartsWith("//"))
                {
                    char customDelimiter = numbers.Substring(2, 2).ToCharArray()[0];

                    defaultDelimiters.Add(customDelimiter);
                    numbers = numbers.Substring(3);
                }

                var numberArray = numbers.Split(defaultDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                foreach (int num in numberArray)
                {
                    sum += num;
                }
            }

            return sum;
        }
    }
}
