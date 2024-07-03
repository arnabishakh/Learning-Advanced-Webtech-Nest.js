using Blogger.DTOs;
using Blogger.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class DashboardController : Controller
    {
        // Conversion methods
        public static post Convert(DashboardDTO c)
        {
            return new post
            {
                pid = c.pid,
                uid = c.uid,
                text = c.text,
                date = c.date,
            };
        }

        public static DashboardDTO Convert(post c)
        {
            return new DashboardDTO
            {
                pid = c.pid,
                uid = c.uid,
                text = c.text,
                date = c.date,
            };
        }

        public static List<DashboardDTO> Convert(List<post> cs)
        {
            var list = new List<DashboardDTO>();
            foreach (var c in cs)
            {
                list.Add(Convert(c));
            }
            return list;
        }

        // Database context
        private bishakhMIDEntities db = new bishakhMIDEntities();

        // GET: Dashboard
        public ActionResult Dashboard()
        {
            var data = db.posts.ToList();
            return View(Convert(data));
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(DashboardDTO s)
        {
            if (ModelState.IsValid)
            {
                var st = Convert(s);
                db.posts.Add(st);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(s);
        }
        // GET: Edit
        public ActionResult Edit(int id)
        {
            var post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var postDto = Convert(post);
            return View(postDto);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(DashboardDTO s)
        {
            if (ModelState.IsValid)
            {
                var updatedPost = db.posts.Find(s.pid);
                if (updatedPost == null)
                {
                    return HttpNotFound();
                }

                // Update properties
                updatedPost.uid = s.uid;
                updatedPost.text = s.text;
                updatedPost.date = s.date;

                db.Entry(updatedPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(s);
        }

        // GET: Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var postDto = Convert(post);
            return View(postDto);
        }
        // POST: Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            db.posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        // GET: Details
        public ActionResult Details(int id)
        {
            var post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var postDto = Convert(post);
            return View(postDto);
        }







    }
}
