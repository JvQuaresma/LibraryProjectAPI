using AutoMapper;
using Library.Domain.DTOs;
using Library.Domain.DTOs.Book;
using Library.Domain.Interfaces;
using Library.Domain.Interfaces.Services;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Services {
    public class BookService : IBookService {

        private readonly IMapper _mapper;
        private readonly IBookApi _bookApi;

        public BookService(IMapper mapper, IBookApi bookApi) {
            _mapper = mapper;
            _bookApi = bookApi;
        }

        public async Task<GenericResponse<List<BookResponseDto>>> GetAllBooks() {
            var book = await _bookApi.GetAllBooks();
            return _mapper.Map<GenericResponse<List<BookResponseDto>>>(book);
        }

        public async Task<GenericResponse<BookResponseDto>> GetBookById(int id) {
            
            var book = await _bookApi.GetBookById(id);
            return _mapper.Map<GenericResponse<BookResponseDto>>(book);
        }
    }
}
