using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<tblemployee>tblemployees { get; set; }
        public DbSet<tblcountry> tblcountries { get; set; }
        public DbSet<tblstate> tblstates { get; set; }
        public DbSet<tblgender> tblgenders { get; set; }
        public DbSet<tblhobby> tblhobbies { get; set; }
    }
}
