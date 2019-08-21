using System.Linq;
using System.Web.Mvc;
using Assignments.Models.Assign5;

namespace Assignments.Controllers
{
    public class Assign11Controller : Controller
    {
        private EmployeesEntities db = new EmployeesEntities();

        #region "Index"
        /// <summary>
        /// Display employees list
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.tblEmployees.ToList());
        }
        #endregion
        
        #region "Check email already exist"
        /// <summary>
        /// Check if duplicate email exist
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        public JsonResult IsUserEmailAvailable(string EmailId)
        {
            return Json(!db.tblEmployees.Any(user => user.EmailId == EmailId), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region "Add Employee(GET)"
        /// <summary>
        ///GET :  Add employee 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region "Add Employee(POST)"
        /// <summary>
        /// Add Employee
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

        #region "Disposing"
        /// <summary>
        /// Disposing
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
