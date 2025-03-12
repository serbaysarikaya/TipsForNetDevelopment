using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANoTracking;

public class BenchmarkService
{
    [ShortRunJob, Config(typeof(Config))]
    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(BenchmarkDotNet.Columns.RatioStyle.Value);
        }
    }



    //[Benchmark(Baseline = true)]
    //public void GetAllWithTracking()
    //{
    //    AppDbContext context = new();

    //    context.Products.ToList();
    //}

    //[Benchmark]
    //public void GetAllWithAsNoTracking()
    //{
    //    AppDbContext context = new();

    //    context.Products.AsNoTracking().ToList();
    //}

    //[Benchmark(Baseline =true)]
    //public void GetFirstWithTracking()
    //{
    //    AppDbContext context = new();
    //    context.Products.First();
    //}
    //[Benchmark]
    //public void GetFirstWithAsNoTracking()
    //{
    //    AppDbContext context = new();
    //    context.Products.AsNoTracking().First();
    //}

}
