using Autoszerelo.Database;
using Autoszerelo.DataClasses;

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

        public void Add(Ugyfel ugyfel)
        {
            _dbContext.Ugyfelek.Add(ugyfel);

            _dbContext.SaveChanges();

            _logger.LogInformation($"New costumer recorded: {ugyfel.Nev}");
        }

        public void Delete(Guid ID)
        {
            var ugyfel = Get(ID);
            
            _dbContext.Ugyfelek.Remove(ugyfel);

            _dbContext.SaveChanges();

            _logger.LogInformation($"{ugyfel.Nev} deleted from the database");
        }

        public Ugyfel Get(Guid ID)
        {
            _logger.LogInformation($"Costumer querried from database");
            return _dbContext.Ugyfelek.Find(ID);
        }

        List<Ugyfel> IUgyfelService.GetAll()
        {
            _logger.LogInformation($"All costumers querried from database");
            return _dbContext.Ugyfelek.ToList();
        }

        void IUgyfelService.Update(Ugyfel ugyfel)
        {
            var updatedUgyfel = Get(ugyfel.Ugyfelszam);

            if (updatedUgyfel != null)
            {
                updatedUgyfel.Nev = ugyfel.Nev;
                updatedUgyfel.Lakcim = ugyfel.Lakcim;
                updatedUgyfel.Email = ugyfel.Email;

                _dbContext.SaveChanges();

                _logger.LogInformation($"{updatedUgyfel.Nev} costumers informations updated");
            }
        }
    }
}
