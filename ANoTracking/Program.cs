﻿using BenchmarkDotNet.Running;

namespace ANoTracking
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
