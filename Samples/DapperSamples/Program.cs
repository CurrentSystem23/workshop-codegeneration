using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Diagnostics;

namespace DapperSamples
{
  internal class Program
  {
    private static string connectionString = @"Server=LOCALHOST\LOCALDB; Database=WorkshopTestProjectDb; Trusted_Connection=True; TrustServerCertificate=True";
    //private static string connectionString = @"Server=(localdb)\MSSQLLocalDB; Database=WorkshopTestProjectDb; Trusted_Connection=True;";
    static void Main(string[] args)
    {
      Console.WriteLine("Dapper Samples!");
      Console.WriteLine($"Start performancetests (approximately 15 minutes)");
      Stopwatch sw = new Stopwatch();
      sw.Reset();
      sw.Start();

      ProductGetCount(100);                          // 0,07 s
      ProductGets(1);                                // 50,0 s
      ProductWithoutModInfoGets(100);                // 1,40 s
      ProductInStockGets(100);                       // 0,14 s
      ProductInStockHardCodedGets(100);              // 0,02 s
      ProductsFromTableByInClauseGets(100);          // 0,01 s
      ProductsFromTableByInClauseHardCodedGets(100); // 0,01 s
      SpecialProductsGets(100);                      // 3,74 s
      //SpecialProductsHardCodedGets();              // Test nicht möglich, da eine HardCoded Unterstützung hier fehlt!

      sw.Stop();
      TimeSpan ts = new TimeSpan(sw.ElapsedTicks);
      Console.WriteLine($"Finish performancetests after {ts.ToString(@"mm\:ss")}");
      Console.ReadLine();
    }

    private static void ProductGetCount(int count)
    {
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductGetCount");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        using (IDbConnection db = new SqlConnection(connectionString))
        {
          var result = db.Query<long>("Select Count(*) From core.Product").AsList();
        }
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductGetCount");
    }
    private static void ProductGets(int count)
    {
      List<ProductDto> products;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductGets");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        using (IDbConnection db = new SqlConnection(connectionString))
        {
          products = db.Query<ProductDto>(@$"
       SELECT [core].[GetInsertUpdateDeleteInformation](pt.[ModifiedUser], pt.[ModifiedDate]) AS ModifiedInformation
              ,pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[ProductName]
              ,pt.[Price]
          FROM [core].[Product] AS pt
").AsList();
        }
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductGets");
    }
    private static void ProductWithoutModInfoGets(int count)
    {
      List<ProductDto> products;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductWithoutModInfoGets");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        using (IDbConnection db = new SqlConnection(connectionString))
        {
          products = db.Query<ProductDto>(@$"
        SELECT pt.[Id]
              ,pt.[ModifiedDate]
              ,pt.[ModifiedUser]
              ,pt.[ProductName]
              ,pt.[Price]
          FROM [core].[Product] AS pt
").AsList();
        }
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductWithoutModInfoGets");
    }
    private static void ProductInStockGets(int count)
    {
      List<ProductInStockDtoV> products;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductInStockGets");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        var parameters = new { productId = 4 };
        using (IDbConnection db = new SqlConnection(connectionString))
        {
          products = db.Query<ProductInStockDtoV>(@$"
        SELECT 
               pv.[Id]
              ,pv.[ProductName]
              ,pv.[Price]
              ,pv.[Quantity]
          FROM [core].[ProductInStock](@productId) pv
", parameters).AsList();
        }
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductInStockGets");
    }
    private static void ProductInStockHardCodedGets(int count)
    {
      List<ProductInStockDtoV> products;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductInStockHardCodedGets");
      long elapsedTicks = 0;
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        using (IDbConnection db = new SqlConnection(connectionString))
        {
          products = db.Query<ProductInStockDtoV>(@$"
        SELECT 
               pv.[Id]
              ,pv.[ProductName]
              ,pv.[Price]
              ,pv.[Quantity]
          FROM [core].[ProductInStock]({4}) pv
").AsList();
        }
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductInStockHardCodedGets");
    }

    private static void ProductsFromTableByInClauseGets(int count)
    {
      ICollection<SpecialProductsDtoV> specialProducts;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductsFromTableByInClauseGets");
      long elapsedTicks = 0;
      long[] productIds = { -1, 0, 1, 4, 8, 1000001, 1000002 };
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        using (IDbConnection db = new SqlConnection(connectionString))
        {
          specialProducts = db.Query<SpecialProductsDtoV>(@$"
        SELECT [Id]
              ,[ProductName]
              ,[Price]
          FROM [core].[Product]
         WHERE [Id] IN @productIds
", new { productIds = new long[] { -1, 0, 1, 4, 8, 1000001, 1000002 } }).AsList();
        }
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductsFromTableByInClauseGets");
    }
    private static void ProductsFromTableByInClauseHardCodedGets(int count)
    {
      ICollection<SpecialProductsDtoV> specialProducts;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest ProductsFromTableByInClauseHardCodedGets");
      long elapsedTicks = 0;
      long[] productIds = { -1, 0, 1, 4, 8, 1000001, 1000002 };
      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        using (IDbConnection db = new SqlConnection(connectionString))
        {
          specialProducts = db.Query<SpecialProductsDtoV>(@$"
        SELECT [Id]
              ,[ProductName]
              ,[Price]
          FROM [core].[Product]
         WHERE [Id] IN ({String.Join(", ", productIds)})
").AsList();
        }
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest ProductsFromTableByInClauseHardCodedGets");
    }
    private static void SpecialProductsGets(int count)
    {
      ICollection<SpecialProductsDtoV> specialProducts;
      Stopwatch sw = new Stopwatch();
      Console.WriteLine($"Performancetest SpecialProductsGets");
      long elapsedTicks = 0;
      DataTable dt = new DataTable();
      dt.Columns.Add("Id");
      dt.Rows.Add(-1);
      dt.Rows.Add(0);
      dt.Rows.Add(1);
      dt.Rows.Add(4);
      dt.Rows.Add(8);
      dt.Rows.Add(1000001);
      dt.Rows.Add(1000002);

      for (int i = 1; i <= count; i++)
      {
        sw.Reset();
        sw.Start();
        using (IDbConnection db = new SqlConnection(connectionString))
        {
          specialProducts = db.Query<SpecialProductsDtoV>(@$"
        SELECT [Id]
              ,[ProductName]
              ,[Price]
          FROM [core].[SpecialProducts](@productIds)
", new { productIds = dt.AsTableValuedParameter("[core].[BigintArray]") }).AsList();
        }
        sw.Stop();
        elapsedTicks += sw.ElapsedTicks;
      }
      elapsedTicks = elapsedTicks / count;

      ConsoleOutput(elapsedTicks, "Performancetest SpecialProductsGets");
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
