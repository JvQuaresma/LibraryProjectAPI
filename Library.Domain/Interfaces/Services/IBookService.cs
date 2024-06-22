using Library.Domain.DTOs;
using Library.Domain.DTOs.Book;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.Services {
    public interface IBookService {

        Task<GenericResponse<BookResponseDto>> GetBookById(int id);
        Task<GenericResponse<List<BookResponseDto>>> GetAllBooks();

    }
}
