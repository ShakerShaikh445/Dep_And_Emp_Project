using System.Data;
using System.Data.SqlClient;

namespace Dep_And_Emp_Project.Models
{
    public class DAL
    {
        public Response GetAllEmpoyees(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employees",connection);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            List<Employees> ListEmployees = new List<Employees>();
            if(dt.Rows.Count > 0 )
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Employees employees = new Employees();
                    employees.EId = Convert.ToInt32(dt.Rows[i]["EId"]);
                    employees.EName = Convert.ToString(dt.Rows[i]["EName"]);
                    employees.EGender = Convert.ToString(dt.Rows[i]["EGender"]);
                    employees.Phone = Convert.ToInt64(dt.Rows[i]["Phone"]);
                    employees.DepNo = Convert.ToInt32(dt.Rows[i]["DepNo"]);

                    ListEmployees.Add(employees);
                }
            }
            if(ListEmployees.Count>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.istEmployees = ListEmployees;
            }
            else 
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.istEmployees = null;
            }
            return response;
        }

        public Response GetAllEmpoyeesById(SqlConnection connection, int Id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employees where EId = '"+Id+"'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
           Employees Employees = new Employees();
            if (dt.Rows.Count > 0)
            {
                


                    Employees employees = new Employees();
                    employees.EId = Convert.ToInt32(dt.Rows[0]["EId"]);
                    employees.EName = Convert.ToString(dt.Rows[0]["EName"]);
                    employees.EGender = Convert.ToString(dt.Rows[0]["EGender"]);
                    employees.Phone = Convert.ToInt64(dt.Rows[0]["Phone"]);
                    employees.DepNo = Convert.ToInt32(dt.Rows[0]["DepNo"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.Employees = employees;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.Employees = null;
            }
            return response;
        }



        public Response AddEmpoyees(SqlConnection connection,Employees employees)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Employees(EName, EGender, Phone, DepNo) values ('"+ employees.EName + "','"+ employees.EGender + "','"+ employees.Phone + "','"+ employees.DepNo + "')",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Employee Added...";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";
            }
            return response;
        }



        public Response UpdateEmpoyees(SqlConnection connection, Employees employees)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update Employees set EName = '" + employees.EName + "', EGender = '" + employees.EGender + "', Phone = '" + employees.Phone + "', DepNo = '" + employees.DepNo + "'Where EId = '"+ employees.EId +"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Employee Updated...";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Updated";
            }
            return response;
        }



        public Response DeleteEmployee(SqlConnection connection,int id) 
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand("Delete From Employees where EId = '"+id+"'",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if(i > 0) 
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Deleted ... ";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " Employee Not Deleted ... ";
            }


            return response;
        }
    }

}
