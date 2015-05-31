using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VevoAPI;
using VevoAPI.Controllers;
using VevoAPI.Repository;
using System.Web.Http.Results;
using VevoAPI.Tests.Models;

namespace VevoAPI.Tests.Controllers
{
  [TestClass]
  public class ArtistsControllerTest
  {
    [TestMethod]
    public void Get()
    {
      MockRepo repo = new MockRepo();
      ArtistsController controller = new ArtistsController(repo);
      var httpActionResult = controller.Get();
      Assert.IsInstanceOfType(httpActionResult, typeof(OkNegotiatedContentResult<IEnumerable<VevoAPI.Artist>>));
      OkNegotiatedContentResult<IEnumerable<VevoAPI.Artist>> contentResult = (OkNegotiatedContentResult<IEnumerable<VevoAPI.Artist>>)httpActionResult;
      Assert.AreEqual("Ke$ha Sebert", contentResult.Content.FirstOrDefault().ArtistName);
    }

    [TestMethod]
    public void GetById()
    {
      MockRepo repo = new MockRepo();
      ArtistsController controller = new ArtistsController(repo);
      var httpActionResult = controller.Get(6);
      Assert.IsInstanceOfType(httpActionResult, typeof(OkNegotiatedContentResult<VevoAPI.Artist>));
      OkNegotiatedContentResult<VevoAPI.Artist> contentResult = (OkNegotiatedContentResult<VevoAPI.Artist>)httpActionResult;
      Assert.AreEqual("U2", contentResult.Content.ArtistName);
    }

    [TestMethod]
    public void Post()
    {
      MockRepo repo = new MockRepo();
      ArtistsController controller = new ArtistsController(repo);
      controller.Request = new HttpRequestMessage();
      controller.Request.Properties.Add(System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

      List<VevoAPI.Video> _Videos = new List<VevoAPI.Video>();
      _Videos.Add(new VevoAPI.Video { ISRC = "54321", Title = "Sun Models", UrlSafeTitle = "SunModels" });
      VevoAPI.Artist _Artist = new VevoAPI.Artist();
      _Artist = new VevoAPI.Artist { ArtistName = "ODESZA", ArtistUrlSafeName = "odesza", Videos = _Videos };


      var httpActionResult = controller.Post(_Artist);
      Assert.IsInstanceOfType(httpActionResult, typeof(CreatedNegotiatedContentResult<VevoAPI.Artist>));
      CreatedNegotiatedContentResult<VevoAPI.Artist> contentResult = (CreatedNegotiatedContentResult<VevoAPI.Artist>)httpActionResult;
      Assert.AreEqual("ODESZA", contentResult.Content.ArtistName);
      Assert.AreEqual(20, contentResult.Content.ArtistID);
    }

    [TestMethod]
    public void Put()
    {
      MockRepo repo = new MockRepo();
      ArtistsController controller = new ArtistsController(repo);

      VevoAPI.Artist _Artist = repo.GetArtists(5);
      _Artist.ArtistName = "ke$ha";
      _Artist.ArtistUrlSafeName = "ke$ha";
      var httpActionResult = controller.Put(_Artist);
      OkNegotiatedContentResult<VevoAPI.Artist> contentResult = (OkNegotiatedContentResult<VevoAPI.Artist>)httpActionResult;
      Assert.AreEqual("ke$ha", contentResult.Content.ArtistName);
      Assert.AreEqual("ke$ha", contentResult.Content.ArtistUrlSafeName);
    }

    [TestMethod]
    public void Delete()
    {
      MockRepo repo = new MockRepo();
      ArtistsController controller = new ArtistsController(repo);
      var httpActionResult = controller.Delete(6);
      Assert.IsNull(repo.GetArtists(6));
      Assert.IsInstanceOfType(httpActionResult, typeof(System.Web.Http.Results.StatusCodeResult));
      StatusCodeResult statusResult = (StatusCodeResult)httpActionResult;
      Assert.AreEqual(System.Net.HttpStatusCode.NoContent, statusResult.StatusCode);
    }
  }

}
