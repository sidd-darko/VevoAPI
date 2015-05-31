using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VevoAPI.DataAccess
{
  public class DataContext : DbContext
  {

    public DataContext()
      : base("name=dbec456c96b54744ccbe8ca4a90080d642Entities1")
    { 
    
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Video> Videos { get; set; }

  }
}