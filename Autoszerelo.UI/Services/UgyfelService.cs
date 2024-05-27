using Autoszerelo.DataClasses;
using Autoszerelo.UI.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Autoszerelo.UI.Services
{
    public class UgyfelService : IUgyfelService
    {
        private readonly HttpClient _httpClient;
        public UgyfelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpStatusCode> AddAsync(Ugyfel ugyfel)
        {
            return (await _httpClient.PostAsJsonAsync("/Ugyfelek", ugyfel)).StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAsync(Guid ID)
        {
            return (await _httpClient.DeleteAsync($"/Ugyfelek/{ID}")).StatusCode;
        }

        public async Task<Ugyfel> GetAsync(Guid ID)
        {
            return await _httpClient.GetFromJsonAsync<Ugyfel>($"/Ugyfelek/{ID}");
        }

        public async Task<IEnumerable<Ugyfel>> GetAllAsync()
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };
            return await _httpClient.GetFromJsonAsync<IEnumerable<Ugyfel>>("/Ugyfelek/list", options);
        }

        public async Task<HttpStatusCode> UpdateAsync(Ugyfel ugyfel)
        {
            var id = ugyfel.Ugyfelszam;
            return (await _httpClient.PutAsJsonAsync($"/Ugyfelek/{id}", ugyfel)).StatusCode;
        }
    }
}
