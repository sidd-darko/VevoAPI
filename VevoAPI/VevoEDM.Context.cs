﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VevoAPI
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class dbec456c96b54744ccbe8ca4a90080d642Entities1 : DbContext
    {
        public dbec456c96b54744ccbe8ca4a90080d642Entities1()
            : base("name=dbec456c96b54744ccbe8ca4a90080d642Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Video> Videos { get; set; }
    
        public virtual int sp_DeleteArtist(Nullable<int> artistID)
        {
            var artistIDParameter = artistID.HasValue ?
                new ObjectParameter("ArtistID", artistID) :
                new ObjectParameter("ArtistID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteArtist", artistIDParameter);
        }
    
        public virtual int sp_DeleteVideo(string iSRC)
        {
            var iSRCParameter = iSRC != null ?
                new ObjectParameter("ISRC", iSRC) :
                new ObjectParameter("ISRC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteVideo", iSRCParameter);
        }
    
        public virtual ObjectResult<sp_GetArtist_Result> sp_GetArtist(Nullable<int> artistID)
        {
            var artistIDParameter = artistID.HasValue ?
                new ObjectParameter("ArtistID", artistID) :
                new ObjectParameter("ArtistID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetArtist_Result>("sp_GetArtist", artistIDParameter);
        }
    
        public virtual ObjectResult<sp_GetArtists_Result> sp_GetArtists()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetArtists_Result>("sp_GetArtists");
        }
    
        public virtual ObjectResult<sp_GetVideo_Result> sp_GetVideo(string iSRC)
        {
            var iSRCParameter = iSRC != null ?
                new ObjectParameter("ISRC", iSRC) :
                new ObjectParameter("ISRC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetVideo_Result>("sp_GetVideo", iSRCParameter);
        }
    
        public virtual ObjectResult<sp_GetVideosByArtist_Result> sp_GetVideosByArtist(Nullable<int> artistID)
        {
            var artistIDParameter = artistID.HasValue ?
                new ObjectParameter("ArtistID", artistID) :
                new ObjectParameter("ArtistID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetVideosByArtist_Result>("sp_GetVideosByArtist", artistIDParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> sp_InsertArtist(string artistName, string artistUrlSafeName)
        {
            var artistNameParameter = artistName != null ?
                new ObjectParameter("ArtistName", artistName) :
                new ObjectParameter("ArtistName", typeof(string));
    
            var artistUrlSafeNameParameter = artistUrlSafeName != null ?
                new ObjectParameter("ArtistUrlSafeName", artistUrlSafeName) :
                new ObjectParameter("ArtistUrlSafeName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("sp_InsertArtist", artistNameParameter, artistUrlSafeNameParameter);
        }
    
        public virtual int sp_InsertVideo(string iSRC, string title, string urlSafeTitle, Nullable<int> artistID)
        {
            var iSRCParameter = iSRC != null ?
                new ObjectParameter("ISRC", iSRC) :
                new ObjectParameter("ISRC", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var urlSafeTitleParameter = urlSafeTitle != null ?
                new ObjectParameter("UrlSafeTitle", urlSafeTitle) :
                new ObjectParameter("UrlSafeTitle", typeof(string));
    
            var artistIDParameter = artistID.HasValue ?
                new ObjectParameter("ArtistID", artistID) :
                new ObjectParameter("ArtistID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertVideo", iSRCParameter, titleParameter, urlSafeTitleParameter, artistIDParameter);
        }
    
        public virtual int sp_UpdateArtist(Nullable<int> artistID, string artistName, string artistUrlSafeName)
        {
            var artistIDParameter = artistID.HasValue ?
                new ObjectParameter("ArtistID", artistID) :
                new ObjectParameter("ArtistID", typeof(int));
    
            var artistNameParameter = artistName != null ?
                new ObjectParameter("ArtistName", artistName) :
                new ObjectParameter("ArtistName", typeof(string));
    
            var artistUrlSafeNameParameter = artistUrlSafeName != null ?
                new ObjectParameter("ArtistUrlSafeName", artistUrlSafeName) :
                new ObjectParameter("ArtistUrlSafeName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateArtist", artistIDParameter, artistNameParameter, artistUrlSafeNameParameter);
        }
    
        public virtual int sp_UpdateVideo(string iSRC, string title, string urlSafeTitle, Nullable<int> artistID)
        {
            var iSRCParameter = iSRC != null ?
                new ObjectParameter("ISRC", iSRC) :
                new ObjectParameter("ISRC", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var urlSafeTitleParameter = urlSafeTitle != null ?
                new ObjectParameter("UrlSafeTitle", urlSafeTitle) :
                new ObjectParameter("UrlSafeTitle", typeof(string));
    
            var artistIDParameter = artistID.HasValue ?
                new ObjectParameter("ArtistID", artistID) :
                new ObjectParameter("ArtistID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateVideo", iSRCParameter, titleParameter, urlSafeTitleParameter, artistIDParameter);
        }
    }
}
