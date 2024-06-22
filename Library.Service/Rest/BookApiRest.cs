using Library.Domain.DTOs;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Service.Rest {
    public class BookApiRest : IBookApi {
        public async Task<GenericResponse<List<Book>>> GetAllBooks() {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://simple-books-api.glitch.me/books");

            var response = new GenericResponse<List<Book>>();
            using (var client = new HttpClient()) {
                var responseBookApi = await client.SendAsync(request);
                var contentResp = await responseBookApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<List<Book>>(contentResp);

                if (responseBookApi.IsSuccessStatusCode) {

                    response.httpCode = responseBookApi.StatusCode;
                    response.returnData = objResponse;

                } else {
                    response.httpCode = responseBookApi.StatusCode;
                    response.returnError = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }

            }

            return response;
        }

        public async Task<GenericResponse<Book>> GetBookById(int id) {

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://simple-books-api.glitch.me/books/{id}");

            var response = new GenericResponse<Book>();
            using (var client = new HttpClient()) {
                var responseBookApi = await client.SendAsync(request);
                var contentResp = await responseBookApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<Book>(contentResp);

                if (responseBookApi.IsSuccessStatusCode) {

                    response.httpCode = responseBookApi.StatusCode;
                    response.returnData = objResponse;

                }else {
                    response.httpCode = responseBookApi.StatusCode;
                    response.returnError = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }

            }

            return response;
        }
    }
}
