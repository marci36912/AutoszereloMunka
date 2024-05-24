using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Autoszerelo.DataClasses
{
    public class Ugyfel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Ugyfelszam {  get; private set; }
        [ForeignKey(nameof(Ugyfel))]
        public string Nev {  get; private set; }
        public string Lakcim { get; private set; }
        [EmailAddress]
        public string Email { get; private set; }
    }
}
