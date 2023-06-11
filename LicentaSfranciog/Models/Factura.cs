using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaSfranciog.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Pret")]
        [RegularExpression(@"^(0|[1-9]\d*)$|^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Invalid Price")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Target Price; Max 18 digits")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Pret { get; set; }
        [Required]
        public DateTime Data { get; set; }

        public virtual Client Client { get; set; }
        public virtual Proces Proces { get; set; }

        public Factura () { }
    }
}
