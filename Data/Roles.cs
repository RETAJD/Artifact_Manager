using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    class Roles
    {
        [Key]  
        public string username { get; set; }
        public string rola { get; set; }

        public string pozwolenia_wszystkie { get; set; }

        public List<Users> Users { get; set; }
        
    }
}
