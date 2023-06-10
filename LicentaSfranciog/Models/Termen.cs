using System.ComponentModel.DataAnnotations;

namespace LicentaSfranciog.Models
{
    public class Termen
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Descriere { get; set; }
        public string? Avocat { get; set; }
        [Required]
        [CustomValidation(typeof(Termen), "ValidateStartTime", ErrorMessage = "Valoarea pentru StartTime un poate fi in trecut!")]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        //relational data
        public virtual Proces Proces { get; set; }
        public virtual Loc Loc { get; set; }

        public Termen(IFormCollection form, Proces proces, Loc loc)
        {
            Nume = form["Termen.Nume"].ToString();
            Descriere = form["Termen.Descriere"].ToString();
            Avocat = form["Termen.Avocat"].ToString();
            StartTime = DateTime.Parse(form["Termen.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Termen.EndTime"].ToString());
            Proces = proces;
            Loc = loc;
        }
        public Termen() { }
        public void UpdateTermen(IFormCollection form, Proces proces, Loc loc)
        {
            Nume = form["Termen.Nume"].ToString();
            Descriere = form["Termen.Descriere"].ToString();
            Avocat = form["Termen.Avocat"].ToString();
            StartTime = DateTime.Parse(form["Termen.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Termen.EndTime"].ToString());
            Proces = proces;
            Loc = loc;
        }

        public static ValidationResult ValidateStartTime(DateTime startTime, ValidationContext context)
        {
            if (startTime < DateTime.Now)
            {
                return new ValidationResult("Valoarea pentru StartTime trebuie să fie o valoare actuală.");
            }
            return ValidationResult.Success;
        }
    }
}
