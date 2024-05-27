using Autoszerelo.DataClasses;
using System.Net;

namespace Autoszerelo.UI.Services.Interfaces
{
    public interface IMunkaService
    {
        public Task<HttpStatusCode> AddAsync(Munka munka);
        public Task<Munka> GetAsync(Guid ID);
        public Task<IEnumerable<Munka>> GetAllAsync();
        public Task<HttpStatusCode> UpdateAsync(Munka munka);
        public Task<HttpStatusCode> DeleteAsync(Guid ID);
        public Task<HttpStatusCode> NextWorkingStateAsync(Guid ID);
    }
}
