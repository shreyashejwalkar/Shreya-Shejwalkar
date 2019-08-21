using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Assignments.Models.Assign5;
using PagedList;

namespace Assignments.Controllers
{
    public class Assign9Controller : Controller
    {
        private EmployeesEntities db = new EmployeesEntities();

        #region "Index View"
        /// <summary>
        /// Search by Department Location,Name , Sort by location and name and Pagination functionality
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public ActionResult Index(string search, int? page, string sortBy)
        {
            ViewBag.SortNameParameter = String.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.SortLocationParameter = String.IsNullOrEmpty(sortBy) ? "Location desc" : "";
            var departments = db.DepartmentDetails1.AsQueryable();

            switch (sortBy)
            {
                case "Name desc":
                    departments = departments.OrderByDescending(x => x.DepName);
                    break;
                case "Location desc":
                    departments = departments.OrderByDescending(x => x.DepLocation);
                    break;

                default:
                    departments = departments.OrderBy(x => x.DepName);
                    break;
            }
            return View(departments.Where(x => x.DepName.StartsWith(search) || x.DepLocation.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
        }
        #endregion

        #region "Delete Department"
        /// <summary>
        /// Delete Departments by checking checkbox
        /// </summary>
        /// <param name="employeeIdsToDelete"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        {
            var departmentList = db.DepartmentDetails1.Where(x => employeeIdsToDelete.Contains(x.DepId)).ToList();

            foreach (var item in departmentList)
            {
                db.DepartmentDetails1.Remove(item);
            }
            db.SaveChanges();

            return RedirectToAction("Index");

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
