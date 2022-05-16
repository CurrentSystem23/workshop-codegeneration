using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using WorkshopTestProject.BusinessLogic.Initializer;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado;
using WorkshopTestProject.Common.DTOs.core;
using WorkshopTestProject.Test.UnitTests.Mocks;

namespace WorkshopTestProject.Test.UnitTests
{
  internal abstract class UnitTestsBase<T> where T : LogicInitializer
  {
    protected ServiceProvider ServiceProvider;

    [OneTimeSetUp]
    public void SetUp()
    {
      Mock<IDataAccess> dataAccessMock = new Mock<IDataAccess>();
      ServiceProvider = CreateServiceProdvider(dataAccessMock);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
      ServiceProvider?.Dispose();
    }

    protected ServiceProvider CreateServiceProdvider(Mock<IDataAccess> dataAccessMock, Action<IServiceCollection> mockOther = null)
    {
      IConfiguration configuration = MockConfiguration().Object;
      IServiceCollection serviceCollection = new ServiceCollection();
      serviceCollection.AddLogging();
      serviceCollection.AddSingleton((T)Activator.CreateInstance(typeof(T), serviceCollection));
      serviceCollection.AddSingleton(configuration);

      MockDataAccess(serviceCollection, dataAccessMock, configuration);

      if (mockOther != null)
      {
        mockOther(serviceCollection);
      }

      return serviceCollection.BuildServiceProvider();
    }

    protected abstract Mock<IConfiguration> MockConfiguration();

    protected abstract void MockDataAccess(IServiceCollection serviceCollection, Mock<IDataAccess> dataAccessMock, IConfiguration configuration);
  }
}
