using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalTermExam.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmpName { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ord { get; set; }
    }
}