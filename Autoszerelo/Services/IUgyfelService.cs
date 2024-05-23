using Autoszerelo.DataClasses;

namespace Autoszerelo.Services
{
    public interface IUgyfelService
    {
        public void Add(Ugyfel ugyfel);
        public Ugyfel Get(Guid ID);
        public List<Ugyfel> GetAll();
        public void Update(Ugyfel ugyfel);
        public void Delete(Guid ID);
    }
}
