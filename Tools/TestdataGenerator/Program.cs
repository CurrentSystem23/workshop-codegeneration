using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using Microsoft.Data.SqlClient;

namespace TestdataGenerator
{
  internal class Program
  {
    //private static string connectionString = @"Server=(localdb)\MSSQLLocalDB; Database=WorkshopTestProjectDb; Trusted_Connection=True;";
    private static string connectionString = @"Server=LOCALHOST\LOCALDB; Database=WorkshopTestProjectDb; Trusted_Connection=True; TrustServerCertificate=True";
    static void Main(string[] args)
    {
      Stopwatch swStopwatch = new Stopwatch();
      swStopwatch.Start();

      #region Write to File Products
      //Console.WriteLine($"{DateTime.Now} Start generate Product Data");
      //using StreamWriter sw = new StreamWriter("Products.csv");
      //Random rnd = new Random();
      //for (int i = 1; i <= 1000000; i++)
      //{
      //  ProductDto product = new ProductDto()
      //  {
      //    Id = -1,
      //    ModifiedDate = DateTime.UtcNow,
      //    ModifiedUser = 1,
      //    ProductName = $"Product {i}",
      //    Price = Math.Round((rnd.NextDouble() * 1000), 2)
      //  };
      //  string price = product.Price.ToString().Replace(",", ".");
      //  sw.WriteLine(@$"{i}, ""{product.ProductName}"", {price}");
      //  if (i % 1000 == 0)
      //    Console.WriteLine($"Product {product.ProductName} with price {price} is created");
      //}
      //sw.Close();
      #endregion

      #region Write to File Stocks
      //Console.WriteLine($"{DateTime.Now} Start generate Stock Data");
      //using StreamWriter sw = new StreamWriter("Stocks.csv");
      //Random rnd = new Random();
      //for (int j = 1; j <= 250000; j++)
      //{
      //  StockDto stock = new StockDto()
      //  {
      //    Id = -1,
      //    ModifiedDate = DateTime.UtcNow,
      //    ModifiedUser = 1,
      //    ProductId = j * 4,
      //    Quantity = rnd.Next(0, 10)
      //  };
      //  sw.WriteLine(@$"{j}, {stock.ProductId}, {stock.Quantity}");
      //  if (j % 1000 == 0)
      //    Console.WriteLine($"Product {stock.ProductId} with quantity {stock.Quantity} is created");
      //}
      //sw.Close();
      #endregion

      #region ReadFrom csv Products
      Console.WriteLine($"{DateTime.Now} Start read product data");
      int i = 1;
      using StreamReader streamReader = File.OpenText("Products.csv");
      using (SqlConnection con = new SqlConnection(connectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          string value = streamReader.ReadLine();
          con.Open();
          cmd.CommandText = "DISABLE TRIGGER [core].[Product_HistTrigger] ON [core].[Product]";
          cmd.ExecuteNonQuery();

          while (value != null)
          {
            string[] fields = value.Split(',');
            ProductDto product = new ProductDto()
            {
              Id = Convert.ToInt64(fields[0]),
              ModifiedDate = new DateTime(2021, 11, 19),
              ModifiedUser = 1,
              ProductName = fields[1],
              Price = Convert.ToDouble(fields[2].Replace(".", ","))
            };
            if (i % 1000 == 0)
              Console.WriteLine($"Product {product.ProductName} with price {product.Price} is created");
            ProductMerge(cmd, product);

            value = streamReader.ReadLine();
            i++;
          }

          streamReader.Close();
          cmd.CommandText = "ENABLE TRIGGER [core].[Product_HistTrigger] ON [core].[Product]";
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
      Console.WriteLine($"{DateTime.Now} Product data reading has ended");
      #endregion

      #region ReadFrom csv Stocks
      Console.WriteLine($"{DateTime.Now} Start read stock data");
      int j = 1;
      using StreamReader streamReader2 = File.OpenText("Stocks.csv");
      using (SqlConnection con = new SqlConnection(connectionString))
      {
        using (SqlCommand cmd = con.CreateCommand())
        {
          string value = streamReader2.ReadLine();
          con.Open();
          cmd.CommandText = "DISABLE TRIGGER [core].[Stock_HistTrigger] ON [core].[Stock]";
          cmd.ExecuteNonQuery();

          while (value != null)
          {
            string[] fields = value.Split(',');
            StockDto stock = new StockDto()
            {
              Id = Convert.ToInt64(fields[0]),
              ModifiedDate = new DateTime(2021, 11, 19),
              ModifiedUser = 1,
              ProductId = Convert.ToInt64(fields[1]),
              Quantity = Convert.ToInt64(fields[2])
            };
            if (j % 1000 == 0)
              Console.WriteLine($"Stock {stock.Id} for product {stock.ProductId} with quantity {stock.Quantity} is created");
            StockMerge(cmd, stock);

            value = streamReader2.ReadLine();
            j++;
          }

          streamReader2.Close();
          cmd.CommandText = "ENABLE TRIGGER [core].[Stock_HistTrigger] ON [core].[Stock]";
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }

      Console.WriteLine($"{DateTime.Now} Stocks data reading has ended");
      #endregion
    }
    public static void ProductMerge(SqlCommand cmd, ProductDto dto)
    {
      try
      {
        SavePrepareCommand(cmd, dto);
        cmd.CommandText = MergeProductSqlStatement();
        cmd.ExecuteNonQuery();

      }
      catch (Exception)
      {
        throw;
      }
    }
    private static void SavePrepareCommand(SqlCommand cmd, ProductDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value = dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value = dto.ModifiedUser;
      cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = dto.ProductName ?? string.Empty;
      cmd.Parameters.Add("@Price", SqlDbType.Float).Value = dto.Price;
      cmd.CommandType = CommandType.Text;
    }
    private static string MergeProductSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[Product] ON;
          MERGE INTO [core].[Product] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @ProductName, @Price)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[ProductName],[Price])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[ProductName]
                  ,[Price]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[ProductName]
                 ,Source.[Price]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[ProductName] = Source.[ProductName]
                ,[Price] = Source.[Price]
          ;
          SET IDENTITY_INSERT [core].[Product] OFF;
      ";
    }

