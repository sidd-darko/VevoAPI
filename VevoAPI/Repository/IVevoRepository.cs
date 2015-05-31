using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VevoAPI.Repository;

namespace VevoAPI.Repository
{
  public interface IVevoRepository
  {

    IEnumerable<VevoAPI.Artist> GetArtists();
    VevoAPI.Artist GetArtists(int id);
    RepoActionResult<VevoAPI.Artist> InsertArtist(VevoAPI.Artist artist);
    RepoActionResult<VevoAPI.Artist> UpdateArtist(VevoAPI.Artist artist);
    RepoActionResult<VevoAPI.Artist> DeleteArtist(int id);
    IEnumerable<VevoAPI.Video> GetVideos(int id);

  }
}
