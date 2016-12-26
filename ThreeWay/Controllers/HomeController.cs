// //-----------------------------------------------------------------------
// // <copyright file="HomeController.cs" company="Stand Sure LLC">
// //     Copyright (c) 2016 . All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace ThreeWay.Controllers
{
  using System.Web.Mvc;
  using Common;

  /// <summary>
  /// Home controller.
  /// </summary>
  public class HomeController : Controller
  {
    /// <summary>
    /// GET: /
    /// </summary>
    /// <param name="fmt">An optional flag. Values of "json" or "xml" will override ACCEPT header.</param>
    /// <returns>An <see cref="T:ThreeWay.Common.AcceptTypeResult"/> instance.
    /// The <c>ExecuteResult</c> method will invoke the 
    /// same method in the ViewResult, JsonResult or XmlResult.</returns>
    [HttpGet]
    public ActionResult Index(string fmt)
    {
      var model = new Models.Person() { FirstName = "John", LastName = "Smith" };

      var result = new AcceptTypeResult("Index", model)
      {
        TempData = this.TempData,
        ViewData = this.ViewData,
        MasterName = string.Empty
      };

      return result;
    }
  }
}
