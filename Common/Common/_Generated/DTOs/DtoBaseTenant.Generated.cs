using System;

namespace WorkshopTestProject.Common.DTOs
{
  public interface IDtoBaseTenant : IDtoBase
  {
    long TenantId { get; set; }
  }
  public abstract class DtoBaseTenant : DtoBase, IDtoBaseTenant
  {
    public long TenantId { get; set; }
  }
}


