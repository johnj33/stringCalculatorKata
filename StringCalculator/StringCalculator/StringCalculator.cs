using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const string MINUS = "minus";
        private Dictionary<string, double> _stringToNum = new Dictionary<string, double>
        {
            {"zero", 0},
            {"one", 1},
            {"two", 2},
            {"three", 3 },
            {"four", 4 },
            {"five", 5 },
            {"six", 6 },
            {"twelve", 12 },
            {"nineteen", 19 },
            {"twenty", 20 },
            {"thirty", 30 },
            {"seventy", 70 },
            {"hundred", 100 },
            {"thousand", 1000 },
            {"million", 1000000 }
        };

        public double Add(string number1, string number2)
        {

            var intNum1 = ParseNumber(number1);
            var intNum2 = ParseNumber(number2);

            return intNum1 + intNum2;
        }

        private double ParseNumber(string numbersString)
        {
            double result;

            numbersString = numbersString.ToLower();
            numbersString = numbersString.Replace('-', ' ');

            var numbers = ParseString(numbersString);


            for (var i =0; i < numbers.Count; i++)
            {
                if (!(numbers[i] >= 100)) continue;

                numbers[i] = numbers[i]*numbers[i - 1];
                numbers.RemoveAt(i -1);
            }

            return double.TryParse(numbersString, out result) ? result : numbers.Sum();
        }

        private List<double> ParseString(string numbersString)
        {
            var numbers = new List<double>();
            var negativeAll = numbersString.Contains(MINUS);

            foreach (var numberString in numbersString.Split(' '))
            {
                if (!_stringToNum.ContainsKey(numberString)) continue;

                if (!negativeAll)
                    numbers.Add(_stringToNum[numberString]);
                else
                    numbers.Add(_stringToNum[numberString] * -1);
            }

            return numbers;
        }
    }
}