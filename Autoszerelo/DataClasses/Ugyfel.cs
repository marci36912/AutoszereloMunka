using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Autoszerelo.DataClasses
{
    public class Ugyfel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Ugyfelszam {  get; set; }
        [RegularExpression("^[A-Za-z]+[A-Za-z]*", ErrorMessage = "A nevnek csak kis, es nagybetuket szabad tartalmaznia!"),
            MinLength(3, ErrorMessage = "Legalabb harom karakter megadasa kotelezo!"),
            MaxLength(50, ErrorMessage = "Legfeljebb 50 karakter megadasa engedelyezett!")]
        public string Nev {  get; set; }
        [RegularExpression("[^\\s-]+"),
            MinLength(3, ErrorMessage = "Legalabb harom karakter megadasa kotelezo!"),
            MaxLength(100, ErrorMessage = "Legfeljebb 100 karakter megadasa engedelyezett!")]
        public string Lakcim { get; set; }
        [EmailAddress,
            MinLength(3, ErrorMessage = "Legalabb harom karakter megadasa kotelezo!"),
            MaxLength(100, ErrorMessage = "Legfeljebb 100 karakter megadasa engedelyezett!")]
        public string Email { get; set; }
        

        //Navigation
        public virtual ICollection<Munka> Munkak {  get; set; }
    }
}
