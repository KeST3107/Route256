namespace Route256
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class BTask
    {
        public static string Run(string input)
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
    }
}
