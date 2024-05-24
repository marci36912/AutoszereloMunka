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
        [RegularExpression("^[A-Z]{3}-[0-9]{3}$")]
        public string Rendszam { get; set; }
        [Range(typeof(DateOnly), "1900-01-01", "2030-01-01")]
        public DateOnly GyartasiEv {  get; set; }
        public MunkaKategoria MunkaKategoria { get; set; }
        public string HibaRovidLeirasa { get; set; }
        //validacio
        [Range(1,10)]
        public int HibaSulyossaga { get; set; }
        public MunkaAllapot MunkaAllapot { get; set; }
     
        //Navigation
        public virtual Ugyfel Ugyfelek {  get; set; }
    }
}
