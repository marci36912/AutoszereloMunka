using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoszerelo.DataClasses
{
    public class Munka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MunkaAzonosito { get; set; }
        [ForeignKey("Ugyfelek")]
        public Guid UgyfelSzam {  get; set; }
        [RegularExpression("^[A-Z]{3}-((00[1-9])|(0[1-9][0-9])|([1-9][0-9]{2}))$", ErrorMessage = "Nem megfelelo formatum! Pelda helyes hasznalata: AAA-001")]
        public string Rendszam { get; set; } = null!;
        [Range(typeof(DateOnly), "1900-01-01", "2030-01-01", ErrorMessage = "1900 es 2030 kozti datum adhato csak meg!")]
        public DateOnly GyartasiEv {  get; set; }
        public MunkaKategoria MunkaKategoria { get; set; }
        [RegularExpression(@"^\S(.*\S)?$", ErrorMessage = "A szoveg csak betuket es szamokat tartalmazhat!"),
            MinLength(3, ErrorMessage = "Legalabb harom karakter megadasa kotelezo!"),
            MaxLength(100, ErrorMessage = "Legfeljebb 100 karakter megadasa engedelyezett!")]
        public string HibaRovidLeirasa { get; set; } = null!;
        [Range(1,10, ErrorMessage = "Csak 1 es 10 kozotti ertek adhato meg!")]
        public int HibaSulyossaga { get; set; }
        public MunkaAllapot MunkaAllapot { get; set; } = MunkaAllapot.Felvett;


        //Navigation
        public virtual Ugyfel Ugyfelek { get; set; } = null!;
    }
}
