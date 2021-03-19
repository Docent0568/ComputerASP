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
    public class PurchasePCComponentsController : Controller
    {
        private readonly CompContext context = new CompContext();
        // GET: PurchasePCComponents
        public ActionResult Index(string SearchString, string CurrentFilter, int? page,string client, bool? clientRet)
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
            var purchase = from s in context.PurchasePCComponents
                           select s;
            purchase = purchase.Include(p => p.Component).Include(p => p.Model).Include(p => p.Supplier);
            if (!String.IsNullOrEmpty(SearchString))
            {
                purchase = purchase.Where((s => s.Model.ModelName.Contains(SearchString) || s.Specifications.Contains(SearchString)));
            }
            var GenreLst = new List<string>();
            var GenreQrt = from g in context.PurchasePCComponents
                           orderby g.Component.ComponentName
                           select g.Component.ComponentName;
            var GenreLs = new List<bool>();
            var GenreQr = from a in context.PurchasePCComponents
                          orderby a.Availabity
                          select a.Availabity;
            GenreLst.AddRange(GenreQrt.Distinct());
            GenreLs.AddRange(GenreQr.Distinct());

            if (!String.IsNullOrEmpty(client) && !client.Equals("Все"))
            {
                purchase = purchase.Where(r => r.Component.ComponentName == client);
            }
            if (clientRet != null && !clientRet.Equals("Все"))
            {
                purchase = purchase.Where(r => r.Availabity == clientRet);
            }
            ViewBag.client = new SelectList(GenreLst, "ComponentName");
            ViewBag.clientRet = new SelectList(GenreLs, "Availabity");

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(purchase.OrderBy(e=>e.Component.ComponentName).ToPagedList(pageNumber, pageSize));
        }

        // GET: PurchasePCComponents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchasePCComponent purchase = await context.PurchasePCComponents.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: PurchasePCComponents/Create
        public ActionResult Create()
        {
            ViewBag.ComponentId = new SelectList(context.Components, "ComponentId", "ComponentName");
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm");
            ViewBag.ModelId = new SelectList(context.Models, "ModelId", "ModelName");
            return View();
        }

        // POST: PurchasePCComponents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseComponentId,ComponentId,ModelId,SupplierId,Availabity,Specifications,Price,GuaranteePeriod,DateIssue")] PurchasePCComponent purchase)
        {
            if (ModelState.IsValid)
            {

                context.Entry(purchase).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }
            ViewBag.ComponentId = new SelectList(context.Components, "ComponentId", "ComponentName", purchase.ComponentId);
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm", purchase.SupplierId);
            ViewBag.ModelId = new SelectList(context.Models, "ModelId", "ModelName", purchase.ModelId);
            return View(purchase);
        }

        // GET: PurchasePCComponents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchasePCComponent purchase = await context.PurchasePCComponents.FindAsync(id);
            if (purchase == null)
            {
                HttpNotFound();
            }
            ViewBag.ComponentId = new SelectList(context.Components, "ComponentId", "ComponentName");
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm");
            ViewBag.ModelId = new SelectList(context.Models, "ModelId", "ModelName");
            return View(purchase);
        }
        // POST: Components/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseComponentId,ComponentId,ModelId,SupplierId,Availabity,Specifications,Price,GuaranteePeriod,DateIssue")] PurchasePCComponent purchase)
        {
            if (ModelState.IsValid)
            {
                context.Entry(purchase).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }
            ViewBag.ComponentId = new SelectList(context.Components, "ComponentId", "ComponentName", purchase.ComponentId);
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm", purchase.SupplierId);
            ViewBag.ModelId = new SelectList(context.Models, "ModelId", "ModelName", purchase.ModelId);
            return View(purchase);
        }

        // GET: PurchasePCComponents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchasePCComponent purchasePCComponent = await context.PurchasePCComponents.FindAsync(id);
            if (purchasePCComponent == null)
            {
                return HttpNotFound();
            }
            return View(purchasePCComponent);
        }
        // POST: PurchasePCComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PurchasePCComponent purchasePCComponent = await context.PurchasePCComponents.FindAsync(id);
            context.PurchasePCComponents.Remove(purchasePCComponent);
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
