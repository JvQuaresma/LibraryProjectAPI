using Library.Domain.DTOs.Book;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.Repositories {
    public interface IBookRepository {

        public Task<Book> ToAddAsync(Book book);
        public Task<Book> GetByIdAsync(int id);
        public Task<IEnumerable<Book>> GetAllAsync();
        public Task<Book> UpdateAsync(BookUpdateDto bookUpdateDto, int id);
        public Task<Book> DeleteAsync(int id);

    }
}
