using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F2022A6DSB.Models;

namespace F2022A6DSB.Controllers
{
    [Authorize]
    public class ArtistsController : Controller
    {
        private Manager m = new Manager();

        // GET: Artists
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var artist = m.ArtistGetByIdWithMediaInfo(id.GetValueOrDefault());

            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(artist);
            }
        }

        [Authorize(Roles = "Coordinator")]
        // GET: Artist/{id}/AddAlbum
        [Route("Artist/{id}/AddAlbum")]
        public ActionResult AddAlbum(int? id)
        {
            var artist = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Create a form
                var form = new AlbumAddFormViewModel();
                form.KnownArtist = artist.Name;

                form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                return View(form);
            }
        }

        [Authorize(Roles = "Coordinator")]
        // GET: Artist/{id}/AddAlbum
        [Route("Artist/{id}/AddAlbum")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddAlbum(AlbumAddViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.AlbumAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", "Albums", new { id = addedItem.Id });
            }
        }

        [Authorize(Roles = "Coordinator")]
        // GET: Artists/5/AddMediaItem
        [Route("artists/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id)
        {
            var o = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new MediaItemAddFormViewModel();
                
                form.ArtistId = o.Id;
                form.ArtistInfo = $"{o.Name}";

                return View(form);
            }
        }

        [Authorize(Roles = "Coordinator")]
        // POST: Artists/5/AddMediaItem
        [HttpPost]
        [Route("artists/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id, MediaItemAddViewModel newItem)
        {
            if (!ModelState.IsValid && id.GetValueOrDefault() == newItem.ArtistId)
            {
                return View(newItem);
            }

            var addedItem = m.MediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }

        [Authorize(Roles = "Executive")]
        // GET: Artists/Create
        public ActionResult Create()
        {
            // Create a form
            var form = new ArtistAddFormViewModel();

            form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

            return View(form);
        }

        [Authorize(Roles = "Executive")]
        // POST: Artists/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(ArtistAddViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.ArtistAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }
    }
}