using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class tblhobby
    {
        [Key]
        public int hid { get; set; }
        public string hname { get; set; }
    }
}
