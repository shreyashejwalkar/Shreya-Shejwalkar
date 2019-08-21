using Assignments.Models.Assign2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Assignments.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        /// <summary>
        /// Tables the specified emp.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="emp">The emp.</param>
        /// <returns></returns>
        public static HtmlString Table(this HtmlHelper helper, List<Employee> emp)
        {
            HtmlTable ht = new HtmlTable();
            //Get the columns
            HtmlTableRow htColumnsRow = new HtmlTableRow();

            typeof(Employee).GetProperties().Select(prop =>
            {
                HtmlTableCell htCell = new HtmlTableCell();
                htCell.InnerText = prop.Name;
                return htCell;
            }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
            ht.Rows.Add(htColumnsRow);
            //Get the remaining rows
            emp.ForEach(delegate (Employee obj)
            {
                HtmlTableRow htRow = new HtmlTableRow();
                obj.GetType().GetProperties().ToList().ForEach(delegate (PropertyInfo prop)
                {
                    HtmlTableCell htCell = new HtmlTableCell();
                    // htCell.InnerText = prop.GetValue(obj, null).ToString();
                    htCell.InnerText = prop.GetValue(obj, null).ToString();
                    htRow.Cells.Add(htCell);
                });
                ht.Rows.Add(htRow);
            });

            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(tw);

            ht.RenderControl(hw);

            String HTMLContent = sb.ToString();

            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Tables the specified data.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="Data">The data.</param>
        /// <param name="class">The class.</param>
        /// <returns></returns>
        public static IHtmlString Table(this HtmlHelper helper, List<Employee> Data, string @class)
        {
            HtmlTable ht = new HtmlTable();
            ht.Attributes.Add("class", @class);
            //Get the columns
            HtmlTableRow htColumnsRow = new HtmlTableRow();

            typeof(Employee).GetProperties().Select(prop =>
            {
                HtmlTableCell htCell = new HtmlTableCell();
                htCell.InnerText = prop.Name;
                return htCell;
            }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
            ht.Rows.Add(htColumnsRow);
            //Get the remaining rows
            Data.ForEach(delegate (Employee obj)
            {
                HtmlTableRow htRow = new HtmlTableRow();
                obj.GetType().GetProperties().ToList().ForEach(delegate (PropertyInfo prop)
                {
                    HtmlTableCell htCell = new HtmlTableCell();
                    htCell.InnerText = prop.GetValue(obj, null).ToString();
                    htRow.Cells.Add(htCell);
                });
                ht.Rows.Add(htRow);
            });

            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(tw);

            ht.RenderControl(hw);

            String HTMLContent = sb.ToString();

            return new MvcHtmlString(sb.ToString());

        }
    }
}