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
        [RegularExpression("^[A-Z]{3}-((00[1-9])|(0[1-9][0-9])|([1-9][0-9]{2}))$", ErrorMessage = "Nem megfelelo formatum! Pelda helyes hasznalatra: AAA-001")]
        public string Rendszam { get; set; } = null!;
        [Range(typeof(DateOnly), "1900-01-01", "2030-01-01")]
        public DateOnly GyartasiEv {  get; set; }
        public MunkaKategoria MunkaKategoria { get; set; }
        [RegularExpression("[^\\S-]+", ErrorMessage = "A szoveg nem tartalmazhat csak szokozoket!"),
            MinLength(3, ErrorMessage = "Legalabb harom karakter megadasa kotelezo!"),
            MaxLength(100, ErrorMessage = "Legfeljebb 100 karakter megadasa engedelyezett!")]
        public string HibaRovidLeirasa { get; set; } = null!;
        [Range(1,10)]
        public int HibaSulyossaga { get; set; }
        public MunkaAllapot MunkaAllapot { get; set; } = MunkaAllapot.Felvett;
     

        //Navigation
        public virtual Ugyfel Ugyfelek {  get; set; } = null!;
    }
}
