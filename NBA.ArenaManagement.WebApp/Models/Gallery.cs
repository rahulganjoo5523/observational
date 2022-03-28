using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA.ArenaManagement.WebApp.Models
{
    public class Gallery
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedDate { get; set; }
        public string URL { get; set; }
    }
}