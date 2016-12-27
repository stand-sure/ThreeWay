using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ThreeWay;
using ThreeWay.Controllers;

namespace ThreeWay.Tests.Controllers
{
  [TestFixture]
  public class HomeControllerTest : AssertionHelper
  {
    [Test]
    public void Index()
    {
      // Arrange
      var controller = new HomeController();

      // Act
      var result = controller.Index();

      // Assert

    }
  }
}
