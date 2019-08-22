using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Assignments.Models.Assign5;

namespace Assignments.Controllers
{
    public class Assign5Controller : Controller
    {
        private EmployeesEntities db = new EmployeesEntities();

        #region "View Employees"
        /// <summary>
        ///GET:  Display employees
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.tblEmployees.ToList());
        }
        #endregion
       
        #region "Employee Details"
        /// <summary>
        /// GET: Get details o employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }
        #endregion

        #region "Add Employee(GET)"
        /// <summary>
        ///GET:  Add new employee
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region "Add Employee(POST)"
        /// <summary>
        /// POST:  Add new employee
        /// </summary>
        /// <param name="tblEmployee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,EmailId")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployees.Add(tblEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmployee);
        }
        #endregion

        #region "Edit Employee Details(GET)"
        /// <summary>
        /// GET: Edit Employee details by their employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }
        #endregion

        #region "Edit Employee Details(POST)"
        /// <summary>
        ///  POST:Edit Employee details 
        /// </summary>
        /// <param name="tblEmployee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Gender,City,EmailId")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmployee);
        }
        #endregion

        #region "Delete Employee"
        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }
        #endregion

        #region "Delete Confirmation"
        /// <summary>
        /// Delete Employee Confirmation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            db.tblEmployees.Remove(tblEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        
        #region "Dispose"
        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }

   
}
