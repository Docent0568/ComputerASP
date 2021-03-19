using ComputerASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ComputerASP.Controllers
{
    public class ModelssController : Controller
    {
        private CompContext context = new CompContext();
        // GET: Models
        public ActionResult Index(string searchString)
        {
            var models = from s in context.Models
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                models = models.Where(s => s.ModelName.Contains(searchString));
            }
            return View(models.ToList());
        }

        // GET: Models/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Model model = await context.Models.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Models/Create
        public ActionResult Create()
        {
            ViewBag.ComponentId = new SelectList(context.Components, "ComponentId", "ComponentName");
            return View();
        }

        // POST: Models/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ModelId,ComponentId,ModelName")] Model model)
        {
            if (ModelState.IsValid)
            {
                context.Entry(model).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }
            ViewBag.ComponentId = new SelectList(context.Components, "ComponentId", "ComponentName", model.ComponentId);
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = await context.Models.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComponentId = new SelectList(context.Components, "ComponentId", "ComponentName", model.ComponentId);
            return View(model);
        }
        // POST: Models/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ModelId , ComponentId ,ModelName")] Model model)
        {
            if (ModelState.IsValid)
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }
            ViewBag.ComponentId = new SelectList(context.Components, "ComponentId", "ComponentName");
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = await context.Models.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Model model = await context.Models.FindAsync(id);
            context.Models.Remove(model);
            await context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Запись удалена";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
