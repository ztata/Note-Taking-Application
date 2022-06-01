using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteTakingApp.Models;

namespace NoteTakingApp.Controllers
{
    public class NotesController : Controller
    {
        // GET: NotesController
        public ActionResult Index()
        {
            List<Notes> result = null;
            using (NotesContext context = new NotesContext())
            {
                result = context.Notes.ToList();
            }
                return View(result);
        }

        // GET: NotesController/Details/5
        public ActionResult Details(int id)
        {
            Notes result = null;
            using (NotesContext context = new NotesContext())
            {
                result = context.Notes.Where(x => x.Id == id).First();
            }
                return View(result);
        }

        // GET: NotesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                using (NotesContext context = new NotesContext())
                {
                    Notes note = new Notes();
                    note.NoteTitle = collection["NoteTitle"];
                    note.Author = collection["Author"];
                    note.NoteBody = collection["NoteBody"];
                    note.DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                    context.Notes.Add(note);
                    context.SaveChanges();
                }
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: NotesController/Edit/5
        public ActionResult Edit(int id)
        {
            Notes result = null;
            using (NotesContext context = new NotesContext())
            {
                result = context.Notes.Where(x => x.Id == id).First();
            }
            return View(result);
        }

        // POST: NotesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                using (NotesContext context = new NotesContext())
                {
                    Notes note = context.Notes.Where(x => x.Id == id).First();
                    note.NoteTitle = collection["NoteTitle"];
                    note.Author = collection["Author"];
                    note.NoteBody = collection["NoteBody"];
                    note.DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                    context.Notes.Update(note);
                    context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: NotesController/Delete/5
        public ActionResult Delete(int id)
        {
            Notes result = null;
            using (NotesContext context = new NotesContext())
            {
                result = context.Notes.Where(x => x.Id == id).First();
            }
                return View(result);
        }

        // POST: NotesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Notes result = null;
                using (NotesContext context = new NotesContext())
                {
                    result = context.Notes.Where(x => x.Id == id).First();
                    context.Remove(result);
                    context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
