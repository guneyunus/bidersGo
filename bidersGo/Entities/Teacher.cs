﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Entities
{
    public class Teacher:BaseEntity
    {
        

        [Required, StringLength(40)]

        public string Name { get; set; }

        [Required, StringLength(40)]

        public string Surname { get; set; }

        public string Branch { get; set; }

        public int TcKimlik { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }


    }
}
