using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_FinalTermExam.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        ASP.NET_FinalTermExam.Models.EmployeeService employeeService = new ASP.NET_FinalTermExam.Models.EmployeeService();
        ASP.NET_FinalTermExam.Models.SelectService selectService = new ASP.NET_FinalTermExam.Models.SelectService();
        public ActionResult Index()
        {
            var EmpData = employeeService.getAllEmp();
            ViewBag.EmpData = EmpData;

            var Titledata = selectService.getTitle();
            ViewBag.Titledata = Titledata;

            return View();
        }

        [HttpPost()]
        public ActionResult Index(ASP.NET_FinalTermExam.Models.Employee postEmp)
        {
            var GetEmpByCondtioin = employeeService.GetEmpByCondtioin(postEmp);
            ViewBag.EmpData = GetEmpByCondtioin;

            var Titledata = selectService.getTitle();
            ViewBag.Titledata = Titledata;

            return View();
        }

        //新增
        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            
            
            return View();
        }
    }
}