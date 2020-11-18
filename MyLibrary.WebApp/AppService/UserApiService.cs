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
    public class UserApiService
    {
        private readonly HttpClient _httpClient;
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<UserDto> userDtos;
            var response = await _httpClient.GetAsync("/api/v1/users");
            if (response.IsSuccessStatusCode)
            {
                userDtos = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(await response.Content.ReadAsStringAsync()); //dönüştürme işleni
            }
            else
            {
                userDtos = null;
            }
            return userDtos;
        }

        public void Add(UserDto userDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json"); //gönderecek data burda encoding etmeyi unutmamak lazım.

            var response = _httpClient.PostAsync("/api/v1/users", stringContent).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                userDto = JsonConvert.DeserializeObject<UserDto>(response.Content.ReadAsStringAsync().Result); //json data'yı class'a dönüştürme işlemi
                //response.Content.ReadAsStringAsync().Result)

            }
            else
            {
             

            }
        }
        public bool Update(UserDto userDto)
        {


            var stringContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
            var response = _httpClient.PutAsync("/api/v1/users", stringContent);

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
            var response = _httpClient.DeleteAsync($"/api/v1/users/{id}");
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            {
                return false;
            }
        }

        public UserDto GetByAsync(int id)
        {
            var response = _httpClient.GetAsync($"/api/v1/users/{id}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<UserDto>(response.Content.ReadAsStringAsync().Result);

            }
            else
            {
                return null;
            }
        }
    }
}
