using System;
using static Route256.TaskList;

namespace Route256
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ATask("hEllo world!"));
            Console.WriteLine(BTask("Привет мир!"));
            Console.WriteLine(CTask("10.0.0.0 10.0.0.50"));
            Console.WriteLine(DTask("1000 2000 1000 2000 5000"));
            Console.WriteLine(ETask("MMLXII MMLX"));
            Console.WriteLine(FTask("a&b|c=d&!a a True b False c True d True"));
        }
    }
}
