using BenchmarkDotNet.Running;

namespace BenchMark.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            BenchmarkRunner.Run<BenchmarkService>();
        }
    }
}
