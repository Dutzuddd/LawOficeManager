using System.ComponentModel.DataAnnotations;

namespace LicentaSfranciog.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Nume { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Telefonul trebuie să conțină doar cifre.")]
        public string Telefon { get; set; }
        public string? Email { get; set; }
        [Required]
        [StringLength(700)]
        public string Mesaj { get; set; }
        public Contact() { }
    }
}
