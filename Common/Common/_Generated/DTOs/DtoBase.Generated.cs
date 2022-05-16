using System;

namespace WorkshopTestProject.Common.DTOs
{
  public interface IDtoBase
  {
    long Id { get; set; }
    DateTime ModifiedDate { get; set; }
    string ModifiedInformation { get; set; }
    long ModifiedUser { get; set; }
  }
  public abstract class DtoBase : IDtoBase
  {
    public string ModifiedInformation { get; set; }
    
    public long Id { get; set; } = -1;
    public DateTime ModifiedDate { get; set; }
    public long ModifiedUser { get; set; }
  }
}


