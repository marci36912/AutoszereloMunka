using System.ComponentModel.DataAnnotations;

namespace Autoszerelo.DataClasses
{
    public class Ugyfel
    {
        public Guid Ugyfelszam {  get; private set; }
        public string Nev {  get; private set; }
        public string Lakcim { get; private set; }
        [EmailAddress]
        public string Email { get; private set; }
    }
}
