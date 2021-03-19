using ComputerASP.Models;
using PagedList;
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
    public class PCSalesController : Controller
    {
        private readonly CompContext context = new CompContext();
        // GET: PCSales
        public ActionResult Index(string SearchString)
        {

            var pCSales = from s in context.PCSales
                           select s;
            if (!String.IsNullOrEmpty(SearchString))
            {
                pCSales = pCSales.Where(s => s.PCName.Contains(SearchString));
            }

            return View(pCSales.ToList());
        }

        // GET: PCSales/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCSale pCSale = await context.PCSales.FindAsync(id);
            if (pCSale == null)
            {
                return HttpNotFound();
            }
            return View(pCSale);
        }

        // GET: PCSales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PCSales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PCSaleId,PCName,PricePC,SellDate,GuaranteePeriod ,PCStatus")] PCSale pCSale)
        {
            if (ModelState.IsValid)
            {
                context.Entry(pCSale).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }

            return View(pCSale);
        }

        // GET: PCSales/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           PCSale pCSale= await context.PCSales.FindAsync(id);
            if (pCSale == null)
            {
                return HttpNotFound();
            }
            return View(pCSale);
        }

        // POST: PCSales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PCSaleId,PCName,PricePC,SellDate,GuaranteePeriod ,PCStatus")] PCSale pCSale)
        {
            if (ModelState.IsValid)
            {
                context.Entry(pCSale).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }
            return View(pCSale);
        }

        // GET: PCSales/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCSale pCSale = await context.PCSales.FindAsync(id);
            if (pCSale == null)
            {
                return HttpNotFound();
            }
            return View(pCSale);
        }


        // POST: PCSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PCSale pCSale = await context.PCSales.FindAsync(id);
            context.PCSales.Remove(pCSale);
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
