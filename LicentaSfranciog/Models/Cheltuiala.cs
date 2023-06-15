using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaSfranciog.Models
{
    public class Cheltuiala
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titlu { get; set; }
        [Required]
        public string Persoana { get; set; }
        [Required]
        [CustomValidation(typeof(Cheltuiala), "ValidateStartTime", ErrorMessage = "Valoarea pentru StartTime un poate fi in trecut!")]
        public DateTime Data { get; set; }
        [Required]
        [DisplayName("Suma")]
        [RegularExpression(@"^(0|[1-9]\d*)$|^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Invalid Price")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid - Suma; Max 18 digits")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Suma { get; set; }
        //relational data
        public virtual Proces Proces { get; set; }

        //methods
        public Cheltuiala() { }

        public Cheltuiala(IFormCollection form, Proces proces)
        {
            Titlu = form["Cheltuiala.Titlu"].ToString();
            Persoana = form["Cheltuiala.Persoana"].ToString();
            Data = DateTime.Parse(form["Cheltuiala.Data"].ToString());
            Suma = decimal.Parse(form["Cheltuiala.Suma"].ToString());
            Proces = proces;
        }
        public void UpdateCheltuiala(IFormCollection form, Proces proces)
        {
            Titlu = form["Cheltuiala.Titlu"].ToString();
            Persoana = form["Cheltuiala.Persoana"].ToString();
            Data = DateTime.Parse(form["Cheltuiala.Data"].ToString());
            Suma = decimal.Parse(form["Cheltuiala.Suma"].ToString());
            Proces = proces;
        }

        public static ValidationResult ValidateStartTime(DateTime Data, ValidationContext context)
        {
            if (Data < DateTime.Now)
            {
                return new ValidationResult("Valoarea pentru Data trebuie să fie o valoare actuală.");
            }
            return ValidationResult.Success;
        }

    }
}
