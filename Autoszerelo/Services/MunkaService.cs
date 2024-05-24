using Autoszerelo.Database;
using Autoszerelo.DataClasses;

namespace Autoszerelo.Services
{
    public class MunkaService : IMunkaService
    {
        private readonly AutoszereloDbContext _dbContext;

        public MunkaService(AutoszereloDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Munka munka)
        {
            _dbContext.Munkak.Add(munka);

            _dbContext.SaveChanges();
        }

        public void Delete(Guid ID)
        {
            var munka = Get(ID);
            _dbContext.Munkak.Remove(munka);

            _dbContext.SaveChanges();
        }

        public Munka Get(Guid ID)
        {
            return _dbContext.Munkak.Find(ID);
        }

        public List<Munka> GetAll()
        {
            return _dbContext.Munkak.ToList();
        }

        public void Update(Munka munka)
        {
            var updatedMunka = Get(munka.MunkaAzonosito);

            updatedMunka.UgyfelSzam = munka.UgyfelSzam;
            updatedMunka.Rendszam = munka.Rendszam;
            updatedMunka.GyartasiEv = munka.GyartasiEv;
            updatedMunka.MunkaKategoria = munka.MunkaKategoria;
            updatedMunka.HibaRovidLeirasa = munka.HibaRovidLeirasa;
            updatedMunka.HibaSulyossaga = munka.HibaSulyossaga;
            updatedMunka.MunkaAllapot = munka.MunkaAllapot;

            _dbContext.SaveChanges();
        }
    }
}
