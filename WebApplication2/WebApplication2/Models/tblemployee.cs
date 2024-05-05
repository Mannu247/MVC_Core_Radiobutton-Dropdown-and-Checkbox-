using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class tblemployee
    {
        [Key]
        public int empid { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int country { get; set; }
        public int state { get; set; }
        public int gender { get; set; }
        public string hobby { get; set; }
    }
}
