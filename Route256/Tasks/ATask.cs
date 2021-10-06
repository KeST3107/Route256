namespace Route256
{
    using System.Linq;

    public static class ATask
    {
        public static string Run(string input)
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
    }
}
