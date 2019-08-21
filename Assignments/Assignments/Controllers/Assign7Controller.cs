using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Assignments.Models.Assign5;

namespace Assignments.Controllers
{
    public class Assign7Controller : Controller
    {
        private EmployeesEntities db = new EmployeesEntities();

        #region "Display user comments"
        /// <summary>
        /// Display user comment
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.tblComments.ToList());
        }
        #endregion

        #region "Form to get user comments"
        /// <summary>
        /// GET : Form to get user comments
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region "Form to get user comments and prevent XSS Attacks"
        /// <summary>
        /// POST : Form which takes user comment , prevent XSS Attacks and allow HTML tags(<b>,<u>,<i>)
        /// </summary>
        /// <param name="tblComment"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Comments")] tblComment tblComment)
        {
            StringBuilder sbComments = new StringBuilder();

            // Encode the text that is coming from comments textbox
            sbComments.Append(HttpUtility.HtmlEncode(tblComment.Comments));

            // Only decode bold and underline tags
            sbComments.Replace("&lt;b&gt;", "<b>");
            sbComments.Replace("&lt;/b&gt;", "</b>");
            sbComments.Replace("&lt;u&gt;", "<u>");
            sbComments.Replace("&lt;/u&gt;", "</u>");         
            tblComment.Comments = sbComments.ToString();

            // HTML encode the text that is coming from name textbox
            string strEncodedName = HttpUtility.HtmlEncode(tblComment.Name);
            tblComment.Name = strEncodedName;

            if (ModelState.IsValid)
            {
                db.tblComments.Add(tblComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblComment);
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
