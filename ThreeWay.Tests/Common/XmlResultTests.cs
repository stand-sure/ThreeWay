// //-----------------------------------------------------------------------
// // <copyright file="XmlResultTests.cs" company="Stand Sure LLC">
// //     Copyright (c) 2016. All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------
using System.Runtime.InteropServices.ComTypes;

namespace ThreeWay.Tests.Common
{
  using System;
  using System.Reflection;
  using System.Web;
  using System.Web.Mvc;
  using Moq;
  using NUnit.Framework;
  using XmlResult = ThreeWay.Common.XmlResult;
  using XmlSerializer = System.Xml.Serialization.XmlSerializer;
  using StringWriter = System.IO.StringWriter;

  [TestFixture]
  public class XmlResultTests : AssertionHelper
  {
    [SetUp]
    public void SetUp()
    {
      
    }

    [Test]
    public void XmlResult_Should_Extend_ViewResult()
    {
      this.Expect(new XmlResult(new object()), Is.InstanceOf<ViewResult>());
    }

    [Test]
    public void XmlResult_ObjectToSerialize_Property_Should_Return_Correct_Object()
    {
      var expected = new object();
      var xr = new XmlResult(expected);

      var actual = xr.ObjectToSerialize;

      this.Expect(actual, Is.EqualTo(expected));
    }

    [Test]
    public void XmlResult_Should_Override_ExecuteResult()
    {
      var expected = typeof(XmlResult);
      var method = expected.GetMethod("ExecuteResult");
      var actual = method.DeclaringType;

      this.Expect(actual, Is.EqualTo(expected));
    }

    [Test]
    public void XmlResult_ExecuteResult_Should_Set_ApplicationXml_ContentType()
    {
      var expected = "application/xml";
      var controllerContext = SetUpController(new StringWriter());

      new XmlResult(new object()).ExecuteResult(controllerContext);
      var actual = controllerContext.HttpContext.Response.ContentType;

      this.Expect(actual, Is.EqualTo(expected));
    }

    [Test]
    public void XmlResult_ExecuteResult_Should_Use_XmlSerializer()
    {
      string[] simple = { "a", "b" };

      var expectedWriter = new StringWriter();
      new XmlSerializer(simple.GetType()).Serialize(expectedWriter, simple);
      var expected = expectedWriter.ToString();

      var actualWriter = new StringWriter();
      var controllerContext = SetUpController(actualWriter);
      new XmlResult(simple).ExecuteResult(controllerContext);
      var actual = actualWriter.ToString();

      this.Expect(actual, Is.EqualTo(expected));
    }

    private static ControllerContext SetUpController(StringWriter writer)
    {
      var response = new Mock<HttpResponseBase>(MockBehavior.Strict);
      response.SetupProperty(resp => resp.ContentType);

      response.SetupGet(resp => resp.Output).Returns(writer);

      var httpContext = new Mock<HttpContextBase>(MockBehavior.Strict);
      httpContext.SetupGet(hctx => hctx.Response).Returns(response.Object);

      var controllerContext = new Mock<ControllerContext>(MockBehavior.Strict);
      controllerContext.SetupGet(cctx => cctx.HttpContext).Returns(httpContext.Object);
      return controllerContext.Object;
    }
  }
}
