using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F2022A6DSB.Models;

namespace F2022A6DSB.Controllers
{
    [Authorize]
    public class TracksController : Controller
    {
        private Manager m = new Manager();

        // GET: Tracks
        public ActionResult Index()
        {
            return View(m.TrackGetAll());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var track = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (track == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(track);
            }
        }

        [Authorize(Roles = "Clerk")]
        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            var obj = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (obj == null)
            {
                return HttpNotFound();
            }
            else
            {
                var formObj = m.mapper.Map<TrackBaseViewModel, TrackEditAudioFormViewModel>(obj);

                return View(formObj);
            }
        }

        [Authorize(Roles = "Clerk")]
        // POST: Tracks/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, TrackEditAudioViewModel track)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = track.Id });
            }

            if (id.GetValueOrDefault() != track.Id)
            {
                return RedirectToAction("Index");
            }

            var editedItem = m.TrackEditAudio(track);

            if (editedItem == null)
            {
                return RedirectToAction("Edit", new { id = track.Id });
            }
            else
            {
                return RedirectToAction("Details", new { id = track.Id });
            }
        }

        [Authorize(Roles = "Clerk")]
        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else return View(itemToDelete);
        }

        [Authorize(Roles = "Clerk")]
        // POST: Tracks/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.TrackDelete(id.GetValueOrDefault());

            return RedirectToAction("Index");
        }

        // GET: Photo/5
        [Route("clip/{id}")]
        public ActionResult GetAudioClip(int? id)
        {
            var o = m.TrackAudioGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(o.Audio, o.AudioContentType);
            }
        }
    }
}