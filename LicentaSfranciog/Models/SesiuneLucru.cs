using System.ComponentModel.DataAnnotations;

namespace LicentaSfranciog.Models
{
    public class SesiuneLucru
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string avocat { get; set; }
        [Required]
        [CustomValidation(typeof(SesiuneLucru), "ValidateStartTime", ErrorMessage = "Valoarea pentru StartTime un poate fi in trecut!")]
        public DateTime DataCal { get; set; }
        [Required]
        public int numarOre { get; set; }
        //relational data
        public virtual Proces Proces { get; set; }
        
        //constructors and methods
        public SesiuneLucru() { }

        public SesiuneLucru(IFormCollection form, Proces proces)
        {
            avocat = form["SesiuneLucru.avocat"].ToString();
            DataCal = DateTime.Parse(form["SesiuneLucru.DataCal"].ToString());
            numarOre = int.Parse(form["SesiuneLucru.numarOre"].ToString());
            Proces = proces;
        }
        public void UpdateSesiuneLucru(IFormCollection form, Proces proces)
        {
            avocat = form["SesiuneLucru.avocat"].ToString();
            DataCal = DateTime.Parse(form["SesiuneLucru.DataCal"].ToString());
            numarOre = int.Parse(form["SesiuneLucru.numarOre"].ToString());
            Proces = proces;
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
