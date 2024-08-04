﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models {
    public class Author {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]      
        public int Id { get; set; }       
        public string Name { get; set; }
 
   

    }
}
