using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Assignments.Models.Assign2;

namespace Assignments.Controllers
{
    public class Assign6Controller : Controller
    {
        #region "Index"
        /// <summary>
        /// To display employees list
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.ToList();
            return View(employees);
        }
        #endregion
    }
}