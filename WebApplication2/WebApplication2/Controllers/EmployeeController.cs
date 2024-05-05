using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly DatabaseContext _db;
        public EmployeeController(DatabaseContext context)
        {
            _db = context;
        }
        [HttpGet]
        public IActionResult AddEmployee(int id = 0)
        {
            EmployeeModel obj = new EmployeeModel();
            //ViewBag.ctr = _db.tblcountries.ToList();
            obj.lstcountry = _db.tblcountries.ToList();
            obj.lstgender = _db.tblgenders.ToList();
            var HData = _db.tblhobbies.ToList();
            obj.lsthobby1 = HData.Select(x => new tblhobby1 { 
            hid = x.hid,
            hname = x.hname,
            ischecked = false
            }).ToList();
            ViewBag.BT = "Submit Data";
            //tblemployee obj = new tblemployee();
            if(id > 0)
            {
                var data = (from a in _db.tblemployees where a.empid == id select a).ToList();
                obj.empid = data[0].empid;
                obj.name = data[0].name;
                obj.age = data[0].age; 
                obj.country = data[0].country;
                obj.state = data[0].state;
                obj.gender = data[0].gender;
                string[] arr = data[0].hobby.Split(',');
                foreach(var a in obj.lsthobby1)
                {
                    foreach(var b in arr)
                    {
                        if(a.hname == b)
                        {
                            a.ischecked = true;
                        }
                    }
                }
                ViewBag.BT = "Update Data";
            }
            //ViewBag.stt = _db.tblstates.Where(x => x.cid == obj.country).ToList();
            obj.lststate = _db.tblstates.Where(x => x.cid == obj.country).ToList();
            return View(obj);
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel _empmodel)
        {
            string mm = "";
            foreach(var a in _empmodel.lsthobby1)
            {
                if(a.ischecked==true)
                {
                    mm += a.hname + ",";
                }
            }
            mm = mm.TrimEnd(',');

            tblemployee _emp = new tblemployee();
            _emp.name = _empmodel.name;
            _emp.age = _empmodel.age;
            _emp.country = _empmodel.country;
            _emp.state = _empmodel.state;
            _emp.gender = _empmodel.gender;
            _emp.hobby = mm;

            if (_empmodel.empid > 0)
            {
                _emp.empid = _empmodel.empid;
                _db.Entry(_emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _db.tblemployees.Add(_emp);
            }
            _db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }
        public IActionResult DeleteEmployee(int id=0)
        {
            var data = _db.tblemployees.Find(id);
            _db.tblemployees.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }
        public IActionResult ShowEmployee()
        {
            var data = (from a in _db.tblemployees
                        join b in _db.tblcountries on a.country equals b.cid
                        join c in _db.tblstates on a.state equals c.sid
                        join d in _db.tblgenders on a.gender equals d.gid
                        select new EmployeeJoin { empid = a.empid, name = a.name, age = a.age, country = b.cname, state = c.sname, gender = d.gname, hobby = a.hobby}).ToList();
            return View(data);
        }
        public JsonResult GetState(int A)
        {
            var data = _db.tblstates.Where(x => x.cid == A).ToList();
            return Json(data);
        }
    }
}