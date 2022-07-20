using System.ComponentModel.DataAnnotations;

namespace PracticaProiect.Entities
{
    public class User {
    [Key]
    public Guid Id { get; set; }

    [MaxLength(150)]
    public string FirstName { get; set; }

    [MaxLength(150)]
    public string LastName { get; set; }
    }

}
