using Autoszerelo.DataClasses;

namespace Autoszerelo.Services
{
    public interface IMunkaService
    {
        public void Add(Munka ugyfel);
        public void Get(Guid ID);
        public void GetAll();
        public void Update(Munka ugyfel);
        public void Delete(Guid ID);
    }
}
