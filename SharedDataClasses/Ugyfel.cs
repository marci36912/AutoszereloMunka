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
        [RegularExpression(@"^\S([A-Za-z\s]*\S)?$", ErrorMessage = "A nev nem kezdodhet, es nem vegzodhet szokozzel!"),
            MinLength(3, ErrorMessage = "Legalabb harom karakter megadasa kotelezo!"),
            MaxLength(50, ErrorMessage = "Legfeljebb 50 karakter megadasa engedelyezett!")]
        public string Nev { get; set; } = null!;
        [RegularExpression(@"^\S(.*\S)?$", ErrorMessage = "A szoveg nem kezdodhet, es nem vegzodhet szokozzel!"),
            MinLength(3, ErrorMessage = "Legalabb harom karakter megadasa kotelezo!"),
            MaxLength(100, ErrorMessage = "Legfeljebb 100 karakter megadasa engedelyezett!")]
        public string Lakcim { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Helytelen email formatum! Helyes hasznalata: pelda@pelda.hu"),
            MinLength(3, ErrorMessage = "Legalabb harom karakter megadasa kotelezo!"),
            MaxLength(100, ErrorMessage = "Legfeljebb 100 karakter megadasa engedelyezett!")]
        public string Email { get; set; } = null!;
        

        //Navigation
        public virtual ICollection<Munka>? Munkak {  get; set; }
    }
}
