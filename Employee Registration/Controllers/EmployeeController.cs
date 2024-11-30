using Employee_Registration.Entity;
using Employee_Registration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Employee_Registration.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRegistrationContext _context;

        public EmployeeController(EmployeeRegistrationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: Employees/Create	
        public IActionResult Create()
        {
            ViewBag.CountryList = _context.CountryMsts.Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();
    
            var model = new _Employee();
            model.DateOfBirth = DateTime.Now;
            return PartialView(model);
        }

        public IActionResult Edit(int ID)
        {
            try
            {
                ViewBag.CountryList = _context.CountryMsts.Select(x => new SelectListItem
                {
                    Text = x.CountryName,
                    Value = x.Id.ToString()
                }).ToList();
                ViewBag.StateList = _context.StateMsts.Select(x => new SelectListItem
                {
                    Text = x.StateName,
                    Value = x.Id.ToString()
                }).ToList();
                var model = _context.EmployeeMsts.Where(x => x.EmployeeId == ID).Select(x => new _Employee
                {
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 = x.AddressLine2,
                    Age = x.Age,
                    DateOfBirth = x.Dob,
                    Employee_Id = x.EmployeeId,
                    Employee_Name = x.EmployeeName,
                    Mobile_Num = x.MobileNum,
                    Pincode = x.Pincode,
                    State = x.StateId,
                    Country = x.CountryId,

                }).FirstOrDefault();
                return PartialView(model);
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }
        public IActionResult GetStateList(int ID)
        {
            return Json(_context.StateMsts.Where(x => x.CountryId == ID).Select(x => new SelectListItem
            {
                Text = x.StateName,
                Value = x.Id.ToString()
            }).ToList());
        }
        [HttpGet]
        public IActionResult GetEmployees(int v)
        {
            var list = _context.EmployeeMsts.Select(x => new _Employee
            {
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
                Age = x.Age,
                DateOfBirth = x.Dob,
                Employee_Id = x.EmployeeId,
                Employee_Name = x.EmployeeName,
                Mobile_Num = x.MobileNum,
                Pincode = x.Pincode,
                State = x.StateId,
                Country = x.CountryId,

            }).ToList();

            return Json(list);

        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(_Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new EmployeeMst
                {
                    CountryId = employee.Country,
                    Dob = employee.DateOfBirth,
                    EmployeeId = employee.Employee_Id,
                    EmployeeName = employee.Employee_Name,
                    Age = employee.Age,
                    Pincode = employee.Pincode,
                    MobileNum = employee.Mobile_Num,
                    StateId = employee.State,
                    AddressLine1 = employee.AddressLine1,
                    AddressLine2 = employee.AddressLine2,

                });
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(_Employee employee)
        {
            if (ModelState.IsValid)
            {
                var model = _context.EmployeeMsts.FirstOrDefault(x => x.EmployeeId == employee.Employee_Id);
                if (model != null)
                {
                    model.StateId = employee.State;
                    model.AddressLine1 = employee.AddressLine1;
                    model.AddressLine2 = employee.AddressLine2;
                    model.CountryId = employee.Country;
                    model.Dob = employee.DateOfBirth;
                    model.EmployeeId = employee.Employee_Id;
                    model.EmployeeName = employee.Employee_Name;
                    model.Age = employee.Age;
                    model.Pincode = employee.Pincode;
                    model.MobileNum = employee.Mobile_Num;
                    _context.EmployeeMsts.Update(model);
                    _context.SaveChanges();
                }
              
            }
            return RedirectToAction(nameof(Index));
        }
        public bool ValidateMoNumber(string Mobile_Num,int Employee_Id)
        {
            if (Employee_Id == 0)
            {
                return !_context.EmployeeMsts.Any(x => x.MobileNum == Mobile_Num);
            }
            else
            {
                return !_context.EmployeeMsts.Any(x => x.MobileNum == Mobile_Num && x.EmployeeId!=Employee_Id);
            }

        }
        public IActionResult Delete(int ID)
        {
            try
            {
                var model = _context.EmployeeMsts.FirstOrDefault(x => x.EmployeeId == ID);
                if (model != null)
                {
                    _context.EmployeeMsts.Remove(model);
                    _context.SaveChanges();
                 
                }

            }catch(Exception ex)
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
