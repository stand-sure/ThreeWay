// //-----------------------------------------------------------------------
// // <copyright file="AcceptTypeViewResult.cs" company="">
// //     Copyright (c) 2016 . All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------
//
using System;
using System.Web.Mvc;
using System.Runtime.CompilerServices;

namespace ThreeWay.Common
{
  public class AcceptTypeResult : ActionResult
  {
    private readonly object model;
    private readonly string viewName;

    public AcceptTypeResult() : this(string.Empty, null)
    {
    }

    public AcceptTypeResult(string viewName = "", object model = null)
    {
      this.viewName = viewName;
      this.model = model;
    }

    public override void ExecuteResult(ControllerContext context)
    {
      ActionResult result = null;
      bool handled = false;

      foreach (var acceptType in context.HttpContext.Request.AcceptTypes)
      {
        var responseType = acceptType.ToLowerInvariant();
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

        switch (responseType)
        {
          case "application/json":
            handled = true;
            result = new JsonResult() { Data = this.model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            break;
          case "application/xml":
            handled = true;
            result = new XmlResult(model);
            break;
          default:
            result = new ViewResult() { ViewName = this.viewName, ViewData = new ViewDataDictionary(this.model) };
            handled = true;
            break;
        }

        if (handled) break;
      }

      if (result != null)
      {
        result.ExecuteResult(context);
      }
    }
  }
}
