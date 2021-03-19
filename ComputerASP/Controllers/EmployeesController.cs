using ComputerASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace ComputerASP.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CompContext context = new CompContext();
        // GET: Employees
        public ActionResult Index(string searchString,string clientRet)
        {
            var GenreLst = new List<string>();
            var GenreQry = from d in context.Employees
                           orderby d.FIO
                           select d.FIO;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.clientRet = new SelectList(GenreLst, "FIO");

            var employee = from e in context.Employees
                           select e;
            if(!String.IsNullOrEmpty(searchString))
            {
                employee = employee.Where(s => s.FIO.Contains(searchString) || s.City.Contains(searchString) || s.Address.Contains(searchString));
            }
            if(!String.IsNullOrEmpty(clientRet) && !clientRet.Equals("Все"))
            {
                employee = employee.Where(e => e.FIO == clientRet);
            }
            return View(employee);
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee =  await context.Employees.FindAsync(id);
            if (employee == null) 
            {
                return HttpNotFound();
            }
            return View(employee); 
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmpolyeeId,FIO,City,Address,Phone,Position")] Employee employee)
        {
           if(ModelState.IsValid)
            {
                context.Entry(employee).State =EntityState.Added;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись добавлена";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await context.Employees.FindAsync(id);
            if(employee==null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "EmpolyeeId,FIO,City,Address,Phone,Position")] Employee employee)
        {
            if(ModelState.IsValid)
            {
                context.Entry(employee).State = EntityState.Modified;
                await context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Запись сохранена";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await context.Employees.FindAsync(id);
            if(employee==null)
            {
                return HttpNotFound();
            }
            return View(employee);

        }

        // POST: Employees/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await context.Employees.FindAsync(id);
            context.Employees.Remove(employee);
            context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Запись удалена";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);

        }
    }
}
