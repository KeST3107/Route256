namespace Route256
{
    using System.Collections.Generic;

    public static class ETask
    {
        public static string Run(string input)
        {
            var str = input;
            var romeNumber = str.Split(" ");
            var firstRomeNumber = RomanToArabic(romeNumber[0]);
            var secondRomeNumber = RomanToArabic(romeNumber[1]);
            string result;
            if (firstRomeNumber < secondRomeNumber)
                result = "-1";
            else if (firstRomeNumber > secondRomeNumber)
                result = "1";
            else
                result = "0";

            return result;
        }

        private static int RomanToArabic(string roman)
        {
            var charValues = new Dictionary<char, int>();
            charValues.Add('I', 1);
            charValues.Add('V', 5);
            charValues.Add('X', 10);
            charValues.Add('L', 50);
            charValues.Add('C', 100);
            charValues.Add('D', 500);
            charValues.Add('M', 1000);

            if (roman.Length == 0) return 0;
            roman = roman.ToUpper();

            if (roman[0] == '(')
            {
                int pos = roman.LastIndexOf(')');
                string part1 = roman.Substring(1, pos - 1);
                string part2 = roman.Substring(pos + 1);
                return 1000 * RomanToArabic(part1) + RomanToArabic(part2);
            }

            int total = 0;
            int lastValue = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                int newValue = charValues[roman[i]];

                if (newValue < lastValue)
                    total -= newValue;
                else
                {
                    total += newValue;
                    lastValue = newValue;
                }
            }

            return total;
        }
    }
}
