using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaProiect.Entities
{
    public class Categorii_Meniu
    {
        [ForeignKey(Users.Id)]
        public Guid Id { get; set; }

        [MaxLength(150)]
        public string Adresa { get; set; }

        [MaxLength(150)]
        public string Meniu { get; set; }

        [MaxLength(10)]
        public string Telefon { get; set; }
    }
}
