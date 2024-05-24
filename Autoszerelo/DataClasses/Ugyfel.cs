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
        public string Nev {  get; set; }
        public string Lakcim { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        

        //Navigation
        public virtual ICollection<Munka> Munkak {  get; set; }
    }
}
