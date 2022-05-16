using EntityFrameworkCoreSamples.Data;
using EntityFrameworkCoreSamples.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace EntityFrameworkCoreSamples
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("EntityFrameworkCore Samples!");
      Console.WriteLine($"Start performancetests (approximately 15 minutes)");
      Stopwatch sw = new Stopwatch();
      sw.Reset();
      sw.Start();

      ProductGetCount(100);                                 // 0,095 s (949017 Ticks)
      ProductGets(1);                                       // 60,23 s (602324955 Ticks)
      ProductWithoutModInfoGets(100);                       // 6,322 s (63220279 Ticks)
      ProductInStockGets(100);                              // 0,179 s (1790783 Ticks)
      ProductInStockHardCodedGets(100);                     // 0,019 s (191280 Ticks)

      ProductsFromTableByInClauseGets(100);                 // 1,1 ms (10895 Ticks)
      //ProductsFromTableByInClauseHardCodedGets(100);      // Test nicht möglich!
      //SpecialProductsGets(100);                           // Test nicht möglich!
      //SpecialProductsHardCodedGets();                     // Test nicht möglich!

      sw.Stop();
      TimeSpan ts = new TimeSpan(sw.ElapsedTicks);
      Console.WriteLine($"Finish performancetests after {ts.ToString(@"mm\:ss")}");
      Console.ReadLine();
    }

    private static void ProductGetCount(int count)
    {
      RunTest(nameof(ProductGetCount), count, () =>
      {
        using (var db = new WorkshopTestProjectDbContext())
        {
          return db.Products.LongCount();
        }
      });
    }
    private static void ProductGets(int count)
    {
      RunTest(nameof(ProductGets), count, () =>
      {
        using (var db = new WorkshopTestProjectDbContext())
        {
          return db.Products
            .Select(p => new ProductWithInfo
            {
              Id = p.Id,
              ModifiedDate = p.ModifiedDate,
              ModifiedUser = p.ModifiedUser,

              ModifiedInformation = WorkshopTestProjectDbContext.GetInsertUpdateDeleteInformation(p.ModifiedUser, p.ModifiedDate),
              ProductName = p.ProductName,
              Price = p.Price
            }).ToList();
        }
      });
    }
    private static void ProductWithoutModInfoGets(int count)
    {
      RunTest(nameof(ProductWithoutModInfoGets), count, () =>
      {
        using (var db = new WorkshopTestProjectDbContext())
        {
          return db.Products.ToList();
        }
      });
    }
    private static void ProductInStockGets(int count)
    {
      RunTest(nameof(ProductInStockGets), count, () =>
      {
        var parameters = new { productId = 4 };
        using (var db = new WorkshopTestProjectDbContext())
        {
          return db.ProductInStock(parameters.productId).ToList();
        }
      });
    }
    private static void ProductInStockHardCodedGets(int count)
    {
      RunTest(nameof(ProductInStockHardCodedGets), count, () =>
      {
        using (var db = new WorkshopTestProjectDbContext())
        {
          return db.Stocks
            .Include(s => s.Product)
            .Where(s => s.ProductId == 4)
            .Select(s => new ProductsInStock
            {
              Id = s.ProductId,
              Price = s.Product.Price,
              ProductName = s.Product.ProductName,
              Quantity = s.Quantity
            }).ToList();
        }
      });
    }

    private static void ProductsFromTableByInClauseGets(int count)
    {
      RunTest(nameof(ProductsFromTableByInClauseGets), count, () =>
      {
        long[] productIds = { -1, 0, 1, 4, 8, 1000001, 1000002 };
        using (var db = new WorkshopTestProjectDbContext())
        {
          return db.Products
            .Where(p => productIds.Contains(p.Id))
            .Select(p => new SpecialProduct
            {
              Id = p.Id,
              Price = p.Price,
              ProductName = p.ProductName
            }).ToList();
        }
      });
    }

    private static void RunTest<T>(string name, int count, Func<T> testmethod, Func<T, bool> resultValidation = null)
    {
      T result = default(T);
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest {name} running");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        result= testmethod();
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
        if (resultValidation != null)
        {
          if (!resultValidation(result))
          {
            Console.WriteLine($"Performancetest {name} Run {i} failed");
          }
        }
      }
      elapsedTicks /= count;

      ConsoleOutput(elapsedTicks, $"Performancetest {name}");
    }
    private static void ConsoleOutput(long elapsedTicks, string task)
    {
      Console.WriteLine($"Elapsed time for {task}:");
      Console.WriteLine($"  - {elapsedTicks} ticks");
      Console.WriteLine($"  - {elapsedTicks / 10000} ms");
      Console.WriteLine($"  - {Math.Round(((double)elapsedTicks / 10000000), 2)} s");
    }
  }
}