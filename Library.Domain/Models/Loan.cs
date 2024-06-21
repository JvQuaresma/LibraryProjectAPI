using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models {
    public class Loan {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("bookId")]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        public User User { get; set; }

        [JsonProperty("loanDate")]
        public DateTime LoanDate { get; set; }

        [JsonProperty("returnDate")]
        public DateTime? ReturnDate { get; set;}

        [JsonProperty("returned")]
        public bool Returned { get; set; }
    }
}
