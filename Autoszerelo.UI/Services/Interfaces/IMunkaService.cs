using Autoszerelo.DataClasses;

namespace Autoszerelo.UI.Services.Interfaces
{
    public interface IMunkaService
    {
        public Task Add(Munka munka);
        public Task<Munka> Get(Guid ID);
        public Task<List<Munka>> GetAll();
        public Task Update(Munka munka);
        public Task Delete(Guid ID);
        public Task NextWorkingState(Guid ID);
    }
}
