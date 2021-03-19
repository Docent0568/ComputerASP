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
    public class SuppliersController : Controller
    {
        private CompContext context = new CompContext();
        // GET: Components
        public ActionResult Index(string searchString, string clientRet)
        {
            var GenreLst = new List<string>();
            var GenreQry = from d in context.Suppliers
                           orderby d.SupplierFirm
                           select d.SupplierFirm;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.clientRet = new SelectList(GenreLst, "SupplierFirm");
            var suppliers = from s in context.Suppliers
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                suppliers = suppliers.Where(s => s.SupplierFirm.Contains(searchString) ||
                 s.CityDelivery.Contains(searchString) || s.AddressDelivery.Contains(searchString));
            }
            if(!String.IsNullOrEmpty(clientRet) && !clientRet.Equals("Все"))
            {
                suppliers = suppliers.Where(r => r.SupplierFirm == clientRet);
            }    
            return View(suppliers);
        }

        // GET: Components/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = await context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Components/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Components/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SupplierId,SupplierFirm,DateDelivery,CityDelivery,AddressDelivery,PhoneDelivery")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                context.Entry(supplier).State = EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Components/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Supplier supplier = await context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Components/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SupplierId,SupplierFirm,DateDelivery,CityDelivery,AddressDelivery,PhoneDelivery")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                context.Entry(supplier).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Components/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = await context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Supplier supplier = await context.Suppliers.FindAsync(id);
            context.Suppliers.Remove(supplier);
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