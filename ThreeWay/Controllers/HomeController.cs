using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Runtime.CompilerServices;
using XmlResult = ThreeWay.Common.XmlResult;
using ThreeWay.Common;

namespace ThreeWay.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    public ActionResult Index(string fmt)
    {
      var mvcName = typeof(Controller).Assembly.GetName();
      var isMono = Type.GetType("Mono.Runtime") != null;

      ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
      ViewData["Runtime"] = isMono ? "Mono" : ".NET";

      var model = new Models.Person() { FirstName="John", LastName="Smith"};

      return new AcceptTypeResult("Index", model);
    }
  }
}
