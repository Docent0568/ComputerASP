using ComputerASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using System.Net;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace ComputerASP.Controllers
{
    public class WarehouseComponentsController : Controller
    {
        private readonly CompContext context = new CompContext();
        // GET: WarehouseComponents
        public ActionResult Index( int? page, string client, bool? clientRet)
        {
            
            var warehouse = from s in context.WarehouseComponents
                         select s;
            warehouse = warehouse.Include(p => p.ProfitBill);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(warehouse.OrderBy(i => i.Amount).ToPagedList(pageNumber, pageSize));
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseComponent warehouse = await context.WarehouseComponents.FindAsync(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        public ActionResult Create()
        {
            ViewBag.PurchaseId = new SelectList(context.WarehouseComponents, "PurchaseId", "PurchaseId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WarehouseComponentId,PurchaseId,ArrivalDate ,Amount")] WarehouseComponent warehouse)
        {
            if (ModelState.IsValid)
            {
                context.Entry(warehouse).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseId = new SelectList(context.WarehouseComponents, "PurchaseId", "PurchaseId", warehouse.PurchaseId);
            return View(warehouse);
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseComponent warehouse= await context.WarehouseComponents.FindAsync(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseId = new SelectList(context.WarehouseComponents, "PurchaseId", "PurchaseId");
            return View(warehouse);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WarehouseComponentId,PurchaseId ,ArrivalDate ,Amount")] WarehouseComponent warehouse)
        {
            if (ModelState.IsValid)
            {
                context.Entry(warehouse).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseId = new SelectList(context.WarehouseComponents, "PurchaseId", "PurchaseId", warehouse.PurchaseId);
            return View(warehouse);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseComponent warehouse = await context.WarehouseComponents.FindAsync(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
           WarehouseComponent warehouse = await context.WarehouseComponents.FindAsync(id);
            context.WarehouseComponents.Remove(warehouse);
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