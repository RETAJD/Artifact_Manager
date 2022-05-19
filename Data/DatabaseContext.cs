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
        public DatabaseContext() : base (@"Data Source=DESKTOP-9K2SBT4\SQLEXPRESS;Initial Catalog=DATABASE_APP;User ID=DESKTOP-9K2SBT4\admin;Password=;Integrated Security=True")
        {
        }

        public virtual DbSet<Users> Userss { get; set; }
    }
}
