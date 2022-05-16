using WorkshopTestProject.Common.Interfaces;
using WorkshopTestProject.DataAccess.Initializer;
using Microsoft.Extensions.DependencyInjection;

namespace WorkshopTestProject.BusinessLogic.Initializer
{
  public class LogicInitializer
  {
    public LogicInitializer(IServiceCollection services)
    {
      services.AddSingleton(new DataAccessInitializer(services));

      services.AddTransient<ILogic, Logic>();
    }
  }
}