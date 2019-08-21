using Assignments.Models.Assign3;
using Assignments.Repository;
using System.Web.Mvc;

namespace Assignments.Controllers
{
    public class Assign3Controller : Controller
    {
        #region "Get employee Details"
        /// <summary>
        /// Get employee details from table employee
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllEmpDetails()
        {
            EmpRepository empRepository = new EmpRepository();
            ModelState.Clear();
            return View(empRepository.GetAllEmployees());
        }
        #endregion

        #region "Add new employee"
        /// <summary>
        /// GET: Add new employee into the table employee
        /// </summary>
        /// <returns></returns>
        public ActionResult AddEmployee()
        {
            return View();
        }
        #endregion

        #region "Add new employee(POST)"
        /// <summary>
        /// POST: Add new employee into the table employee 
        /// </summary>
        /// <param name="Emp"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddEmployee(EmployeeDetails Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepository empRepository = new EmpRepository();
                    if (empRepository.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region "Edit employee details(GET)"
        /// <summary>
        /// GET: Edit employee details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditEmpDetails(int id)
        {
            EmpRepository empRepository = new EmpRepository();
            return View(empRepository.GetAllEmployees().Find(Emp => Emp.Empid == id));
        }
        #endregion

        #region "Edit employee details(POST)"
        /// <summary>
        /// POST: Edit employee details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditEmpDetails(int id, EmployeeDetails obj)
        {
            try
            {
                EmpRepository empRepository = new EmpRepository();
                empRepository.UpdateEmployee(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region "Delete Employee"
        /// <summary>
        /// GET: Delete employee details by their empId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                EmpRepository empRepository = new EmpRepository();
                if (empRepository.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";
                }
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }
        #endregion        
    }
}
