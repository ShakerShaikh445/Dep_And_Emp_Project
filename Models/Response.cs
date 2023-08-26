namespace Dep_And_Emp_Project.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage{ get; set; }
        public Employees Employees { get; set; }
        public List<Employees> istEmployees { get; set; }

    }
}
