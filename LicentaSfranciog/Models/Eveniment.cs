using LicentaSfranciog.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace LicentaSfranciog.Models
{
    public class Eveniment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nume { get; set; }
        public string Descriere { get; set; }
        [Required]
        [CustomValidation(typeof(Eveniment), "ValidateStartTime", ErrorMessage = "Valoarea pentru StartTime un poate fi in trecut!")]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        // relatiile dintre entitati event-location
        public virtual Loc Location { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Eveniment(IFormCollection form, Loc location)
        {

            Nume = form["Eveniment.Nume"].ToString();
            Descriere = form["Eveniment.Descriere"].ToString();
            StartTime = DateTime.Parse(form["Eveniment.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Eveniment.EndTime"].ToString());
            Location = location;
        }
        public void UpdateEveniment(IFormCollection form, Loc location)
        {

            Nume = form["Eveniment.Nume"].ToString();
            Descriere = form["Eveniment.Descriere"].ToString();
            StartTime = DateTime.Parse(form["Eveniment.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Eveniment.EndTime"].ToString());
            Location = location;
        }
        public Eveniment() { }

        //validate start time
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
