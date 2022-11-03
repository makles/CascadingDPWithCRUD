using CascadingDPWithCRUD.DAL;
using CascadingDPWithCRUD.IRepository;
using CascadingDPWithCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace CascadingDPWithCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> list1 = _employeeRepository.GetEmployees();

            return View(list1);
        }



        public ActionResult Create()
        {
            DataAccessLayer objDB = new DataAccessLayer();
            var list = objDB.GetDepartment();
            var list1 = objDB.GetDesination();
            ViewBag.DepartmentId = new SelectList(list, "DepartmentId", "DeptName");
            //ViewBag.DesignationId = new SelectList(list1, "DesignationId", "DesinationName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
           
            if (ModelState.IsValid) //checking model is valid or not    
            {
                //DataAccessLayer objDB = new DataAccessLayer();
                string result = _employeeRepository.InsertData(employee);
                //ViewData["result"] = result;    
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model    
                                    //return View();    
                return RedirectToAction("Index");
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            var list = objDB.GetDepartment();
            var list1 = objDB.GetDesination();
            ViewBag.DepartmentId = new SelectList(list, "DepartmentId", "DeptName");
            ViewBag.DesignationId = new SelectList(list1, "DesignationId", "DesinationName");
            Employee employee = _employeeRepository.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid) //checking model is valid or not    
            {
                //DataAccessLayer objDB = new DataAccessLayer();
                string result = _employeeRepository.UpdateEmployee(employee);
                //ViewData["result"] = result;    
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model    
                                    //return View();    
                return RedirectToAction("Index");
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int ID)
        {
            try
            {
                string result = _employeeRepository.DeleteEmployee(ID);
                TempData["result3"] = result;
                ModelState.Clear(); //clearing model    
                                    //return View();    
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

       public JsonResult getDesinationList(int dId)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            DataSet ds = objDB.GetDesinationList(dId);
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Value = dr["DesignationId"].ToString(), Text = dr["DesinationName"].ToString() });
               
            }
            return Json(list);
        }

    }
}
