using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DTOs.Book {
    public class BookResponseDto {
       
        public string Name { get; set; }
        public string Type { get; set; }       
        public bool Available { get; set; }

    }
}
