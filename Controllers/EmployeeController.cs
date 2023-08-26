using Dep_And_Emp_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Dep_And_Emp_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _config;
        public EmployeeController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetAllEmpoyees")]

        public Response GetAllEmpoyees()
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllEmpoyees(con);
            return response;
        }



        [HttpGet]
        [Route("GetAllEmpoyeesById/{id}")]

        public Response GetAllEmpoyeesById(int id)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllEmpoyeesById(con,id);
            return response;
        }



        [HttpPost]
        [Route("AddEmpoyees")]
        public Response AddEmpoyees(Employees employees) 
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal =new DAL();
            response = dal.AddEmpoyees(con, employees);

            return response;
        }




        [HttpPut]
        [Route("UpdateEmpoyees")]
        public Response UpdateEmpoyees(Employees employees)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateEmpoyees(con, employees);

            return response;
        }


        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public Response DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteEmployee(con, id);
            return response;
        }



        [HttpGet]
        [Route("GetAllDepartment")]

        public Response GetAllDepartment()
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Respons1 res = new Respons1();
            DAL2 dal = new DAL2();
            res = dal.GetAllDepartment(con);
            return res;
        }



        [HttpGet]
        [Route("GetAllEmpoyeesById/{id}")]

        public Response GetAllDepartmentById(int id)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Respons1 res = new Respons1();
            DAL2 dal = new DAL2();
            res = dal.GetAllDepartmentById(con, id);
            return res;
        }




        [HttpPost]
        [Route("AddEmpoyees")]
        public Response AddDepartment(Department department)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Respons1 res = new Respons1();
            DAL2 dal = new DAL2();
            res = dal.AddDepartment(con, department);

            return res;
        }




        [HttpPut]
        [Route("UpdateEmpoyees")]
        public Response UpdateDepartment(Department department)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Respons1 res = new Respons1();
            DAL2 dal = new DAL2();
            res = dal.UpdateDepartment(con, department);

            return res;
        }




        [HttpDelete]
        [Route("DeleteDepartment/{id}")]
        public Response DeleteDepartment(int id, Response res)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("CrudConnection").ToString());
            Respons1 Resp = new Respons1();
            DAL2 dal = new DAL2();
            Resp = dal.DeleteDepartment(con, id);
            return Resp;
        }
    }
}
