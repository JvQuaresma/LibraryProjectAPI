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
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }       
        public int UserId { get; set; }
        public User User { get; set; }       
        public DateTime LoanDate { get; set; }        
        public DateTime? ReturnDate { get; set;}      
        public bool Returned { get; set; }
    }
}
