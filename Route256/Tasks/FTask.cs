namespace Route256
{
    using System.Collections.Generic;

    public static class FTask
    {
        public static string Run(string input)
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
