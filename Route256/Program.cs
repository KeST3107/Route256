using System;


namespace Route256
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ATask.Run("hEllo world!"));
            Console.WriteLine(BTask.Run("01234567890123456789"));
            Console.WriteLine(CTask.Run("10.0.0.0 10.0.0.50"));
            Console.WriteLine(DTask.Run("1000 2000 1000 2000 5000"));
            Console.WriteLine(ETask.Run("MMLXII MMLX"));
            Console.WriteLine(FTask.Run("a&b|c=d&!a=a&b|c=d&!a=a&b|c=d&!a a True b True c True d False"));
        }
    }
}
