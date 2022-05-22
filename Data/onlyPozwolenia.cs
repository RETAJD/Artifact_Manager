using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    class onlyPozwolenia
    {
        [Key]
        public string pozwolenie_pojedyncze { get; set; }
    }
}
