using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using VevoAPI;
using VevoAPI.Controllers;
using VevoAPI.Repository;
using VevoAPI.Tests.Models;

namespace VevoAPI.Tests.Controllers
{
  [TestClass]
  public class VideosControllerTest
  {

    [TestMethod]
    public void Get()
    {
      MockRepo repo = new MockRepo();
      VideosController controller = new VideosController(repo);
      var httpActionResult = controller.Get(6);
      Assert.IsInstanceOfType(httpActionResult, typeof(OkNegotiatedContentResult<IEnumerable<VevoAPI.Video>>));
      OkNegotiatedContentResult<IEnumerable<VevoAPI.Video>> contentResult = (OkNegotiatedContentResult<IEnumerable<VevoAPI.Video>>)httpActionResult;
      Assert.AreEqual("Bad", contentResult.Content.FirstOrDefault().Title);
    }

  }
}
