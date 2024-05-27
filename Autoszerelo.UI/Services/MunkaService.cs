using Autoszerelo.DataClasses;
using Autoszerelo.UI.Services.Interfaces;
using System;
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
        public async Task AddAsync(Munka munka)
        {
            await _httpClient.PostAsJsonAsync("/Munkak", munka);
        }

        public async Task DeleteAsync(Guid ID)
        {
            await _httpClient.DeleteAsync($"/Munkak/{ID}");
        }

        public async Task<Munka> GetAsync(Guid ID)
        {
            return await _httpClient.GetFromJsonAsync<Munka>($"/Munkak/{ID}");
        }

        public async Task<IEnumerable<Munka>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>("/Munkak");
        }

        public async Task NextWorkingStateAsync(Guid ID)
        {
            await _httpClient.PutAsJsonAsync($"/Munkak/next/{ID}", ID);
        }

        public async Task UpdateAsync(Munka munka)
        {
            var id = munka.MunkaAzonosito;
            await _httpClient.PutAsJsonAsync($"/Munkak/{id}", munka);
        }
    }
}
