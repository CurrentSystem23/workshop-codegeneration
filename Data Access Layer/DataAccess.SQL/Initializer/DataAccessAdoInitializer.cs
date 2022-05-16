using Microsoft.Extensions.DependencyInjection;

namespace WorkshopTestProject.DataAccess.SQL.Helper
{
  public partial class DataAccessAdoInitializer
  {
    public DataAccessAdoInitializer(IServiceCollection services)
    {
      InitializeGenerated(services);
    }
  }
}
