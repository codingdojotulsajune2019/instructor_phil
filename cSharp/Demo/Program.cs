using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            System.Console.WriteLine();
            int x = 10;
            int y = 20;
            Console.WriteLine($"x is: {x}, and y is: {y}, with a sum of: {AddNum(x, y)}");
        }

        static int AddNum(int x, int y)
        {
            return x+y;
        }
    }
}
