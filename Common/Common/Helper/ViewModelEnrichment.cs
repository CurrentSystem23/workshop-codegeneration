using WorkshopTestProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WorkshopTestProject.Common.Helper
{
  public static class ViewModelEnrichment
  {
    public static void AddUserinformationToViewModel(ClaimsPrincipal user, IDtoBase dtoBase)
    {
      /*
      if (user.TryGetSubject<long>(out var userId))
      {
        dtoBase.ModifiedUser = userId;
        dtoBase.ModifiedDate = DateTime.UtcNow;
      }
      */
      IDtoBaseTenant dtoBaseTenant = dtoBase as IDtoBaseTenant;
      if (dtoBaseTenant != null)
      {
        /*
        if (user.TryGetTenant(out var tenantId))
        {
          dtoBaseTenant.TenantId = tenantId;
        }
        */
      }
    }

    public static void AddUserinformationToViewModel(long userId, long tenantId, IDtoBase dtoBase)
    {
      dtoBase.ModifiedUser = userId;
      dtoBase.ModifiedDate = DateTime.UtcNow;

      IDtoBaseTenant dtoBaseTenant = dtoBase as IDtoBaseTenant;
      if (dtoBaseTenant != null)
      {
        dtoBaseTenant.TenantId = tenantId;
      }
    }
  }
}
