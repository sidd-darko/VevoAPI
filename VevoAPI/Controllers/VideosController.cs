using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VevoAPI.Controllers
{
  public class VideosController : ApiController
  {

    Repository.IVevoRepository _repository;

    public VideosController(Repository.IVevoRepository repository)
    {
      _repository = repository;
    }

    public IHttpActionResult Get(int id)
    {
      try
      {
        return Ok(_repository.GetVideos(id));
      }
      catch (Exception)
      {
        return InternalServerError();
      }
    }

  }
}
