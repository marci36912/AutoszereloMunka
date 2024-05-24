using Autoszerelo.Database;
using Autoszerelo.DataClasses;

namespace Autoszerelo.Services
{
    public class UgyfelService : IUgyfelService
    {
        private AutoszereloDbContext _dbContext;
        public UgyfelService(AutoszereloDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Ugyfel ugyfel)
        {
            _dbContext.Ugyfelek.Add(ugyfel);

            _dbContext.SaveChanges();
        }

        public void Delete(Guid ID)
        {
            var ugyfel = Get(ID);
            
            _dbContext.Ugyfelek.Remove(ugyfel);

            _dbContext.SaveChanges();
        }

        public Ugyfel Get(Guid ID)
        {
            return _dbContext.Ugyfelek.Find(ID);
        }

        List<Ugyfel> IUgyfelService.GetAll()
        {
            return _dbContext.Ugyfelek.ToList();
        }

        void IUgyfelService.Update(Ugyfel ugyfel)
        {
            var updatedUgyfel = Get(ugyfel.Ugyfelszam);

            updatedUgyfel.Nev = ugyfel.Nev;
            updatedUgyfel.Lakcim = ugyfel.Lakcim;
            updatedUgyfel.Email = ugyfel.Email;

            _dbContext.SaveChanges();
        }
    }
}
