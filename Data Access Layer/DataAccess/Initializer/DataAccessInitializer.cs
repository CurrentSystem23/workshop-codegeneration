using WorkshopTestProject.Common.DataAccess.Interfaces.Ado;
using WorkshopTestProject.DataAccess.SQL.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace WorkshopTestProject.DataAccess.Initializer
{
  public class DataAccessInitializer
  {
    public DataAccessInitializer(IServiceCollection services)
    {
      services.AddSingleton(new DataAccessAdoInitializer(services));
      services.AddTransient<IDataAccess, DataAccess>();
    }
  }
}
