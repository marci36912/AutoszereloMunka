using Autoszerelo.DataClasses;

namespace Autoszerelo.Services
{
    public class UgyfelService : IUgyfelService
    {
        private List<Ugyfel> _ugyfelek = new();
        void IUgyfelService.Add(Ugyfel ugyfel)
        {
            _ugyfelek.Add(ugyfel);
        }

        void IUgyfelService.Delete(Guid ID)
        {
            _ugyfelek.Remove(_ugyfelek.FirstOrDefault(x => x.Ugyfelszam == ID));
        }

        Ugyfel IUgyfelService.Get(Guid ID)
        {
            return _ugyfelek.FirstOrDefault(x => x.Ugyfelszam == ID);
        }

        List<Ugyfel> IUgyfelService.GetAll()
        {
            return _ugyfelek;
        }

        void IUgyfelService.Update(Ugyfel ugyfel)
        {
            int index =  _ugyfelek.FindIndex(x => x.Ugyfelszam == ugyfel.Ugyfelszam);
            _ugyfelek[index] = ugyfel;
        }
    }
}
