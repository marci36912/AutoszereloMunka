using Autoszerelo.DataClasses;
using Autoszerelo.UI.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Components;

namespace Autoszerelo.UI.Services
{
    public class UgyfelService : IUgyfelService
    {
        private readonly HttpClient _httpClient;
        public UgyfelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Add(Ugyfel ugyfel)
        {
            await _httpClient.PostAsJsonAsync("/Ugyfelek", ugyfel);
        }

        public async Task Delete(Guid ID)
        {
            await _httpClient.DeleteAsync($"/Ugyfelek/{ID}");
        }

        public async Task<Ugyfel> Get(Guid ID)
        {
            return await _httpClient.GetFromJsonAsync<Ugyfel>($"/Ugyfelek/{ID}");
        }

        public async Task<IEnumerable<Ugyfel>> GetAll()
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };
            return await _httpClient.GetFromJsonAsync<IEnumerable<Ugyfel>>("/Ugyfelek/list", options);
        }

        public async Task Update(Ugyfel ugyfel)
        {
            var id = ugyfel.Ugyfelszam;
            await _httpClient.PutAsJsonAsync($"/Ugyfelek/{id}", ugyfel);
        }
    }
}
