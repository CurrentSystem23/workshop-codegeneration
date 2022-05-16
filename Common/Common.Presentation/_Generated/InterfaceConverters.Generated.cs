using CurrentSystem23.Extensions;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkshopTestProject.Common.Presentation
{
  public static class InterfaceConverters
  {
    public static List<JsonConverter> Converters = new List<JsonConverter>()
    {
      new InterfaceConverter<DTOs.core.CountryDto, DTOs.core.ICountryDto>(),
        new InterfaceConverter<DTOs.core.CountryViewModel, DTOs.core.ICountryViewModel>(),
        new InterfaceConverter<DTOs.core.CountryDto, DTOs.core.ICountryDto>(),
        new InterfaceConverter<DTOs.core.CountryViewModel, DTOs.core.ICountryViewModel>(),
        
      new InterfaceConverter<DTOs.core.CurrencyDto, DTOs.core.ICurrencyDto>(),
        new InterfaceConverter<DTOs.core.CurrencyViewModel, DTOs.core.ICurrencyViewModel>(),
        new InterfaceConverter<DTOs.core.CurrencyDto, DTOs.core.ICurrencyDto>(),
        new InterfaceConverter<DTOs.core.CurrencyViewModel, DTOs.core.ICurrencyViewModel>(),
        
      new InterfaceConverter<DTOs.core.DomainTypeDto, DTOs.core.IDomainTypeDto>(),
        new InterfaceConverter<DTOs.core.DomainTypeViewModel, DTOs.core.IDomainTypeViewModel>(),
        new InterfaceConverter<DTOs.core.DomainTypeDto, DTOs.core.IDomainTypeDto>(),
        new InterfaceConverter<DTOs.core.DomainTypeViewModel, DTOs.core.IDomainTypeViewModel>(),
        
      new InterfaceConverter<DTOs.core.DomainValueDto, DTOs.core.IDomainValueDto>(),
        new InterfaceConverter<DTOs.core.DomainValueViewModel, DTOs.core.IDomainValueViewModel>(),
        new InterfaceConverter<DTOs.core.DomainValueDto, DTOs.core.IDomainValueDto>(),
        new InterfaceConverter<DTOs.core.DomainValueViewModel, DTOs.core.IDomainValueViewModel>(),
        
      new InterfaceConverter<DTOs.core.ProductDto, DTOs.core.IProductDto>(),
        new InterfaceConverter<DTOs.core.ProductViewModel, DTOs.core.IProductViewModel>(),
        new InterfaceConverter<DTOs.core.ProductDto, DTOs.core.IProductDto>(),
        new InterfaceConverter<DTOs.core.ProductViewModel, DTOs.core.IProductViewModel>(),
        
      new InterfaceConverter<DTOs.core.ProductInStockDtoV, DTOs.core.IProductInStockDtoV>(),
        new InterfaceConverter<DTOs.core.ProductInStockViewModel, DTOs.core.IProductInStockViewModel>(),
        
      new InterfaceConverter<DTOs.core.ProductsInStockDtoV, DTOs.core.IProductsInStockDtoV>(),
        new InterfaceConverter<DTOs.core.ProductsInStockViewModel, DTOs.core.IProductsInStockViewModel>(),
        
      new InterfaceConverter<DTOs.core.SpecialProductsDtoV, DTOs.core.ISpecialProductsDtoV>(),
        new InterfaceConverter<DTOs.core.SpecialProductsViewModel, DTOs.core.ISpecialProductsViewModel>(),
        
      new InterfaceConverter<DTOs.core.StockDto, DTOs.core.IStockDto>(),
        new InterfaceConverter<DTOs.core.StockViewModel, DTOs.core.IStockViewModel>(),
        new InterfaceConverter<DTOs.core.StockDto, DTOs.core.IStockDto>(),
        new InterfaceConverter<DTOs.core.StockViewModel, DTOs.core.IStockViewModel>(),
        
      new InterfaceConverter<DTOs.core.TenantDto, DTOs.core.ITenantDto>(),
        new InterfaceConverter<DTOs.core.TenantViewModel, DTOs.core.ITenantViewModel>(),
        new InterfaceConverter<DTOs.core.TenantDto, DTOs.core.ITenantDto>(),
        new InterfaceConverter<DTOs.core.TenantViewModel, DTOs.core.ITenantViewModel>(),
        
      new InterfaceConverter<DTOs.core.UserDto, DTOs.core.IUserDto>(),
        new InterfaceConverter<DTOs.core.UserViewModel, DTOs.core.IUserViewModel>(),
        new InterfaceConverter<DTOs.core.UserDto, DTOs.core.IUserDto>(),
        new InterfaceConverter<DTOs.core.UserViewModel, DTOs.core.IUserViewModel>(),
        
      new InterfaceConverter<DTOs.core.UserGroupDto, DTOs.core.IUserGroupDto>(),
        new InterfaceConverter<DTOs.core.UserGroupViewModel, DTOs.core.IUserGroupViewModel>(),
        new InterfaceConverter<DTOs.core.UserGroupDto, DTOs.core.IUserGroupDto>(),
        new InterfaceConverter<DTOs.core.UserGroupViewModel, DTOs.core.IUserGroupViewModel>(),
        
      new InterfaceConverter<DTOs.core.UserRightDto, DTOs.core.IUserRightDto>(),
        new InterfaceConverter<DTOs.core.UserRightViewModel, DTOs.core.IUserRightViewModel>(),
        new InterfaceConverter<DTOs.core.UserRightDto, DTOs.core.IUserRightDto>(),
        new InterfaceConverter<DTOs.core.UserRightViewModel, DTOs.core.IUserRightViewModel>(),
        
      new InterfaceConverter<DTOs.core.UserRightsRoleDto, DTOs.core.IUserRightsRoleDto>(),
        new InterfaceConverter<DTOs.core.UserRightsRoleViewModel, DTOs.core.IUserRightsRoleViewModel>(),
        new InterfaceConverter<DTOs.core.UserRightsRoleDto, DTOs.core.IUserRightsRoleDto>(),
        new InterfaceConverter<DTOs.core.UserRightsRoleViewModel, DTOs.core.IUserRightsRoleViewModel>(),
        
      };
  }
}


