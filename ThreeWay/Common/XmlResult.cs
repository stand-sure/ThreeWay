// //-----------------------------------------------------------------------
// // <copyright file="XmlResult.cs" company="Stand Sure LLC">
// //     Copyright (c) 2016 . All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace ThreeWay.Common
{
  using System.Web.Mvc;
  using System.Xml.Serialization;

  /// <summary>
  /// XML view result.
  /// </summary>
  public class XmlResult : ViewResult
  {
    /// <summary>
    /// The xml attribute overrides.
    /// </summary>
    private readonly XmlAttributeOverrides xmlAttributeOverrides;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:ThreeWay.Common.XmlResult"/> class.
    /// </summary>
    /// <param name="objectToSerialize">Object to serialize.</param>
    /// <param name="xmlAttributeOverrides">Xml attribute overrides.</param>
    public XmlResult(
      object objectToSerialize,
      XmlAttributeOverrides xmlAttributeOverrides = null)
    {
      this.ObjectToSerialize = objectToSerialize;
      this.xmlAttributeOverrides = xmlAttributeOverrides;
    }

    /// <summary>
    /// Gets the object to serialize.
    /// </summary>
    /// <value>The object to serialize.</value>
    public object ObjectToSerialize { get; private set; }

    /// <summary>
    /// Executes the result.
    /// </summary>
    /// <param name="context">The Controller Context.</param>
    public override void ExecuteResult(ControllerContext context)
    {
      if (this.ObjectToSerialize != null)
      {
        var xs = this.xmlAttributeOverrides == null ?
                     new XmlSerializer(this.ObjectToSerialize.GetType()) :
                     new XmlSerializer(
                       this.ObjectToSerialize.GetType(),
                       this.xmlAttributeOverrides);
        context.HttpContext.Response.ContentType = "application/xml";
        xs.Serialize(context.HttpContext.Response.Output, this.ObjectToSerialize);
      }
    }
  }
}
