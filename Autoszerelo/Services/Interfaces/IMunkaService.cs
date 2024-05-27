using Autoszerelo.DataClasses;

namespace Autoszerelo.Services.Interfaces
{
    public interface IMunkaService
    {
        public Task AddAsync(Munka munka);
        public Task<Munka> GetAsync(Guid ID);
        public List<Munka> GetAll();
        public Task UpdateAsync(Munka munka);
        public Task DeleteAsync(Guid ID);
        public Task NextWorkingStateAsync(Guid ID);
    }
}