    public static void StockMerge(SqlCommand cmd, StockDto dto)
    {
      try
      {
        SavePrepareCommand(cmd, dto);
        cmd.CommandText = MergeStockSqlStatement();
        cmd.ExecuteNonQuery();
      }
      catch (Exception)
      {
        throw;
      }
    }
    private static void SavePrepareCommand(SqlCommand cmd, StockDto dto)
    {
      cmd.Parameters.Clear();
      cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = dto.Id;
      cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime2).Value = dto.ModifiedDate;
      cmd.Parameters.Add("@ModifiedUser", SqlDbType.BigInt).Value = dto.ModifiedUser;
      cmd.Parameters.Add("@ProductId", SqlDbType.BigInt).Value = dto.ProductId;
      cmd.Parameters.Add("@Quantity", SqlDbType.BigInt).Value = dto.Quantity;
      cmd.CommandType = CommandType.Text;
    }
    private static string MergeStockSqlStatement()
    {
      return @"
          SET IDENTITY_INSERT [core].[Stock] ON;
          MERGE INTO [core].[Stock] AS Target
          USING (VALUES
          (@Id, @ModifiedDate, @ModifiedUser, @ProductId, @Quantity)
          )
          AS Source ( [Id],[ModifiedDate],[ModifiedUser],[ProductId],[Quantity])
          ON Target.Id = Source.Id
          WHEN NOT MATCHED BY TARGET THEN
          INSERT (
                   [Id]
                  ,[ModifiedDate]
                  ,[ModifiedUser]
                  ,[ProductId]
                  ,[Quantity]
                 )
          VALUES (
                  Source.[Id]
                 ,Source.[ModifiedDate]
                 ,Source.[ModifiedUser]
                 ,Source.[ProductId]
                 ,Source.[Quantity]
                 )
          WHEN MATCHED THEN
          UPDATE
             SET [ModifiedDate] = Source.[ModifiedDate]
                ,[ModifiedUser] = Source.[ModifiedUser]
                ,[ProductId] = Source.[ProductId]
                ,[Quantity] = Source.[Quantity]
          ;
          SET IDENTITY_INSERT [core].[Stock] OFF;
      ";
    }


  }
}
