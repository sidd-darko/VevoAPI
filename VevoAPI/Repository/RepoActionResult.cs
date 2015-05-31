using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VevoAPI.Repository
{
  public class RepoActionResult<T> where T: class
  {

        public T Entity { get; private set; }
        public RepoActionStatus Status { get; private set; }

        public Exception Exception { get; private set; }


        public RepoActionResult(T entity, RepoActionStatus status)
        {
            Entity = entity;
            Status = status;
        }

        public RepoActionResult(T entity, RepoActionStatus status, Exception exception)
          : this(entity, status)
        {
            Exception = exception;
        }

  }
}