using Autoszerelo.DataClasses;
using System.Net;

namespace Autoszerelo.UI.Services.Interfaces
{
    public interface IUgyfelService
    {
        public Task<HttpStatusCode> AddAsync(Ugyfel ugyfel);
        public Task<Ugyfel> GetAsync(Guid ID);
        public Task<IEnumerable<Ugyfel>> GetAllAsync();
        public Task<HttpStatusCode> UpdateAsync(Ugyfel ugyfel);
        public Task<HttpStatusCode> DeleteAsync(Guid ID);
    }
}
