using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VevoAPI.Repository;

namespace VevoAPI.Tests.Models
{

  public class MockRepo : IVevoRepository
  {

    List<VevoAPI.Artist> _Artists;

    public MockRepo()
    {
      _Artists = new List<VevoAPI.Artist>();
      List<VevoAPI.Video> _Videos = new List<VevoAPI.Video>();
      _Videos.Add(new VevoAPI.Video { ISRC = "12345", Title = "TikTok", ArtistID = 5, UrlSafeTitle = "tiktok" });
      _Videos.Add(new VevoAPI.Video { ISRC = "12346", Title = "Blah Blah Blah", ArtistID = 5, UrlSafeTitle = "blahblahblah" });
      _Artists.Add(new VevoAPI.Artist { ArtistID = 5, ArtistName = "Ke$ha Sebert", ArtistUrlSafeName = "ke$hasebert", Videos = _Videos });
      _Videos = new List<VevoAPI.Video>();
      _Videos.Add(new VevoAPI.Video { ISRC = "12347", Title = "Bad", ArtistID = 6, UrlSafeTitle = "bad" });
      _Artists.Add(new VevoAPI.Artist { ArtistID = 6, ArtistName = "U2", ArtistUrlSafeName = "u2", Videos = _Videos });
    }

    public IEnumerable<VevoAPI.Artist> GetArtists()
    {
      return _Artists;
    }

    public VevoAPI.Artist GetArtists(int id)
    {
      return (from a in _Artists
              where a.ArtistID == id
              select a).FirstOrDefault();
    }

    public RepoActionResult<VevoAPI.Artist> InsertArtist(VevoAPI.Artist artist)
    {
      artist.ArtistID = 20;
      artist.Videos.First().ArtistID = 20;
      _Artists.Add(artist);
      return new RepoActionResult<VevoAPI.Artist>(artist, RepoActionStatus.Created);
    }

    public RepoActionResult<VevoAPI.Artist> UpdateArtist(VevoAPI.Artist artist)
    {
      _Artists.FirstOrDefault(afr => afr.ArtistID == artist.ArtistID).ArtistName = artist.ArtistName;
      _Artists.FirstOrDefault(afr => afr.ArtistID == artist.ArtistID).ArtistUrlSafeName = artist.ArtistUrlSafeName;
      return new RepoActionResult<VevoAPI.Artist>(_Artists.FirstOrDefault(afr => afr.ArtistID == artist.ArtistID), RepoActionStatus.Updated);
    }

    public RepoActionResult<VevoAPI.Artist> DeleteArtist(int id)
    {
      _Artists.Remove(_Artists.FirstOrDefault(afr => afr.ArtistID == id));
      return new RepoActionResult<VevoAPI.Artist>(null, RepoActionStatus.Deleted);
    }

    public IEnumerable<VevoAPI.Video> GetVideos(int id)
    {
      VevoAPI.Artist artist = GetArtists(id);
      return artist.Videos;
    }

  }

}
