using AutoMapper;
using Library.Domain.DTOs.Book;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Models;
using Library.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infra.Repositories {
    public class BookRepository : IBookRepository {

        private readonly LibraryContext _context;
        private readonly IMapper _mapper;
        public BookRepository(LibraryContext context, IMapper mapper ) {
            _context = context;
            _mapper = mapper;
        } 

        public async Task<IEnumerable<Book>> GetAllAsync() {

            try {
                var book = await _context.Books.ToListAsync();
                return book;

            }catch (Exception ex) {
                throw new Exception("Erro ao buscar Livros" + ex.Message);
            }

        }

        public async Task<Book> GetByIdAsync(int id) {

            try {

                var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
                return book;

            }catch (Exception ex) {
                throw new Exception("Erro ao buscar Livro" + ex.Message);
            }

        }

        public async Task<Book> ToAddAsync(Book book) {
            
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync(); 
            return book;

        }

        public async Task<Book> UpdateAsync(BookUpdateDto bookUpdateDto, int id) {

            try {
                var existingBook = await _context.Books.FindAsync(id);

                if (existingBook == null)
                    throw new Exception("Book não encontrado.");

                _mapper.Map(bookUpdateDto, existingBook);

                await _context.SaveChangesAsync();
                return existingBook;

            } catch (Exception ex) {

                throw new Exception("Erro ao tentar atualizar" + ex.Message);
            }

        }

        public async Task<Book> DeleteAsync(int id) {

            try {
                var book = await _context.Books.FirstOrDefaultAsync(l => l.Id == id);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return book;

            } catch (Exception ex) {
                throw new Exception("Erro ao deletar" + ex.Message);
            }
        }
    }
}
