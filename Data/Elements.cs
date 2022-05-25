using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    class Elements
    {
        [Key]
        public int ID_ele { get; set; }
        public string kategoria_ele { get; set; }
        public string element { get; set; }
    }
}
