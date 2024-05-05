using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EmployeeModel
    {
        public int empid { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int country { get; set; }
        public int state { get; set; }
        public int gender { get; set; }
        public string hobby {get; set;}
        public List<tblcountry> lstcountry { get; set; }
        public List<tblstate> lststate { get; set; }
        public List<tblgender> lstgender { get; set; }
        public List<tblhobby1> lsthobby1 { get; set; }
    }
}
