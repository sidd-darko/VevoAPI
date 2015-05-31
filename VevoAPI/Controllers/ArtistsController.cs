using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VevoAPI.Controllers
{
    public class ArtistsController : ApiController
    {

      Repository.IVevoRepository _repository;

      public ArtistsController(Repository.IVevoRepository repository)
      {
        _repository = repository;
      }

      public IHttpActionResult Get() {
        try
        {
          return Ok(_repository.GetArtists());
        }
        catch (Exception)
        {
          return InternalServerError();
        }
      
      }

      public IHttpActionResult Get(int id)
      {
        try
        {
          return Ok(_repository.GetArtists(id));
        }
        catch (Exception)
        {
          return InternalServerError();
        }

      }

      [HttpPost]
      public IHttpActionResult Post([FromUri] VevoAPI.Artist artist)
      {
        try
        {
          var result = _repository.InsertArtist(artist);

          if (result.Status == VevoAPI.Repository.RepoActionStatus.Created) 
          {
            return Created(Request.RequestUri + "/" + result.Entity.ArtistID.ToString(), result.Entity);
          }
          return BadRequest();
        }
        catch (Exception)
        {
          return InternalServerError();
        }    
      }

      [HttpPut]
      public IHttpActionResult Put([FromUri] VevoAPI.Artist artist)
      {
        try
        {
          var result = _repository.UpdateArtist(artist);

          if (result.Status == VevoAPI.Repository.RepoActionStatus.NotFound)
          {
            return NotFound();
          }

          if (result.Status == VevoAPI.Repository.RepoActionStatus.Updated)
          {
            return Ok(result.Entity);
          }
          return BadRequest();
        }
        catch (Exception)
        {
          return InternalServerError();
        }
      }

      public IHttpActionResult Delete(int id) 
      {
        try
        {
          var result = _repository.DeleteArtist(id);
          if (result.Status == VevoAPI.Repository.RepoActionStatus.NotFound)
          {
            return NotFound();
          }

          if (result.Status == VevoAPI.Repository.RepoActionStatus.Deleted)
          {
            return StatusCode(HttpStatusCode.NoContent);
          }
          return BadRequest();
        }
        catch (Exception)
        {
          return InternalServerError();     
        }
      }

    }
}
