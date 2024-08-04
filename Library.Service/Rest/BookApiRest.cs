using Library.Domain.DTOs;
using Library.Domain.DTOs.Book;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Service.Rest {
    public class BookApiRest : IBookExternalApi {
        
        public async Task<GenericResponse<IEnumerable<Book>>> GetAllBooksAsync(HttpClient client) {
            var response = new GenericResponse<IEnumerable<Book>>();

            try {
                var responseBookApi = await client.GetAsync("https://simple-books-api.glitch.me/books");
                var contentResp = await responseBookApi.Content.ReadAsStringAsync();

                if (responseBookApi.IsSuccessStatusCode) {
                    var objResponse = JsonSerializer.Deserialize<IEnumerable<Book>>(contentResp, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (objResponse != null) {
                        response.httpCode = responseBookApi.StatusCode;
                        response.returnData = objResponse;
                    } else {
                        response.httpCode = HttpStatusCode.InternalServerError;
                       
                    }
                } else {
                    response.httpCode = responseBookApi.StatusCode;
                    response.returnError = JsonSerializer.Deserialize<ExpandoObject>(contentResp, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            } catch (Exception ex) {
                response.httpCode = HttpStatusCode.InternalServerError;
               
            }

            return response;
        }

        public async Task<GenericResponse<BookExternalByIdDto>> GetBookById(int id, HttpClient client) {
            var response = new GenericResponse<BookExternalByIdDto>();

            try {
                
                var responseBookApi = await client.GetAsync($"https://simple-books-api.glitch.me/books/{id}");
                var contentResp = await responseBookApi.Content.ReadAsStringAsync();

                if (responseBookApi.IsSuccessStatusCode) {
                    var objResponse = JsonSerializer.Deserialize<BookExternalByIdDto>(contentResp, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (objResponse != null) {
                        response.httpCode = responseBookApi.StatusCode;
                        response.returnData = objResponse;
                    } else {
                        response.httpCode = HttpStatusCode.InternalServerError;
                       
                    }
                } else {
                    response.httpCode = responseBookApi.StatusCode;
                    response.returnError = JsonSerializer.Deserialize<ExpandoObject>(contentResp, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            } catch (Exception ex) {
                response.httpCode = HttpStatusCode.InternalServerError;
                
            }

            return response;
        }
        
    }
}
