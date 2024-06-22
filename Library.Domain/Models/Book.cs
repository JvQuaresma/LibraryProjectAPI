using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models {
    public class Book {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]       
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }     

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }

    }
}
