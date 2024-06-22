using Library.Domain.DTOs;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces {
    public interface IBookApi {

        Task<GenericResponse<List<Book>>> GetAllBooks();
        Task<GenericResponse<Book>> GetBookById(int id);

    }
}
