using PracticaProiect.Entities;
using System.ComponentModel.DataAnnotations;

namespace PraticaProiect.Entities
{
    public class OrderMenu
    {
        [Key]
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Guid MenuID { get; set; }
        public Order Order { get; set; }
        public Menu Menu { get; set; }
        public bool? Deleted { get; set; } 
    }
}
