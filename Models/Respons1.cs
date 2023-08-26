namespace Dep_And_Emp_Project.Models
{
    public class Respons1
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public Employees? Employees { get; set; }
        public List<Department> listDeparment { get; set; }
    }
}
