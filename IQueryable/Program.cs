using DataAccess.Context;
using DataAccess.Models;

namespace IQueryable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new();
            IQueryable<Product> products = context.Products.AsQueryable();

            IList<Product> productList = products.Where(p => p.Id > 4999 && p.Id<6000).ToList();

            Console.WriteLine("Hello, World!");
        }
    }
}
