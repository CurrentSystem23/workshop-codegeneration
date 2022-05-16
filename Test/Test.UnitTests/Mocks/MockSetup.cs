using WorkshopTestProject.Common.DataAccess.Interfaces.Ado;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace WorkshopTestProject.Test.UnitTests.Mocks
{
  public class MockSetup : MockSetupBase
  {
    public static new void InitializeMockSetup(IServiceCollection serviceCollection, Mock<IDataAccess> dataAccessMock, Action<Mock<IDataAccess>> mockOthers = null)
    {
      MockSetupBase.InitializeMockSetup(serviceCollection, dataAccessMock, mockOthers);

      // manual mocks go here
    }
  }
}
