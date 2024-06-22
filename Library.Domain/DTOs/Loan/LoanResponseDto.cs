using Library.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DTOs.Loan {
    public class LoanResponseDto {
      
        public int BookId { get; set; }       
        public int UserId { get; set; }
        public DateTime LoanDate { get; set; }        
        public DateTime? ReturnDate { get; set; }       
        public bool Returned { get; set; }

    }
}
