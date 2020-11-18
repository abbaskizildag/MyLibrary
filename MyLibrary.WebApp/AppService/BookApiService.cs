using MyLibrary.WebApp.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.WebApp.AppService
{
    public class BookApiService
    {
        private readonly HttpClient _httpClient;
        public BookApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            IEnumerable<BookDto> bookDtos;
            var response = await _httpClient.GetAsync("/api/v1/books");
            if (response.IsSuccessStatusCode)
            {
                bookDtos = JsonConvert.DeserializeObject<IEnumerable<BookDto>>(await response.Content.ReadAsStringAsync()); //dönüştürme işleni
            }
            else
            {
                bookDtos = null;
            }
            return bookDtos;
        }
        public void Add(BookDto bookDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(bookDto), Encoding.UTF8, "application/json"); //gönderecek data burda encoding etmeyi unutmamak lazım.

            var response = _httpClient.PostAsync("/api/v1/books", stringContent).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                bookDto = JsonConvert.DeserializeObject<BookDto>( response.Content.ReadAsStringAsync().Result); //json data'yı class'a dönüştürme işlemi
                //response.Content.ReadAsStringAsync().Result)

            }
            else
            {
                //loglama yap.

            }
        }

        public bool Update(BookDto bookDto)
        {
           

            var stringContent = new StringContent(JsonConvert.SerializeObject(bookDto), Encoding.UTF8, "application/json");
            var response =  _httpClient.PutAsync("/api/v1/books", stringContent);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Remove(int id)
        {
            var response =  _httpClient.DeleteAsync($"/api/v1/books/{id}");
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            {
                return false;
            }
        }

        public BookDto GetByAsync(int id)
        {
            var response = _httpClient.GetAsync($"/api/v1/books/{id}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<BookDto>( response.Content.ReadAsStringAsync().Result);

            }
            else
            {
                return null;
            }
        }
    }
}
