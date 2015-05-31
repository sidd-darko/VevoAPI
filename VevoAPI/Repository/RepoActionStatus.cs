using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VevoAPI.Repository
{
    public enum RepoActionStatus
    {
      Ok,
      Created,
      Updated,
      NotFound,
      Deleted,
      NothingModified,
      Error
    }

}