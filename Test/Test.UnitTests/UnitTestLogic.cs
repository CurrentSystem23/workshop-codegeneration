using System.Collections.Generic;
using System.Threading.Tasks;
using WorkshopTestProject.BusinessLogic.Initializer;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado;
using WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core;
using WorkshopTestProject.Common.DTOs.core;
using WorkshopTestProject.Common.Interfaces;
using WorkshopTestProject.Test.UnitTests.Mocks;
//using WorkshopTestProject.Test.UnitTests.Mocks.core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace WorkshopTestProject.Test.UnitTests
{
  [TestFixture]
  internal class UnitTestLogic : UnitTestsBase<LogicInitializer>
  {
    [Test]
    public void Test1()
    {
      // arrange
      ILogic logic = ServiceProvider.GetRequiredService<ILogic>();

      // act
      long domainValueGetCount = logic.Core_DomainValueGetCount();
      var a = logic.Core_DomainValueGets(OrderDomainValue.TypeId_Desc);

      // assert
      Assert.Greater(domainValueGetCount, 0);
    }

    [Test]
    public void Test2()
    {
      // arrange
      Mock<IDataAccess> dataAccessMock = new Mock<IDataAccess>();
      var sp = this.CreateServiceProdvider(dataAccessMock, sc =>
      {
        dataAccessMock.As<WorkshopTestProject.Common.DataAccess.Interfaces.Ado.core.IDomainValueDao>().Setup(x => x.DomainValueGetCount()).Returns(7);
      });

      ILogic logic = sp.GetRequiredService<ILogic>();

      // act
      long domainValueGetCount = logic.Core_DomainValueGetCount();
      var domainValues = logic.Core_DomainValueGets();

      // assert
      Assert.Greater(domainValueGetCount, 0);
    }

    [Test]
    public void Test3()
    {
      // arrange
      IDataAccess dataAccess = ServiceProvider.GetRequiredService<IDataAccess>();

      // act
      long domainValueGetCount = dataAccess.DomainValueGetCount();
      var a = dataAccess.DomainValueGets(OrderDomainValue.Id_Desc);

      // assert
      Assert.Greater(domainValueGetCount, 0);
    }

    protected override Mock<IConfiguration> MockConfiguration()
    {
      Mock<IConfiguration> configuration = new Mock<IConfiguration>();

      return configuration;
    }

    protected override void MockDataAccess(IServiceCollection serviceCollection, Mock<IDataAccess> dataAccessMock, IConfiguration configuration)
    {
      MockSetup.InitializeMockSetup(serviceCollection, dataAccessMock);
    }
  }
}