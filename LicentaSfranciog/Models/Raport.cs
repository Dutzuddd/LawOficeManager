using LicentaSfranciog.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaSfranciog.Models

{
    public class Raport
    {
        [Key]
        public int Id { get; set; }
        public string? NumeProces { get; set; }
        public int OreLucrate { get; set; }
        public decimal Facturat { get; set; }
        public decimal Cheltuieli { get; set; }
        public DateTime DataRaport { get; set; }

        //relational data
        public virtual Proces Proces { get; set; }

        public Raport() { }

        public Raport(Proces proces)
        {
            Proces = proces;
            NumeProces = proces.Nume;
            OreLucrate = proces.OreLucrate;
            Cheltuieli = 0;            
            DataRaport = DateTime.Now;
            using (var dbContext = new ApplicationDbContext())
            {
                Facturat = dbContext.Facturi
                    .Where(f => f.Proces.Id == proces.Id)
                    .Sum(f => f.Pret);
            }
        }

    }
}
