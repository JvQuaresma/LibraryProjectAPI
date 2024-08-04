using Library.Domain.DTOs.Book;
using Library.Domain.Interfaces.Services;
using Library.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers {

    

    [ApiController]
    [Route("api")]
    public class BookController : ControllerBase {

        private readonly IBookService _bookService;
        public BookController(IBookService service) {
            _bookService = service;
        }

        [HttpGet("books")]
        public async Task<ActionResult<ResponseViewModel<List<BookResponseDto>>>> GetAllBooks() {

            try {

                return Ok(new ResponseViewModel(true,"Sucesso!", await _bookService.GetAllBooks()));

            }catch (Exception ex) {
                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }

        }

        [HttpGet("books/{id}")]
        public async Task<ActionResult<ResponseViewModel<BookResponseDto>>> GetBook(int id) {
            try {
                var book = await _bookService.GetBookById(id);
                if (book == null) {
                    return NotFound();
                }

                return Ok(new ResponseViewModel(true, "Sucesso!", book));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }

        }

        [HttpPost("book")]
        public async Task<ActionResult<ResponseViewModel<BookResponseDto>>> AddBook([FromBody]BookRegisterDto bookRegisterDto) {

            try {

                return Ok(new ResponseViewModel(true, "Sucesso!", await _bookService.AddBook(bookRegisterDto)));

            }catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }

        }


        [HttpPut("updateBook/{id}")]
        public async Task<ActionResult<ResponseViewModel<BookResponseDto>>> UpdateBook([FromBody] BookUpdateDto bookDto, int id) {
            try {

                return Ok(new ResponseViewModel(true, "Sucesso!", await _bookService.UpdateBook(bookDto, id)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }
        }

        [HttpDelete("deleteBook/{id}")]
        public async Task<ActionResult<ResponseViewModel<BookResponseDto>>> DeleteBook(int id) {
            try {

                return Ok(new ResponseViewModel(true, "Sucesso!", await _bookService.DeleteBook(id)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }
        }

    }
}
