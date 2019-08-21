using Assignments.Models.Assign2;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignments.Controllers
{
    public class Assign2Controller : Controller
    {
        #region "Employees list"
        /// <summary>
        /// Display the list of employees 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.ToList();
            return View(employees);
        }
        #endregion

        #region "Employees Details"
        /// <summary>
        /// Get the employee details by their employeeId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeId == id);
            return View(employee);
        }
        #endregion
    }
}