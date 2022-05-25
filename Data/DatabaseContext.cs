using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace App.Data
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base (@"Data Source=DESKTOP-9K2SBT4\SQLEXPRESS;Initial Catalog=DATABASE_APP;User ID=DESKTOP-9K2SBT4\admin;Password=;Integrated Security=True;MultipleActiveResultSets=True")
        {
        }

        public virtual DbSet<Users> Userss { get; set; }
        public virtual DbSet<Roles> Roless { get; set; }
        public virtual DbSet<onlyRoles> onlyRoless { get; set; }
        public virtual DbSet<onlyPozwolenia> OnlyPozwolenias { get; set; }
        public virtual DbSet<Category> Categoryss { get; set; }
        public virtual DbSet<Elements> Elementsss { get; set; }
        public virtual DbSet<elements_values> Elementsvaluess { get; set; }


    }
}
