using Autoszerelo.Database;
using Autoszerelo.DataClasses;
using Microsoft.EntityFrameworkCore;

namespace Autoszerelo.Services
{
    public class UgyfelService : IUgyfelService
    {
        private readonly AutoszereloDbContext _dbContext;
        private readonly ILogger<Ugyfel> _logger;
        public UgyfelService(AutoszereloDbContext dbContext, ILogger<Ugyfel> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task Add(Ugyfel ugyfel)
        {
            await _dbContext.Ugyfelek.AddAsync(ugyfel);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"New costumer recorded: {ugyfel.Nev}");
        }

        public async Task Delete(Guid ID)
        {
            var ugyfel = Get(ID);
            
            _dbContext.Ugyfelek.Remove(ugyfel.Result);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"{ugyfel.Result.Nev} deleted from the database");
        }

        public async Task<Ugyfel> Get(Guid ID)
        {
            _logger.LogInformation($"Costumer querried from database");
            return await _dbContext.Ugyfelek.FirstOrDefaultAsync(x => x.Ugyfelszam == ID);
        }

        public async Task<List<Ugyfel>> GetAll()
        {
            _logger.LogInformation($"All costumers querried from database");
            return await _dbContext.Ugyfelek.ToListAsync();
        }

        public async Task Update(Ugyfel ugyfel)
        {
            var updatedUgyfel = Get(ugyfel.Ugyfelszam);

            if (updatedUgyfel.Result != null)
            {
                updatedUgyfel.Result.Nev = ugyfel.Nev;
                updatedUgyfel.Result.Lakcim = ugyfel.Lakcim;
                updatedUgyfel.Result.Email = ugyfel.Email;

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"{updatedUgyfel.Result.Nev} costumers informations updated");
            }
        }
    }
}
