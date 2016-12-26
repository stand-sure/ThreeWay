// //-----------------------------------------------------------------------
// // <copyright file="Global.asax.cs" company="">
// //     Copyright (c) 2016 . All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------
//
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace ThreeWay
{
  public class Global : HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }
  }
}
