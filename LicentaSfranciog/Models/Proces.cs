using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaSfranciog.Models
{
    public class Proces
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nume { get; set; }
        [Required]
        [StringLength(20)]
        public string Tip { get; set; }
        [Required]
        [StringLength(35)]
        public string Partile { get; set; }
        [Required]
        [StringLength(300)]
        public string Obiect { get; set; }
        public string? Solutie { get; set; }
        public int OreLucrate { get; set; }

        //relational data        
        public virtual Client Client { get; set; }

        //methods
        public Proces() { }

        public Proces (IFormCollection form, Client nclient)
        {           
            Nume = form["Proces.Nume"].ToString();
            Tip = form["Proces.Tip"].ToString();
            Partile = form["Proces.Partile"].ToString();
            Obiect = form["Proces.Obiect"].ToString();
            Solutie = form["Proces.Solutie"].ToString();
            OreLucrate = int.Parse(form["Proces.OreLucrate"].ToString());
            Client = nclient;
        }
        public void UpdateProces(IFormCollection form, Client nclient)
        {           
            Nume = form["Proces.Nume"].ToString();
            Tip = form["Proces.Tip"].ToString();
            Partile = form["Proces.Partile"].ToString();
            Obiect = form["Proces.Obiect"].ToString();
            Solutie = form["Proces.Solutie"].ToString();
            OreLucrate = int.Parse(form["Proces.OreLucrate"].ToString());
            Client = nclient;
        }
    }
}
