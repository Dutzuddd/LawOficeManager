using System.ComponentModel.DataAnnotations;

namespace LicentaSfranciog.Models
{
    public class Loc
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(50)]
        public string? Adresa { get; set; }
    }
}
