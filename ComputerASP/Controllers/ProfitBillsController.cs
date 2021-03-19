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
    public class ProfitBillsController : Controller
    {
        private readonly CompContext context = new CompContext();
        // GET: ProfitBills
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
            var profit = from s in context.ProfitBills
                           select s;
            profit = profit.Include(p => p.PurchasePCComponent).Include(p => p.Supplier);
            if (!String.IsNullOrEmpty(SearchString))
            {
                profit = profit.Where(s => s.Supplier.SupplierFirm.Contains(SearchString ));
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(profit.OrderBy(i => i.Supplier.SupplierFirm).ToPagedList(pageNumber, pageSize));
        }

        // GET: ProfitBills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfitBill profit = await context.ProfitBills.FindAsync(id);
            if(profit==null)
            {
                return HttpNotFound();
            }    
            return View(profit);
        }

        // GET: ProfitBills/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm");
            ViewBag.PurchaseComponentId = new SelectList(context.PurchasePCComponents, "PurchaseComponentId ", "Model.ModelName"); 
            return View();
        }

        // POST: ProfitBills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseId,PurchaseComponentId ,SupplierId,UnitPrice,Amount,PurchaseDate,SumPrice")] ProfitBill profit)
        {
            if (ModelState.IsValid)
            {
                context.Entry(profit).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }
           
            ViewBag.PurchaseComponentId = new SelectList(context.PurchasePCComponents, "PurchaseComponentId ", "Model.ModelName", profit.PurchaseComponentId);
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm", profit.SupplierId);
            return View(profit);
        }

        // GET: ProfitBills/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfitBill profit = await context.ProfitBills.FindAsync(id);
            if (profit == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm");
            ViewBag.PurchaseComponentId = new SelectList(context.PurchasePCComponents, "PurchaseComponentId ", "Model.ModelName");
            return View(profit);
        }

        // POST: ProfitBills/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseId,PurchaseComponentId ,SupplierId,UnitPrice,Amount,PurchaseDate,SumPrice")] ProfitBill profit)
        {
            if (ModelState.IsValid)
            {
                context.Entry(profit).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseComponentId = new SelectList(context.PurchasePCComponents, "PurchaseComponentId ", "Model.ModelName", profit.PurchaseComponentId);
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "SupplierFirm", profit.SupplierId);
            return View(profit);
        }

        // GET: PurchasePCComponents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           ProfitBill profit = await context.ProfitBills.FindAsync(id);
            if (profit == null)
            {
                return HttpNotFound();
            }
            return View(profit);
        }
        // POST: PurchasePCComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
          ProfitBill profit= await context.ProfitBills.FindAsync(id);
            context.ProfitBills.Remove(profit);
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
