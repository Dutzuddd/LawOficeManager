﻿using System.ComponentModel.DataAnnotations;

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
        [StringLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Telefonul trebuie să conțină doar cifre.")]
        public string Telefon { get; set; }
        [Required]
        [StringLength(50)]
        public string Adresa { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        public Client(IFormCollection form)
        {
            Id = int.Parse(form["Id"]);
            Tip = form["Tip"];
            Nume = form["Nume"];
            Prenume = form["Prenume"];
            CNPorCUI = form["CNPorCUI"];
            Telefon = form["Telefon"];
            Adresa = form["Adresa"];
            Email = form["Email"];
        }
        public Client() { }
        public void UpdateClient(IFormCollection form)
        {
            Id = int.Parse(form["Id"]);
            Tip = form["Tip"];
            Nume = form["Nume"];
            Prenume = form["Prenume"];
            CNPorCUI = form["CNPorCUI"];
            Telefon = form["Telefon"];
            Adresa = form["Adresa"];
            Email = form["Email"];
        }
        
    }
}
