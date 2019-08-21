using Assignments.Models.Assign3;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Assignments.Repository
{
    public class EmpRepository
    {
        private SqlConnection con;
        #region "Connection"
        /// <summary>
        /// Handle connection related activities
        /// </summary>
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeesDataConnectionString"].ToString();
            con = new SqlConnection(constr);
        }
        #endregion

        #region "Add employee"
        /// <summary>
        /// To Add Employee details 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeDetails obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@JobName", obj.JobName);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        #region "Get Employee details"
        /// <summary>
        /// view employee details with generic list 
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDetails> GetAllEmployees()
        {
            connection();
            List<EmployeeDetails> EmpList = new List<EmployeeDetails>();
            SqlCommand com = new SqlCommand("GetEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new EmployeeDetails
                    {
                        Empid = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        JobName = Convert.ToString(dr["JobName"])
                    }
                    );
            }
            return EmpList;
        }
        #endregion


        #region "Update Employee"
        /// <summary>
        /// Update Employee details
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateEmployee(EmployeeDetails obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.Empid);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@JobName", obj.JobName);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region "Delete Employee"
        /// <summary>
        /// delete Employee details 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteEmployee(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
