using Autoszerelo.DataClasses;

namespace Autoszerelo.UI.Services.Interfaces
{
    public interface IUgyfelService
    {
        public Task Add(Ugyfel ugyfel);
        public Task<Ugyfel> Get(Guid ID);
        public Task<IEnumerable<Ugyfel>> GetAll();
        public Task Update(Ugyfel ugyfel);
        public Task Delete(Guid ID);
    }
}
