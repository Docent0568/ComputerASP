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
    public class ReadyPCsController : Controller
    {
        private readonly CompContext context = new CompContext();
        // GET: ReadyPC
        public ActionResult Index(string SearchString, string CurrentFilter, int? page, string client, bool? clientRet)
        {
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;
            var readyPC = from s in context.ReadyPCs
                         select s;
            readyPC = readyPC.Include(p => p.Supplier);
            if (!String.IsNullOrEmpty(SearchString))
            {
                readyPC = readyPC.Where(s => s.PCName.Contains(SearchString));
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(readyPC.OrderBy(i => i.PCName).ToPagedList(pageNumber, pageSize));
        }

        // GET: ReadyPC/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReadyPC readyPC= await context.ReadyPCs.FindAsync(id);
            if (readyPC == null)
            {
                return HttpNotFound();
            }
            return View(readyPC);
        }

        // GET: ReadyPC/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm");
            return View();
        }

        // POST: ReadyPC/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = " ReadyPCId,SupplierId,PurchasePrice,PCName,CharacteristicPC,Amount")] ReadyPC readyPC)
        {
            if (ModelState.IsValid)
            {
                context.Entry(readyPC).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }

            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm",readyPC.SupplierId);
            return View(readyPC);
        }

        // GET: ReadyPC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReadyPC readyPC= await context.ReadyPCs.FindAsync(id);
            if (readyPC == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm");
            return View(readyPC);
        }

        // POST: ReadyPC/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = " ReadyPCId,SupplierId,PurchasePrice,PCName,CharacteristicPC,Amount,")] ReadyPC readyPC)
        {
            if (ModelState.IsValid)
            {
                context.Entry(readyPC).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm",readyPC.SupplierId);
            return View(readyPC);
        }

        // GET: ReadyPC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReadyPC readyPC= await context.ReadyPCs.FindAsync(id);
            if (readyPC == null)
            {
                return HttpNotFound();
            }
            return View(readyPC);
        }

        // POST: ReadyPC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
           ReadyPC readyPC = await context.ReadyPCs.FindAsync(id);
            context.ReadyPCs.Remove(readyPC);
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
