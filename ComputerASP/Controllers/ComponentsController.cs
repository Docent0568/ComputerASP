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
    public class ComponentsController : Controller
    {
        private CompContext context = new CompContext();
        // GET: Components
        public ActionResult Index(string searchString)
        {
            var components = from s in context.Components
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                components = components.Where(s => s.ComponentName.Contains(searchString));
            }
            return View(components.ToList());
        }

        // GET: Components/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = await context.Components.FindAsync(id);
            if(component==null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // GET: Components/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Components/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ComponentId,ComponentName")] Component component)
        {
            if(ModelState.IsValid)
            {
                context.Entry(component).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }
            return View(component);
        }

        // GET: Components/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = await context.Components.FindAsync(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // POST: Components/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ComponentId,ComponentName")] Component component)
        {
            if (ModelState.IsValid)
            {
                context.Entry(component).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }
            return View(component);
        }

        // GET: Components/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = await context.Components.FindAsync(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Component component = await context.Components.FindAsync(id);
            context.Components.Remove(component);
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
