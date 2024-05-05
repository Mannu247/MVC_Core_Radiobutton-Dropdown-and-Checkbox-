using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class tblstate
    {
        [Key]
        public int sid { get; set; }
        public int cid { get; set; }
        public string sname { get; set; }
    }
}
