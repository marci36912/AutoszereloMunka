using Autoszerelo.DataClasses;

namespace Autoszerelo.UI.Services.Interfaces
{
    public interface IUgyfelService
    {
        public Task AddAsync(Ugyfel ugyfel);
        public Task<Ugyfel> GetAsync(Guid ID);
        public Task<IEnumerable<Ugyfel>> GetAllAsync();
        public Task UpdateAsync(Ugyfel ugyfel);
        public Task DeleteAsync(Guid ID);
    }
}
