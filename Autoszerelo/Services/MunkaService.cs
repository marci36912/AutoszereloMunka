using Autoszerelo.Database;
using Autoszerelo.DataClasses;

namespace Autoszerelo.Services
{
    public class MunkaService : IMunkaService
    {
        private readonly AutoszereloDbContext _dbContext;
        private readonly ILogger<Munka> _logger;

        public MunkaService(AutoszereloDbContext dbContext, ILogger<Munka> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Add(Munka munka)
        {
            _dbContext.Munkak.Add(munka);

            _dbContext.SaveChanges();

            _logger.LogInformation($"New job ({munka.MunkaKategoria.ToString()}) recorded as {munka.MunkaAzonosito} for {munka.UgyfelSzam} - {munka.Rendszam}");
        }

        public void Delete(Guid ID)
        {
            var munka = Get(ID);
            _dbContext.Munkak.Remove(munka);

            _dbContext.SaveChanges();

            _logger.LogInformation($"Job deleted from the database: {ID}");
        }

        public Munka Get(Guid ID)
        {
            var munka = _dbContext.Munkak.FirstOrDefault(x => x.MunkaAzonosito == ID);

            _logger.LogInformation("Job querried from the database");
            return munka;
        }

        public List<Munka> GetAll()
        {
            _logger.LogInformation("All jobs querried from the database");
            return _dbContext.Munkak.ToList();
        }

        public void Update(Munka munka)
        {
            var updatedMunka = Get(munka.MunkaAzonosito);

            if (updatedMunka != null)
            {
                updatedMunka.UgyfelSzam = munka.UgyfelSzam;
                updatedMunka.Rendszam = munka.Rendszam;
                updatedMunka.GyartasiEv = munka.GyartasiEv;
                updatedMunka.MunkaKategoria = munka.MunkaKategoria;
                updatedMunka.HibaRovidLeirasa = munka.HibaRovidLeirasa;
                updatedMunka.HibaSulyossaga = munka.HibaSulyossaga;

                _dbContext.SaveChanges();
                _logger.LogInformation($"Jobs information updated ({updatedMunka.MunkaAzonosito})");
            }
        }

        public void NextWorkingState(Guid ID)
        {
            var munka = Get(ID);

            if(munka.MunkaAllapot == MunkaAllapot.Befejezett)
            {
                return;
            }

            munka.MunkaAllapot =  munka.MunkaAllapot + 1;

            _dbContext.SaveChanges();

            _logger.LogInformation($"Jobs status updated ({ID})");
        }
    }
}
