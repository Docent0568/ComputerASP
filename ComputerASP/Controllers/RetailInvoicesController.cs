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
    public class RetailInvoicesController : Controller
    {
        private readonly CompContext context = new CompContext();
        // GET: RetailInvoices
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
            var reteil = from s in context.RetailInvoices
                         select s;
            reteil = reteil.Include(p => p.WarehouseComponent).Include(p => p.Employee);
            if (!String.IsNullOrEmpty(SearchString))
            {
                reteil = reteil.Where(s => s.Employee.FIO.Contains(SearchString));
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(reteil.OrderBy(i => i.Employee.FIO).ToPagedList(pageNumber, pageSize));
        }

        // GET: RetailInvoices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetailInvoice retail = await context.RetailInvoices.FindAsync(id);
            if (retail== null)
            {
                return HttpNotFound();
            }
            return View(retail);
        }

        // GET: RetailInvoices/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(context.Employees, "EmployeeId", "FIO");
            ViewBag.WarehouseComponentId = new SelectList(context.WarehouseComponents, "WarehouseComponentId", "WarehouseComponentId");
            return View();
        }

        // POST: RetailInvoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SaleId,WarehouseComponentId ,UnitPrice,Amount,EmployeeId,SaleDate,SumPrice")] RetailInvoice retail)
        {
            if (ModelState.IsValid)
            {
                context.Entry(retail).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(context.Employees, "EmployeeId", "FIO",retail.EmployeeId);
            ViewBag.WarehouseComponentId = new SelectList(context.WarehouseComponents, "WarehouseComponentId", "WarehouseComponentId",retail.WarehouseComponentId);
            return View(retail);
        }

        // GET: RetailInvoices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetailInvoice retail = await context.RetailInvoices.FindAsync(id);
            if (retail == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(context.Employees, "EmployeeId", "FIO");
            ViewBag.WarehouseComponentId = new SelectList(context.WarehouseComponents, "WarehouseComponentId", "WarehouseComponentId");
            return View(retail);
        }
        // POST: RetailInvoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = " ReadyPCId,SupplierId,PurchasePrice,PCName,CharacteristicPC,SaleDate,SumPrice")] RetailInvoice retail)
        {
            if (ModelState.IsValid)
            {
                context.Entry(retail).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(context.Employees, "EmployeeId", "FIO", retail.EmployeeId);
            ViewBag.WarehouseComponentId = new SelectList(context.WarehouseComponents, "WarehouseComponentId", "WarehouseComponentId", retail.WarehouseComponentId);
            return View(retail);
        }
        // GET: RetailInvoices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           RetailInvoice retail = await context.RetailInvoices.FindAsync(id);
            if (retail== null)
            {
                return HttpNotFound();
            }
            return View(retail);
        }

        // POST: RetailInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RetailInvoice retail = await context.RetailInvoices.FindAsync(id);
            context.RetailInvoices.Remove(retail);
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
