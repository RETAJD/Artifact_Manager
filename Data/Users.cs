﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    class Users
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
