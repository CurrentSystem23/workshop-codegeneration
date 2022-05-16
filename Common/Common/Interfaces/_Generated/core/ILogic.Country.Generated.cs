using WorkshopTestProject.Common.DTOs.core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WorkshopTestProject.Common.Interfaces
{
  public partial interface ILogic
  {
    #region Async
    Task<long> Core_CountryGetCountAsync();
    Task<ICollection<ICountryViewModel>> Core_CountryGetsAsync(params OrderCountry[] orderBy);
    Task<ICollection<ICountryViewModel>> Core_CountryGetsAsync(int? pageNum, int? pageSize, params OrderCountry[] orderBy);
    Task<ICountryViewModel> Core_CountryGetAsync(long id);
    Task<ICollection<ICountryHistViewModel>> Core_CountryHistGetsAsync(long id);
    Task<ICountryHistViewModel> Core_CountryHistEntryGetAsync(long histId);
    Task Core_CountryHistDeleteAsync(long histId);
    Task Core_CountrySaveAsync(ICountryViewModel dto);
    Task Core_CountryMergeAsync(ICountryViewModel dto);
    Task Core_CountryDeleteAsync(long id);
    Task<bool> Core_CountryHasChangedAsync(ICountryViewModel dto);
    Task Core_CountryBulkInsertAsync(ICollection<ICountryViewModel> dtos);
    Task Core_CountryBulkInsertAsync(ICollection<ICountryViewModel> dtos, bool identityInsert);
    Task Core_Country_TempBulkInsertAsync(ICollection<ICountryViewModel> dtos);
    Task Core_Country_TempBulkInsertAsync(ICollection<ICountryViewModel> dtos, bool identityInsert);
    Task Core_CountryBulkMergeAsync(ICollection<ICountryViewModel> dtos);
    Task Core_CountryBulkMergeAsync(ICollection<ICountryViewModel> dtos, bool identityInsert);
    Task Core_CountryBulkUpdateAsync(ICollection<ICountryViewModel> dtos);
    Task Core_CountryBulkDeleteAsync(ICollection<ICountryViewModel> dtos);
    #endregion
    #region Sync
    long Core_CountryGetCount();
    ICollection<ICountryViewModel> Core_CountryGets(params OrderCountry[] orderBy);
    ICollection<ICountryViewModel> Core_CountryGets(int? pageNum, int? pageSize, params OrderCountry[] orderBy);
    ICountryViewModel Core_CountryGet(long id);
    ICollection<ICountryHistViewModel> Core_CountryHistGets(long id);
    ICountryHistViewModel Core_CountryHistEntryGet(long histId);
    void Core_CountryHistDelete(long histId);
    void Core_CountrySave(ICountryViewModel dto);
    void Core_CountryMerge(ICountryViewModel dto);
    void Core_CountryDelete(long id);
    bool Core_CountryHasChanged(ICountryViewModel dto);
    void Core_CountryBulkInsert(ICollection<ICountryViewModel> dtos);
    void Core_CountryBulkInsert(ICollection<ICountryViewModel> dtos, bool identityInsert);
    void Core_Country_TempBulkInsert(ICollection<ICountryViewModel> dtos);
    void Core_Country_TempBulkInsert(ICollection<ICountryViewModel> dtos, bool identityInsert);
    void Core_CountryBulkMerge(ICollection<ICountryViewModel> dtos);
    void Core_CountryBulkMerge(ICollection<ICountryViewModel> dtos, bool identityInsert);
    void Core_CountryBulkUpdate(ICollection<ICountryViewModel> dtos);
    void Core_CountryBulkDelete(ICollection<ICountryViewModel> dtos);
    #endregion
  }
}


