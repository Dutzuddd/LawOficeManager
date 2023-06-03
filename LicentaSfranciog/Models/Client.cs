using System.ComponentModel.DataAnnotations;

namespace LicentaSfranciog.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(2)]
        public string Tip { get; set; }
        [Required]
        [StringLength(50)]
        public string Nume { get; set; }
        [Required]
        [StringLength(50)]
        public string Prenume { get; set; }
        [Required]
        public string CNPorCUI { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Adresa { get; set; }
        public string Email { get; set; }
    }
}
