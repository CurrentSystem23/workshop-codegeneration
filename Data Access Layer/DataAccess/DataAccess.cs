using Microsoft.Extensions.Logging;
using System;

namespace WorkshopTestProject.DataAccess
{
  /// <summary>
  /// The <see cref="DataAccess"/> class.
  /// </summary>
  public partial class DataAccess
  {
    public DataAccess(IServiceProvider provider)
    {
      _logger = null;
      _provider = provider;
    }
  }
}