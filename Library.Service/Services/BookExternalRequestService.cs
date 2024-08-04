using AutoMapper;
using Library.Domain.DTOs;
using Library.Domain.DTOs.Book;
using Library.Domain.Interfaces;
using Library.Domain.Interfaces.Services;
using Library.Domain.Models;
using Library.Infra.Data;
using Microsoft.EntityFrameworkCore;


namespace Library.Service.Services {
    public class BookExternalRequestService : IBookExternalRequestService {

        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IBookExternalApi _bookApi;
        private readonly LibraryContext _context;

        public BookExternalRequestService(HttpClient httpClient, IMapper mapper, IBookExternalApi bookApi, LibraryContext context) {
            _httpClient = httpClient;
            _mapper = mapper;
            _bookApi = bookApi;
            _context = context;
        }

        public async Task<GenericResponse<IEnumerable<BookResponseDto>>> GetAllExternalBooks() {

            var bookInApi = await _bookApi.GetAllBooksAsync(_httpClient);
            var books = _mapper.Map<GenericResponse<IEnumerable<BookResponseDto>>>(bookInApi);
            await PopulatedDb();
            return books;

        }

        public async Task<GenericResponse<BookExternalByIdDto>> GetBookExternalById(int id) {

            var book = await _bookApi.GetBookById(id, _httpClient);
            return book;
        }

        public async Task PopulatedDb() {
            
            var response = await _bookApi.GetAllBooksAsync(_httpClient);
            
            if (response == null || response.returnData == null) {
                throw new Exception("A lista de livros da API é nula.");
            }
        
            var booksFromApi = response.returnData;
            var booksInDb = await _context.Books.ToListAsync();
          
            foreach (var bookDto in booksFromApi) {
                if (!booksInDb.Any(b => b.Name == bookDto.Name)) {

                    var book = new Book {
                        Name = bookDto.Name,
                        Type = bookDto.Type,
                        Available = bookDto.Available,

                    };
                    _context.Books.Add(book);
                }
            }
           
            await _context.SaveChangesAsync();

           
        }
    }
}
