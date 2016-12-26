// //-----------------------------------------------------------------------
// // <copyright file="XmlResult.cs" company="">
// //     Copyright (c) 2016 . All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------
//
using System;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace ThreeWay.Common
{
  public class XmlResult : ViewResult
  {
    private readonly XmlAttributeOverrides xmlAttributeOverrides;

    public object ObjectToSerialize { get; private set; }

    public XmlResult(
      object objectToSerialize, 
      XmlAttributeOverrides xmlAttributeOverrides = null)
    {
      this.ObjectToSerialize = objectToSerialize;
      this.xmlAttributeOverrides = xmlAttributeOverrides;
    }

    public override void ExecuteResult(ControllerContext context)
    {
      if (this.ObjectToSerialize != null)
      {
        var xs = this.xmlAttributeOverrides == null ?
                     new XmlSerializer(this.ObjectToSerialize.GetType()) :
                     new XmlSerializer(
                       this.ObjectToSerialize.GetType(), 
                       this.xmlAttributeOverrides);
        context.HttpContext.Response.ContentType = "text/xml";
        xs.Serialize(context.HttpContext.Response.Output, this.ObjectToSerialize);
      }
    }
  }
}
