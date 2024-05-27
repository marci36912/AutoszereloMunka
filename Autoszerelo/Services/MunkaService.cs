using Autoszerelo.Database;
using Autoszerelo.DataClasses;
using Autoszerelo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task AddAsync(Munka munka)
        {
            await _dbContext.Munkak.AddAsync(munka);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"New job ({munka.MunkaKategoria.ToString()}) recorded as {munka.MunkaAzonosito} for {munka.UgyfelSzam} - {munka.Rendszam}");
        }

        public async Task DeleteAsync(Guid ID)
        {
            var munka = GetAsync(ID);
            _dbContext.Munkak.Remove(munka.Result);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Job deleted from the database: {ID}");
        }

        public async Task<Munka> GetAsync(Guid ID)
        {
            var munka = await _dbContext.Munkak.FirstOrDefaultAsync(x => x.MunkaAzonosito == ID);

            _logger.LogInformation("Job querried from the database");
            return munka;
        }

        public List<Munka> GetAll()
        {
            _logger.LogInformation("All jobs querried from the database");
            return _dbContext.Munkak.ToList();
        }

        public async Task UpdateAsync(Munka munka)
        {
            var updatedMunka = GetAsync(munka.MunkaAzonosito);

            if (updatedMunka.Result != null)
            {
                updatedMunka.Result.UgyfelSzam = munka.UgyfelSzam;
                updatedMunka.Result.Rendszam = munka.Rendszam;
                updatedMunka.Result.GyartasiEv = munka.GyartasiEv;
                updatedMunka.Result.MunkaKategoria = munka.MunkaKategoria;
                updatedMunka.Result.HibaRovidLeirasa = munka.HibaRovidLeirasa;
                updatedMunka.Result.HibaSulyossaga = munka.HibaSulyossaga;

                await _dbContext.SaveChangesAsync();
                _logger.LogInformation($"Jobs information updated ({updatedMunka.Result.MunkaAzonosito})");
            }
        }

        public async Task NextWorkingStateAsync(Guid ID)
        {
            var munka = GetAsync(ID);

            if(munka.Result.MunkaAllapot == MunkaAllapot.Befejezett)
            {
                return;
            }

            munka.Result.MunkaAllapot =  munka.Result.MunkaAllapot + 1;

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Jobs status updated ({ID})");
        }
    }
}
