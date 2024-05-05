using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class tblgender
    {
        [Key]
        public int gid { get; set; }
        public string gname { get; set; }
    }
}
