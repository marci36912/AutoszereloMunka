using Autoszerelo.DataClasses;

namespace Autoszerelo.Services
{
    public class MunkaService : IMunkaService
    {
        private List<Munka> _munkak = new();
        void IMunkaService.Add(Munka munka)
        {
            _munkak.Add(munka);
        }

        void IMunkaService.Delete(Guid ID)
        {
            _munkak.Remove(_munkak.FirstOrDefault(x => x.MunkaAzonosito == ID));
        }

        Munka IMunkaService.Get(Guid ID)
        {
            return _munkak.FirstOrDefault(x => x.MunkaAzonosito == ID);
        }

        List<Munka> IMunkaService.GetAll()
        {
            return _munkak;
        }

        void IMunkaService.Update(Munka munka)
        {
            int index = _munkak.IndexOf(_munkak.FirstOrDefault(x => x.MunkaAzonosito == munka.MunkaAzonosito));
            _munkak[index] = munka;
        }
    }
}
