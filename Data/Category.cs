using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    class Category
    {
        [Key]
        public int Id { get; set; } 
        public string poj_kategoria { get; set; }
        public string autor_kategorii { get; set; }
        public int ktora_kategoria { get; set; }
    }
}
