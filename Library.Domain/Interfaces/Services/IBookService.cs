using Library.Domain.DTOs.Book;
using Library.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.Services {
    public interface IBookService {

        public Task<IEnumerable<BookResponseDto>> GetAllBooks();
        public Task<BookResponseDto> GetBookById(int id);
        public Task<BookResponseDto> AddBook(BookRegisterDto bookRegisterDto);
        public Task<BookResponseDto> UpdateBook(BookUpdateDto bookUpdateDto, int id);
        public Task<BookResponseDto> DeleteBook(int id);
        

    }
}
