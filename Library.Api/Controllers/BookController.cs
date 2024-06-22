using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Api.Controllers {
   
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase {

        public readonly IBookService _bookService;

        public BookController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> AllBooks() {
            var response = await _bookService.GetAllBooks();

            if (response.httpCode == HttpStatusCode.OK) {
                return Ok(response.returnData);
            } else {
                return StatusCode((int)response.httpCode, response.returnError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BookById([FromRoute]int id) {

            var response = await _bookService.GetBookById(id);

            if(response.httpCode == HttpStatusCode.OK) {
                return Ok(response.returnData);
            } else {
                return StatusCode((int)response.httpCode, response.returnError);
            }

        }
    }
}
