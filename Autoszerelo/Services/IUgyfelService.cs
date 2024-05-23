using Autoszerelo.DataClasses;

namespace Autoszerelo.Services
{
    public interface IUgyfelService
    {
        public void Add(Ugyfel ugyfel);
        public void Get(Guid ID);
        public void GetAll();
        public void Update(Ugyfel ugyfel);
        public void Delete(Guid ID);
    }
}
