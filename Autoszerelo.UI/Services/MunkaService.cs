using Autoszerelo.DataClasses;
using Autoszerelo.UI.Services.Interfaces;
using System;
using System.Net;
using System.Net.Http.Json;

namespace Autoszerelo.UI.Services
{
    public class MunkaService : IMunkaService
    {
        private readonly HttpClient _httpClient;
        public MunkaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpStatusCode> AddAsync(Munka munka)
        {
            return (await _httpClient.PostAsJsonAsync("/Munkak", munka)).StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAsync(Guid ID)
        {
            return (await _httpClient.DeleteAsync($"/Munkak/{ID}")).StatusCode;
        }

        public async Task<Munka> GetAsync(Guid ID)
        {
            return await _httpClient.GetFromJsonAsync<Munka>($"/Munkak/{ID}");
        }

        public async Task<IEnumerable<Munka>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>("/Munkak");
        }

        public async Task<HttpStatusCode> NextWorkingStateAsync(Guid ID)
        {
            return (await _httpClient.PutAsJsonAsync($"/Munkak/next/{ID}", ID)).StatusCode;
        }

        public async Task<HttpStatusCode> UpdateAsync(Munka munka)
        {
            var id = munka.MunkaAzonosito;
            return (await _httpClient.PutAsJsonAsync($"/Munkak/{id}", munka)).StatusCode;
        }
    }
}
