using Microsoft.Extensions.DependencyInjection;
using WorkshopTestProject.DataAccess.SQL.core;

namespace WorkshopTestProject.DataAccess.SQL.Helper
{
  public partial class DataAccessAdoInitializer
  {
    private void InitializeGenerated(IServiceCollection services)
    {
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.ICountryDao, WorkshopTestProject.DataAccess.SQL.core.CountryDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.ICountryInternalDao, WorkshopTestProject.DataAccess.SQL.core.CountryDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.ICurrencyDao, WorkshopTestProject.DataAccess.SQL.core.CurrencyDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.ICurrencyInternalDao, WorkshopTestProject.DataAccess.SQL.core.CurrencyDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IDomainTypeDao, WorkshopTestProject.DataAccess.SQL.core.DomainTypeDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IDomainTypeInternalDao, WorkshopTestProject.DataAccess.SQL.core.DomainTypeDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IDomainValueDao, WorkshopTestProject.DataAccess.SQL.core.DomainValueDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IDomainValueInternalDao, WorkshopTestProject.DataAccess.SQL.core.DomainValueDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IProductDao, WorkshopTestProject.DataAccess.SQL.core.ProductDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IProductInternalDao, WorkshopTestProject.DataAccess.SQL.core.ProductDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IProductInStockDaoV, WorkshopTestProject.DataAccess.SQL.core.ProductInStockDaoV>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IProductInStockInternalDaoV, WorkshopTestProject.DataAccess.SQL.core.ProductInStockDaoV>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IProductsInStockDaoV, WorkshopTestProject.DataAccess.SQL.core.ProductsInStockDaoV>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IProductsInStockInternalDaoV, WorkshopTestProject.DataAccess.SQL.core.ProductsInStockDaoV>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.ISpecialProductsDaoV, WorkshopTestProject.DataAccess.SQL.core.SpecialProductsDaoV>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.ISpecialProductsInternalDaoV, WorkshopTestProject.DataAccess.SQL.core.SpecialProductsDaoV>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IStockDao, WorkshopTestProject.DataAccess.SQL.core.StockDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IStockInternalDao, WorkshopTestProject.DataAccess.SQL.core.StockDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.ITenantDao, WorkshopTestProject.DataAccess.SQL.core.TenantDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.ITenantInternalDao, WorkshopTestProject.DataAccess.SQL.core.TenantDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IUserDao, WorkshopTestProject.DataAccess.SQL.core.UserDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IUserInternalDao, WorkshopTestProject.DataAccess.SQL.core.UserDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IUserGroupDao, WorkshopTestProject.DataAccess.SQL.core.UserGroupDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IUserGroupInternalDao, WorkshopTestProject.DataAccess.SQL.core.UserGroupDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IUserRightDao, WorkshopTestProject.DataAccess.SQL.core.UserRightDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IUserRightInternalDao, WorkshopTestProject.DataAccess.SQL.core.UserRightDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleDao, WorkshopTestProject.DataAccess.SQL.core.UserRightsRoleDao>();
      services.AddTransient<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IUserRightsRoleInternalDao, WorkshopTestProject.DataAccess.SQL.core.UserRightsRoleDao>();
    }
  }
}


