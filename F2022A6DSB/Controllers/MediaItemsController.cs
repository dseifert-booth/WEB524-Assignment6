using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Win32;

namespace F2022A6DSB.Controllers
{
    public class MediaItemsController : Controller
    {

        Manager m = new Manager();

        // GET: MediaItem
        public ActionResult Index()
        {
            return View();
        }

        // GET: MediaItem/5
        [Route("mediaitem/{stringId}")]
        public ActionResult Details(string stringId = "")
        {
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(o.Content, o.ContentType);
            }
        }

        [Route("mediaitem/{stringId}/download")]
        public ActionResult DetailsDownload(string stringId = "")
        {
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                string extension;
                RegistryKey key;
                object value;

                key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + o.ContentType, false);
                value = (key == null) ? null : key.GetValue("Extension", null);
                extension = (value == null) ? string.Empty : value.ToString();

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = $"img-{stringId}{extension}",
                    Inline = false
                };
                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(o.Content, o.ContentType);
            }
        }
    }
}