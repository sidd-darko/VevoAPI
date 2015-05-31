using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using VevoAPI.Repository;

namespace VevoAPI.Repository
{
  public class VevoRepository : IVevoRepository
  {

    VevoAPI.dbec456c96b54744ccbe8ca4a90080d642Entities1 _context;

    public VevoRepository(VevoAPI.dbec456c96b54744ccbe8ca4a90080d642Entities1 context = null)
    {
      if (context == null)
      {
        _context = new VevoAPI.dbec456c96b54744ccbe8ca4a90080d642Entities1();
      }
      else
      {
        _context = context;     
      }

    }

    public IEnumerable<VevoAPI.Artist> GetArtists()
    {
      return (from a in _context.Set<VevoAPI.Artist>()
              select new { ArtistID = a.ArtistID, ArtistName = a.ArtistName, ArtistUrlSafeName = a.ArtistUrlSafeName, Videos = a.Videos }).ToList()
              .Select(x => new VevoAPI.Artist { ArtistID = x.ArtistID, ArtistName = x.ArtistName, ArtistUrlSafeName = x.ArtistUrlSafeName, Videos = x.Videos.Select(y => new VevoAPI.Video { ISRC = y.ISRC,  Title = y.Title, UrlSafeTitle = y.UrlSafeTitle, ArtistID = y.ArtistID}).ToList() });
    }

    public VevoAPI.Artist GetArtists(int id)
    {
      return (from a in _context.Set<VevoAPI.Artist>()
              where a.ArtistID == id
              select new { ArtistID = a.ArtistID, ArtistName = a.ArtistName, ArtistUrlSafeName = a.ArtistUrlSafeName, Videos = a.Videos }).ToList()
              .Select(x => new VevoAPI.Artist { ArtistID = x.ArtistID, ArtistName = x.ArtistName, ArtistUrlSafeName = x.ArtistUrlSafeName, Videos = x.Videos.Select(y => new VevoAPI.Video { ISRC = y.ISRC, Title = y.Title, UrlSafeTitle = y.UrlSafeTitle, ArtistID = y.ArtistID }).ToList() }).First();
    }

    public RepoActionResult<VevoAPI.Artist> InsertArtist(VevoAPI.Artist artist)
    {
      try
      {
        _context.Artists.Add(artist);
        var result = _context.SaveChanges();
        if (result > 0)
        {
          return new RepoActionResult<VevoAPI.Artist>(artist, RepoActionStatus.Created);
        }
        else
        {
          return new RepoActionResult<VevoAPI.Artist>(artist, RepoActionStatus.NothingModified, null);
        }
      }
      catch (Exception ex)
      {
        return new RepoActionResult<VevoAPI.Artist>(null, RepoActionStatus.Error, ex);
      }

    }

    public RepoActionResult<VevoAPI.Artist> UpdateArtist(VevoAPI.Artist artist)
    {
      try
      {
        var artistFromRepo = _context.Artists.FirstOrDefault(afr => afr.ArtistID == artist.ArtistID);

        if (artistFromRepo == null)
        {
          return new RepoActionResult<VevoAPI.Artist>(artist, RepoActionStatus.NotFound);
        }

        _context.Entry(artistFromRepo).State = EntityState.Detached;
        _context.Artists.Attach(artist);
        _context.Entry(artist).State = EntityState.Modified;

        var result = _context.SaveChanges();
        if (result > 0)
        {
          return new RepoActionResult<VevoAPI.Artist>(artist, RepoActionStatus.Updated);
        }
        else
        {
          return new RepoActionResult<VevoAPI.Artist>(artist, RepoActionStatus.NothingModified, null);
        }

      }
      catch (Exception ex)
      {
        return new RepoActionResult<VevoAPI.Artist>(null, RepoActionStatus.Error, ex);
      }

    }

    public RepoActionResult<VevoAPI.Artist> DeleteArtist(int id)
    {
      try
      {
        var artist = _context.Artists.Where(a => a.ArtistID == id).FirstOrDefault();
        if (artist == null)
        {
          return new RepoActionResult<VevoAPI.Artist>(null, RepoActionStatus.NotFound);
        }

        _context.Artists.Remove(artist);
        _context.SaveChanges();
        return new RepoActionResult<VevoAPI.Artist>(null, RepoActionStatus.Deleted);

      }
      catch (Exception ex)
      {
        return new RepoActionResult<VevoAPI.Artist>(null, RepoActionStatus.Error, ex);
      }
    }

    public IEnumerable<VevoAPI.Video> GetVideos(int id)
    {
      VevoAPI.Artist artist = GetArtists(id);
      return artist.Videos;
    }

  }
}