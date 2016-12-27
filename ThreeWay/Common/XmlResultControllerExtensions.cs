// //-----------------------------------------------------------------------
// // <copyright file="XmlResultControllerExtensions.cs" company="Stand Sure LLC">
// //     Copyright (c) 2016. All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace ThreeWay.Common
{
  using System.Web.Mvc;
  using System.Xml.Serialization;

  public static class XmlResultControllerExtensions
  {
    public static XmlResult XML(
      this Controller controller,
      object model,
      XmlAttributeOverrides xmlAttributeOverrides = null)
    {
      return new XmlResult(model, xmlAttributeOverrides);
    }
  }
}
