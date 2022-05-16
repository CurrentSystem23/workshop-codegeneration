namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado
{
  public partial interface IDataAccess : Ado.core.ICountryDao, Ado.core.ICurrencyDao, Ado.core.IDomainTypeDao, Ado.core.IDomainValueDao, Ado.core.IProductDao, Ado.core.IProductInStockDaoV, Ado.core.IProductsInStockDaoV, Ado.core.ISpecialProductsDaoV, Ado.core.IStockDao, Ado.core.ITenantDao, Ado.core.IUserDao, Ado.core.IUserGroupDao, Ado.core.IUserRightDao, Ado.core.IUserRightsRoleDao
  {
  }
  public partial interface IDataAccessInternal : IDataAccess, Ado.core.ICountryInternalDao, Ado.core.ICurrencyInternalDao, Ado.core.IDomainTypeInternalDao, Ado.core.IDomainValueInternalDao, Ado.core.IProductInternalDao, Ado.core.IProductInStockInternalDaoV, Ado.core.IProductsInStockInternalDaoV, Ado.core.ISpecialProductsInternalDaoV, Ado.core.IStockInternalDao, Ado.core.ITenantInternalDao, Ado.core.IUserInternalDao, Ado.core.IUserGroupInternalDao, Ado.core.IUserRightInternalDao, Ado.core.IUserRightsRoleInternalDao
  {
  }
}


