using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Domain.DTOs.Book {
    public class BookExternalByIdDto {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        [JsonPropertyName("current-stock")]
        public int Current_Stock { get; set; }
        public bool Available { get; set; }

    }
}
