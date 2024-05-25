using Autoszerelo.DataClasses;

namespace Autoszerelo.Services
{
    public interface IMunkaService
    {
        public void Add(Munka munka);
        public Munka Get(Guid ID);
        public List<Munka> GetAll();
        public void Update(Munka munka);
        public void Delete(Guid ID);
        public void NextWorkingState(Guid ID);
    }
}
