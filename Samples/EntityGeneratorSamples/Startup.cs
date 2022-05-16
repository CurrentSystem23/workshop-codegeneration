using Microsoft.Extensions.DependencyInjection;
using WorkshopTestProject.DataAccess;
using WorkshopTestProject.DataAccess.SQL.core;

namespace EntityGeneratorSamples
{
  internal class Startup
  {
    public Startup()
    { }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddTransient<CountryDao>();
      services.AddTransient<CurrencyDao>();
      services.AddTransient<DomainTypeDao>();
      services.AddTransient<DomainValueDao>();
      services.AddTransient<ProductDao>();
      services.AddTransient<ProductInStockDaoV>();
      services.AddTransient<ProductsInStockDaoV>();
      services.AddTransient<SpecialProductsDaoV>();
      services.AddTransient<StockDao>();
      services.AddTransient<TenantDao>();
      services.AddTransient<UserDao>();
      services.AddTransient<UserGroupDao>();
      services.AddTransient<UserRightDao>();
      services.AddTransient<UserRightsRoleDao>();

      services.AddTransient<DataAccess>();
    }
  }
}
