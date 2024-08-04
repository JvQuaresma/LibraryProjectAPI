using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Api.Controllers {
   
    [ApiController]
    [Route("apiExternal/books")]
    public class BookExternalRequestController : ControllerBase {

        public readonly IBookExternalRequestService _bookExternalService;

        public BookExternalRequestController(IBookExternalRequestService bookService) {
            _bookExternalService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> AllBooks() {
            var response = await _bookExternalService.GetAllExternalBooks();

            if (response.httpCode == HttpStatusCode.OK) {
                return Ok(response.returnData);
            } else {
                return StatusCode((int)response.httpCode, response.returnError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BookById([FromRoute]int id) {

            try {
                var response = await _bookExternalService.GetBookExternalById(id);

                if (response.httpCode == HttpStatusCode.OK) {
                    return Ok(response.returnData);
                } else {
                    return StatusCode((int)response.httpCode, response.returnError);
                }
            }catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
