namespace Route256
{
    using System.Linq;

    public static class CTask
    {
        public static string Run(string input)
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
    }
}
