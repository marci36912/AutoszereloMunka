namespace Autoszerelo.DataClasses
{
    public class Ugyfel
    {
        public Guid Ugyfelszam {  get; private set; }
        public string Nev {  get; private set; }
        public string Lakcim { get; private set; }
        //validacio
        public string Email { get; private set; }
    }
}
