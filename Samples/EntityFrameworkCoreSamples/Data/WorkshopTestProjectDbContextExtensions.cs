using EntityFrameworkCoreSamples.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkCoreSamples.Data
{
  public partial class WorkshopTestProjectDbContext
  {
    [DbFunction("GetInsertUpdateDeleteInformation", "core")]
    public static string GetInsertUpdateDeleteInformation(long modifiedUserId, DateTime modifiedDateTime)
      => throw new InvalidOperationException();

    [DbFunction("ProductInStock", "core")]
    public virtual IQueryable<ProductsInStock> ProductInStock(long productId)
      => FromExpression(() => ProductInStock(productId));

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {

    }
  }
}
