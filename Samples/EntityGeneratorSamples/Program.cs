using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core;
using WorkshopTestProject.Common.DTOs.core;
using WorkshopTestProject.DataAccess.SQL.core;

namespace EntityGeneratorSamples
{
  internal class Program
  {
    static void Main(string[] args)
    {
      IServiceCollection services = new ServiceCollection();
      Startup startup = new Startup();
      startup.ConfigureServices(services);
      IServiceProvider serviceProvider = services.BuildServiceProvider();

      Console.WriteLine("EntityGenerator Samples!");
      WorkshopTestProject.Common.DatabaseConnection.ConnectionString = @"Server=LOCALHOST\LOCALDB; Database=WorkshopTestProjectDb; Trusted_Connection=True; TrustServerCertificate=True";
      //WorkshopTestProject.Common.DatabaseConnection.ConnectionString = @"Server=(localdb)\MSSQLLocalDB; Database=WorkshopTestProjectDb; Trusted_Connection=True;";
      DummyRequest(serviceProvider);

      Console.WriteLine($"Start performancetests (approximately 15 minutes)");
      Stopwatch sw = new Stopwatch();
      sw.Reset();
      sw.Start();

      ProductGetCount(serviceProvider, 100);               // 0,05 s (543571 Ticks)
      ProductGets(serviceProvider, 1);                     // 50,0 s
      ProductWithoutModInfoGets(serviceProvider, 100);     // 0,92 s
      ProductInStockGets(serviceProvider, 100);            // 0,14 s
      ProductInStockHardCodedGets(serviceProvider, 100);   // 0,01 s

      ProductInGets(serviceProvider, 100);                 // > 1 ms
      ProductInHardCodedGets(serviceProvider, 100);        // > 1 ms
      SpecialProductsGets(serviceProvider, 100);           // 3,53 s
      SpecialProductsHardCodedGets(serviceProvider, 100);  // 3,08 s

      sw.Stop();
      TimeSpan ts = new TimeSpan(sw.ElapsedTicks);
      Console.WriteLine($"Finish performancetests after {ts.ToString(@"mm\:ss")}");
      Console.ReadLine();
    }
    private static void DummyRequest(IServiceProvider serviceProvider)
    {
      ProductDao productDao = serviceProvider.GetRequiredService<ProductDao>();
      long productCount = productDao.ProductGetCount();
    }

    private static void ProductGetCount(IServiceProvider serviceProvider, int count)
    {
      ProductDao productDao = serviceProvider.GetRequiredService<ProductDao>();

      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductGetCount");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        long productCount = productDao.ProductGetCount();
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductGetCount");
    }
    private static void ProductGets(IServiceProvider serviceProvider, int count)
    {
      ProductDao productDao = serviceProvider.GetRequiredService<ProductDao>();

      ICollection<IProductDto> products;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductGets");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        products = productDao.ProductGets();
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductGets");
    }
    private static void ProductWithoutModInfoGets(IServiceProvider serviceProvider, int count)
    {
      ProductDao productDao = serviceProvider.GetRequiredService<ProductDao>();

      ICollection<IProductDto> products;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductWithoutModInfoGets");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        products = productDao.ProductWithoutModInfoGets();
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductWithoutModInfoGets");
    }

    private static void ProductInStockGets(IServiceProvider serviceProvider, int count)
    {
      ProductInStockDaoV productInStockDaoV = serviceProvider.GetRequiredService<ProductInStockDaoV>();

      WhereClause whereClause = new WhereClause("");
      ICollection<IProductInStockDtoV> productsInStock;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductInStockGets");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        productsInStock = productInStockDaoV.ProductInStockGets(whereClause, false, 4);
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductInStockGets");
    }
    private static void ProductInStockHardCodedGets(IServiceProvider serviceProvider, int count)
    {
      ProductInStockDaoV productInStockDaoV = serviceProvider.GetRequiredService<ProductInStockDaoV>();

      WhereClause whereClause = new WhereClause("");
      ICollection<IProductInStockDtoV> productsInStock;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductInStockHardCodedGets");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        productsInStock = productInStockDaoV.ProductInStockHardCodedGets(whereClause, false, 4);
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductInStockHardCodedGets");
    }

    private static void ProductInGets(IServiceProvider serviceProvider, int count)
    {
      ProductDao productDao = serviceProvider.GetRequiredService<ProductDao>();

      ICollection<IProductDto> products;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductInGets");
      long elapsedTicks = 0;
      List<long> productIds = new List<long> { -1, 0, 1, 4, 8, 1000001, 1000002 };
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        products = productDao.ProductWithoutModInfoHardCodedGets(productIds);
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductInGets");
    }
    private static void ProductInHardCodedGets(IServiceProvider serviceProvider, int count)
    {
      ProductDao productDao = serviceProvider.GetRequiredService<ProductDao>();

      ICollection<IProductDto> products;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductInHardCodedGets");
      long elapsedTicks = 0;
      List<long> productIds = new List<long> { -1, 0, 1, 4, 8, 1000001, 1000002 };
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        products = productDao.ProductWithoutModInfoHardCodedGets(productIds);
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductInHardCodedGets");
    }

    private static void SpecialProductsGets(IServiceProvider serviceProvider, int count)
    {
      SpecialProductsDaoV specialProductsDaoV = serviceProvider.GetRequiredService<SpecialProductsDaoV>();

      WhereClause whereClause = new WhereClause("");
      ICollection<ISpecialProductsDtoV> specialProducts;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest SpecialProductsGets");
      long elapsedTicks = 0;
      long[] productIds = { -1, 0, 1, 4, 8, 1000001, 1000002 };
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        specialProducts = specialProductsDaoV.SpecialProductsGets(productIds);
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest SpecialProductsGets");
    }
    private static void SpecialProductsHardCodedGets(IServiceProvider serviceProvider, int count)
    {
      SpecialProductsDaoV specialProductsDaoV = serviceProvider.GetRequiredService<SpecialProductsDaoV>();

      WhereClause whereClause = new WhereClause("");
      ICollection<ISpecialProductsDtoV> specialProducts;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest SpecialProductsHardCodedGets");
      long elapsedTicks = 0;
      long[] productIds = { -1, 0, 1, 4, 8, 1000001, 1000002 };
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        specialProducts = specialProductsDaoV.SpecialProductsHardCodedGets(productIds);
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest SpecialProductsHardCodedGets");
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
