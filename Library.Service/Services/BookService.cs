using AutoMapper;
using Library.Domain.DTOs.Book;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Services {
    public class BookService : IBookService {

        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper) {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAllBooks() {

            var book = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookResponseDto>>(book);

        }

        public async Task<BookResponseDto> GetBookById(int id) {

            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookResponseDto>(book);

        }

        public async Task<BookResponseDto> AddBook(BookRegisterDto bookRegisterDto) {

            var book = _mapper.Map<Book>(bookRegisterDto);

            await _bookRepository.ToAddAsync(book);

            return _mapper.Map<BookResponseDto>(book);
        }

        public async Task<BookResponseDto> UpdateBook(BookUpdateDto bookUpdateDto, int id) {

            var book = _mapper.Map<Book>(bookUpdateDto);
            var existingBook = await _bookRepository.UpdateAsync(bookUpdateDto, id);

            return _mapper.Map<BookResponseDto>(existingBook);

        }

        public async Task<BookResponseDto> DeleteBook(int id) {

            var book = await _bookRepository.DeleteAsync(id);
            return _mapper.Map<BookResponseDto>(book);

        }

        

        

        
    }
}
