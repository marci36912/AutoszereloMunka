using System.ComponentModel.DataAnnotations;

namespace Autoszerelo.DataClasses
{
    public class Munka
    {
        public Guid MunkaAzonosito { get; private set; }
        public Guid UgyfelSzam {  get; private set; }
        [RegularExpression("^[A-Z]{3}-[0-9]{3}$")]
        public string Rendszam { get; private set; }
        [Range(typeof(DateOnly), "1900-01-01", "2030-01-01")]
        public DateOnly GyartasiEv {  get; private set; }
        public MunkaKategoria MunkaKategoria { get; private set; }
        public string HibaRovidLeirasa { get; private set; }
        //validacio
        [Range(1,10)]
        public int HibaSulyossaga { get; private set; }
        public MunkaAllapot MunkaAllapot { get; private set; }
    }
}
