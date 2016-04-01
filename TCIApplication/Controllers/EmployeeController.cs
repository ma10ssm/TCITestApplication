using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCIApplication.Models;
using TCIApplication.DAL;
using System.Net;

namespace TCIApplication.Controllers
{
    public class EmployeeController : Controller
    {        
        IEmployeeRepository _employeeRepository;
        IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeRepository, IDepartmentRepository departmentRepository)

        {
            _employeeRepository = employeRepository;
            _departmentRepository = departmentRepository;
        }

        public ActionResult Index()
        {            
            var employeeList = _employeeRepository.GetAll();
            return View("Index", employeeList);
        }
        
        public ActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, MiddleName, LastName, Address, StartDate, DepartmentId")]Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeRepository.Add(employee);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {                
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View("Create", employee);

        }
        
        public ActionResult Edit(int? employeeId)
        {            
            if (employeeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = _employeeRepository.Get(employeeId.Value);
            PopulateDepartmentsDropDownList(employee.DepartmentId);
            return View("Edit", employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            var employeeToUpdate = _employeeRepository.Get(employee.EmployeeId);
            if (employee == null)
            {
                return HttpNotFound();
            }

            try
            {
                _employeeRepository.Update(employeeToUpdate, employee);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            
            return View("Edit", employeeToUpdate);

        }

        public ActionResult Delete(int? employeeId)
        {
            if (employeeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = _employeeRepository.Get(employeeId.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View("Delete", employee);        
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int employeeId)
        {
            _employeeRepository.Remove(employeeId);            
            return RedirectToAction("Index");
        }
        
        public ActionResult Details(int? employeeId)
        {
            if (employeeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = _employeeRepository.Get(employeeId.Value);
            return View("Details", employee);
        }
        
        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = _departmentRepository.GetOrderedList();
            ViewBag.DepartmentId = new SelectList(departmentsQuery, "DepartmentId", "Name", selectedDepartment);
        }
    }
}