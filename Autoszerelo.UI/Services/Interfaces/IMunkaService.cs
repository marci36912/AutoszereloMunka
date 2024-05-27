using Autoszerelo.DataClasses;

namespace Autoszerelo.UI.Services.Interfaces
{
    public interface IMunkaService
    {
        public Task AddAsync(Munka munka);
        public Task<Munka> GetAsync(Guid ID);
        public Task<IEnumerable<Munka>> GetAllAsync();
        public Task UpdateAsync(Munka munka);
        public Task DeleteAsync(Guid ID);
        public Task NextWorkingStateAsync(Guid ID);
    }
}
