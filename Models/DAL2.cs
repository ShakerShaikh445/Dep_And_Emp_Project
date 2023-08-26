using System.Data.SqlClient;
using System.Data;

namespace Dep_And_Emp_Project.Models
{
    public class DAL2
    {

        public Respons1 GetAllDepartment(SqlConnection connection)
        {
            Respons1 response = new Respons1();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) as  count ,B.DepNo from Employees as A inner join DepartmentInfomation  as B on  A.DepNo = B.DepNo  GROUP BY A.DepNo", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Department> ListDepartment = new List<Department>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Department deparment = new Department();
                    deparment.DepNo = Convert.ToInt32(dt.Rows[i]["DepNo"]);
                    deparment.DName = Convert.ToString(dt.Rows[i]["DName"]);
                    deparment.DEmp = Convert.ToInt32(dt.Rows[i]["DEmp"]);
                    deparment.InChargeName = Convert.ToString(dt.Rows[i]["InChargeName"]);


                    ListDepartment.Add(deparment);
                }
            }
            if (ListDepartment.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listDeparment = ListDepartment;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
               
            }
            return response;
        }

        public Respons1 GetAllDepartmentById(SqlConnection connection, int Id)
        {
            Respons1 response = new Respons1();
            SqlDataAdapter da = new SqlDataAdapter("select * from DepartmentInfomation where DepNo ='" + Id + "'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Department department = new Department();
            if (dt.Rows.Count > 0)
            {



                Department deparment = new Department();
                deparment.DepNo = Convert.ToInt32(dt.Rows[0]["DepNo"]);
                deparment.DName = Convert.ToString(dt.Rows[0]["DName"]);
                deparment.DEmp = Convert.ToInt32(dt.Rows[0]["DEmp"]);
                deparment.InChargeName = Convert.ToString(dt.Rows[0]["InChargeName"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
               
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
               
            }
            return response;
        }



        public Respons1 AddDepartment(SqlConnection connection, Department department)
        {
            Respons1 response = new Respons1();
            SqlCommand cmd = new SqlCommand("INSERT INTO DepartmentInfomation(DepNo, DName, DEmp, InChargeName) values ('" + department.DepNo + "','" + department.DName + "','" + department.DEmp + "','" + department.InChargeName + "')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Department Added...";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";
            }
            return response;
        }



        public Respons1 UpdateDepartment(SqlConnection connection, Department department)
        {
            Respons1 response = new Respons1();
            SqlCommand cmd = new SqlCommand("Update DepartmentInfomation set DName = '" + department.DName + "', DEmp = '" + department.DEmp + "', InChargeName = '" + department.InChargeName + "', Where DepNo = '" + department.DepNo + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Department Updated...";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Updated";
            }
            return response;
        }



        public Respons1 DeleteDepartment(SqlConnection connection, int id)
        {
            Respons1 response = new Respons1();

            SqlCommand cmd = new SqlCommand("Delete From DepartmentInfomation where DepNo = '" + id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Department Deleted ... ";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " Department Not Deleted ... ";
            }


            return response;
        }
    }
}
