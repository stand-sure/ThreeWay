// //-----------------------------------------------------------------------
// // <copyright file="AcceptTypeResult.cs" company="Stand Sure LLC">
// //     Copyright (c) 2016 . All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace ThreeWay.Common
{
  using System.Linq;
  using System.Web.Mvc;

  /// <summary>
  /// An ActionResult substitute that uses the Accept header from the response to
  /// determine whether to send HTML, XML, or JSON.
  /// </summary>
  /// <remarks>
  /// <para>Since the most preferred is first from modern browsers,
  /// this code only uses the first value.</para>
  /// <para>The Accept headers "application/json" and "application/xml" are the expected 
  /// types for JSON and XML, respectively.</para>
  /// <para>The default is to use a regular ViewResult.</para>
  /// </remarks>
  public class AcceptTypeResult : ActionResult
  {
    /// <summary>
    /// The model.
    /// </summary>
    private readonly object model;

    /// <summary>
    /// The name of the view.
    /// </summary>
    private readonly string viewName;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:ThreeWay.Common.AcceptTypeResult"/> class.
    /// </summary>
    public AcceptTypeResult() : this(string.Empty, null) 
    { 
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:ThreeWay.Common.AcceptTypeResult"/> class.
    /// </summary>
    /// <param name="viewName">View name.</param>
    /// <param name="model">The Model.</param>
    public AcceptTypeResult(string viewName = "", object model = null)
    {
      this.viewName = viewName;
      this.model = model;
    }

    /// <summary>
    /// Gets or sets the view data.
    /// </summary>
    /// <value>The view data.</value>
    public ViewDataDictionary ViewData { get; set; }

    /// <summary>
    /// Gets or sets the temp data.
    /// </summary>
    /// <value>The temp data.</value>
    public TempDataDictionary TempData { get; set; }

    /// <summary>
    /// Gets or sets the name of the master view.
    /// </summary>
    /// <value>The name of the master view.</value>
    public string MasterName { get; set; }

    /// <summary>
    /// Executes the result.
    /// </summary>
    /// <param name="context">The Controller Context.</param>
    public override void ExecuteResult(ControllerContext context)
    {
      ActionResult result = null;

      var acceptType = context.HttpContext.Request.AcceptTypes.FirstOrDefault();
      string responseType = acceptType.ToLowerInvariant();
      responseType = AlterResponseTypeByFmtFlag(context, responseType);

      switch (responseType)
      {
        case "application/json":
          result = new JsonResult()
          {
            Data = this.model,
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
          };
          break;

        case "application/xml":
          result = new XmlResult(this.model);
          break;

        default:
          if (this.ViewData == null)
          {
            this.ViewData = new ViewDataDictionary();
          }

          this.ViewData.Model = this.model;
          result = new ViewResult()
          {
            ViewName = this.viewName,
            ViewData = this.ViewData,
            TempData = this.TempData,
            MasterName = this.MasterName
          };
          break;
      }

      if (result != null)
      {
        result.ExecuteResult(context);
      }
    }

    /// <summary>
    /// Alters the response type by fmt flag.
    /// </summary>
    /// <returns>The response type by fmt flag.</returns>
    /// <param name="context">The Controller Context.</param>
    /// <param name="responseType">The response MIME type.</param>
    private static string AlterResponseTypeByFmtFlag(ControllerContext context, string responseType)
    {
      var overrideFormat = context.HttpContext.Request.QueryString["fmt"];

      if (!string.IsNullOrEmpty(overrideFormat))
      {
        switch (overrideFormat)
        {
          case "xml":
            responseType = "application/xml";
            break;
          case "json":
            responseType = "application/json";
            break;
          default:
            break;
        }
      }

      return responseType;
    }
  }
}
