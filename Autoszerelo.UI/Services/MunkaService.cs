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
        public async Task Add(Munka munka)
        {
            await _httpClient.PutAsJsonAsync("/Munkak", munka);
        }

        public async Task Delete(Guid ID)
        {
            await _httpClient.DeleteAsync($"/Munkak/{ID}");
        }

        public async Task<Munka> Get(Guid ID)
        {
            return await _httpClient.GetFromJsonAsync<Munka>($"/Munkak/{ID}");
        }

        public async Task<IEnumerable<Munka>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>("/Munkak");
        }

        public async Task NextWorkingState(Guid ID)
        {
            //TODO SAJAT UTVONAL
        }

        public async Task Update(Munka munka)
        {
            var id = munka.MunkaAzonosito;
            await _httpClient.PutAsJsonAsync($"/Munkak/{id}", munka);
        }
    }
}
