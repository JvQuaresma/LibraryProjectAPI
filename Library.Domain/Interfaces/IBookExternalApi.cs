using Library.Domain.DTOs;
using Library.Domain.DTOs.Book;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces {
    public interface IBookExternalApi {

        Task<GenericResponse<IEnumerable<Book>>> GetAllBooksAsync(HttpClient client);
        Task<GenericResponse<BookExternalByIdDto>> GetBookById(int id, HttpClient httpClient);

    }
}
