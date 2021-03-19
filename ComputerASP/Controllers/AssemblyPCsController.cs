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
    public class AssemblyPCsController : Controller
    {
        private readonly CompContext context = new CompContext();
        // GET: AssemblyPCs
        public ActionResult Index(string SearchString)
        {
            
            var assembly = from s in context.AssemblyPcs
                          select s;
            if (!String.IsNullOrEmpty(SearchString))
            {
                assembly = assembly.Where(s => s.PCName.Contains(SearchString));
            }

            return View(assembly.ToList());
        }


        // GET: AssemblyPCs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssemblyPc assembly = await context.AssemblyPcs.FindAsync(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // GET: AssemblyPCs/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: AssemblyPCs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AssemblyPCId,CharacteristicPC,DateAssemblyPC,Amount,AssemblyPrice,PCName ")] AssemblyPc assembly)
        {
            if (ModelState.IsValid)
            {
                context.Entry(assembly).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }

            return View(assembly);
        }

        // GET: AssemblyPCs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssemblyPc assembly = await context.AssemblyPcs.FindAsync(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // POST: AssemblyPCs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AssemblyPCId,CharacteristicPC,DateAssemblyPC,Amount,AssemblyPrice,PCName ")] AssemblyPc assembly)
        {
            if (ModelState.IsValid)
            {
                context.Entry(assembly).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }
            return View(assembly);
        }

        // GET: AssemblyPCs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssemblyPc assembly = await context.AssemblyPcs.FindAsync(id);
            if (assembly== null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // POST: AssemblyPCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AssemblyPc assembly = await context.AssemblyPcs.FindAsync(id);
            context.AssemblyPcs.Remove(assembly);
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
