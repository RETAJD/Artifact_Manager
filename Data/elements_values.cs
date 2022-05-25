using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    class elements_values
    {
        [Key]
        public int ID { get; set; }
        public string element { get; set; }
        public string nazwa_wartosci { get; set; }
        public string wartosc { get; set; }
    }
}
