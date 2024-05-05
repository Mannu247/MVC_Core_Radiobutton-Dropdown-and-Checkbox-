using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class tblcountry
    {
        [Key]
        public int cid { get; set; }
        public string cname { get; set; }
    }
}
