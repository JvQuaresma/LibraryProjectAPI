using Library.Domain.DTOs;
using Library.Domain.DTOs.Book;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.Services {
    public interface IBookExternalRequestService {

        Task<GenericResponse<BookExternalByIdDto>> GetBookExternalById(int id);
        Task<GenericResponse<IEnumerable<BookResponseDto>>> GetAllExternalBooks();
        Task PopulatedDb();

    }
}
