namespace Route256
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class TaskList
    {
        public static string ATask(string input)
        {
            var str = input;
            var result = string.Join(" ", str.Split(' ')
                .Select(x =>
                    string.Concat(
                        x.Length >= 1 ? x.Substring(0, 1).ToUpper() : "",
                        x.Length > 1 ? x.Substring(1, x.Length - 1).ToLower() : "")
                ));
            return result;
        }

        public static string BTask(string input)
        {
            var chars = input.ToCharArray();
            var usedChars = new List<Char>();
            var strBuilder = new StringBuilder();
            foreach (var c in chars)
            {
                usedChars.Add(c);
                var count = usedChars.Where(x => x == c).Count();
                strBuilder.Append(count);
            }

            return strBuilder.ToString();
        }

        public static string CTask(string input)
        {
            var diapasons = input.Split(' ').ToArray();
            var startSplited = diapasons[0].Split('.');
            var endSplitted = diapasons[1].Split('.');
            int sum = 0;
            for (int i = 0; i < endSplitted.Length; i++)
            {
                sum = (sum << 8) + int.Parse(endSplitted[i]) - int.Parse(startSplited[i]);
            }

            return sum.ToString();
        }

        public static string DTask(string input)
        {
            var bills = input.Split(' ').Select(Int32.Parse).ToList();
            var cashBox = new List<int>();
            foreach (var bill in bills)
            {
                if (bill == 1000)
                {
                    cashBox.Add(bill);
                    continue;
                }

                if (bill == 2000)
                {
                    var cnts1000 = cashBox.Where(x => x == 1000).Count();
                    if (cnts1000 == 0)
                    {
                        return "False";
                    }

                    cashBox.Remove(1000);
                    cashBox.Add(bill);
                    continue;
                }

                if (bill == 5000)
                {
                    var cnts1000 = cashBox.Where(x => x == 1000).Count();
                    var cnts2000 = cashBox.Where(x => x == 2000).Count();
                    if (cnts2000 >= 2)
                    {
                        cashBox.Remove(2000);
                        cashBox.Remove(2000);
                        cashBox.Add(bill);
                        continue;
                    }

                    if (cnts2000 >= 1 && cnts1000 >= 2)
                    {
                        cashBox.Remove(2000);
                        cashBox.Remove(1000);
                        cashBox.Remove(1000);
                        cashBox.Add(bill);
                        continue;
                    }

                    if (cnts1000 >= 4)
                    {
                        cashBox.Remove(1000);
                        cashBox.Remove(1000);
                        cashBox.Remove(1000);
                        cashBox.Remove(1000);
                        cashBox.Add(bill);
                        continue;
                    }

                    return "False";
                }
            }

            return "True";
        }


        public static string ETask(string input)
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

        public static string FTask(string input)
        {
            var strArray = input.Split(' ');
            var logicString = strArray[0];
            var logicVariables = new Dictionary<char, bool>();
            for (int i = 1; i < strArray.Length; i += 2)
            {
                var key = char.Parse(strArray[i]);
                var value = bool.Parse(strArray[i + 1]);
                logicVariables.Add(key, value);
            }
            while (logicString.Contains('!'))
            {
                var index = logicString.IndexOf('!');
                var key = logicString[index + 1];
                bool value;
                if (key == '1') value = true;
                else if (key == '0') value = false;
                else value = logicVariables[key];
                value = LogicNot(value);
                var i = value ? 1 : 0;
                var c = i.ToString();
                logicString = logicString.Remove(index, 2).Insert(index, c);
            }

            while (logicString.Contains('&'))
            {
                var index = logicString.IndexOf('&');
                var leftKey = logicString[index - 1];
                var rightKey = logicString[index + 1];
                bool leftValue;
                if (leftKey == '1') leftValue = true;
                else if (leftKey == '0') leftValue = false;
                else leftValue = logicVariables[leftKey];
                bool rightValue;
                if (rightKey == '1') rightValue = true;
                else if (rightKey == '0') rightValue = false;
                else rightValue = logicVariables[rightKey];
                leftValue = LogicAnd(leftValue, rightValue);
                var i = leftValue ? 1 : 0;
                var c = i.ToString();
                logicString = logicString.Remove(index - 1, 3).Insert(index - 1, c);
            }

            while (logicString.Contains('|'))
            {
                var index = logicString.IndexOf('|');
                var leftKey = logicString[index - 1];
                var rightKey = logicString[index + 1];
                bool leftValue;
                if (leftKey == '1') leftValue = true;
                else if (leftKey == '0') leftValue = false;
                else leftValue = logicVariables[leftKey];
                bool rightValue;
                if (rightKey == '1') rightValue = true;
                else if (rightKey == '0') rightValue = false;
                else rightValue = logicVariables[rightKey];
                leftValue = LogicOr(leftValue, rightValue);
                var i = leftValue ? 1 : 0;
                var c = i.ToString();
                logicString = logicString.Remove(index - 1, 3).Insert(index - 1, c);
            }

            while (logicString.Contains('='))
            {
                var index = logicString.IndexOf('=');
                var leftKey = logicString[index - 1];
                var rightKey = logicString[index + 1];
                bool leftValue;
                if (leftKey == '1') leftValue = true;
                else if (leftKey == '0') leftValue = false;
                else leftValue = logicVariables[leftKey];
                bool rightValue;
                if (rightKey == '1') rightValue = true;
                else if (rightKey == '0') rightValue = false;
                else rightValue = logicVariables[rightKey];
                leftValue = LogicEqual(leftValue, rightValue);
                var i = leftValue ? 1 : 0;
                var c = i.ToString();
                logicString = logicString.Remove(index - 1, 3).Insert(index - 1, c);
            }

            if (int.Parse(logicString) == 1) return "True";
            if (int.Parse(logicString) == 0) return "False";
            return "False";
        }
        private static bool LogicAnd(bool left, bool right)
        {
            if (left && right)
            {
                return true;
            }
            else return false;
        }

        private static bool LogicOr(bool left, bool right)
        {
            if (left || right)
            {
                return true;
            }
            else return false;
        }

        private static bool LogicEqual(bool left, bool right)
        {
            if (left == right)
            {
                return true;
            }
            else return false;
        }

        private static bool LogicNot(bool value)
        {
            if (!value)
            {
                return true;
            }
            else return false;
        }
    }
}
