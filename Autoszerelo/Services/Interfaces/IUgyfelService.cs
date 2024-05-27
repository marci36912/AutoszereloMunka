using Autoszerelo.DataClasses;

namespace Autoszerelo.Services.Interfaces
{
    public interface IUgyfelService
    {
        public Task AddAsync(Ugyfel ugyfel);
        public Task<Ugyfel> GetAsync(Guid ID);
        public List<Ugyfel> GetAll();
        public Task UpdateAsync(Ugyfel ugyfel);
        public Task DeleteAsync(Guid ID);
    }
}
