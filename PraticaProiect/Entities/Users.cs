using System.ComponentModel.DataAnnotations;

namespace PracticaProiect.Entities
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(150)]
        public string Nume { get; set; }

        [MaxLength(150)]
        public string Prenume { get; set; }

        [MaxLength(150)]
        public string Parola { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }
    }

}
