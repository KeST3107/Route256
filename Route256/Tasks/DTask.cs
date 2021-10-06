namespace Route256
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DTask
    {
        public static string Run(string input)
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
    }
}
