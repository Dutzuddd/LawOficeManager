using Microsoft.AspNetCore.Mvc.Rendering;

namespace LicentaSfranciog.Models.ViewModels
{
    public class CheltuialaViewModel
    {
        public Cheltuiala Cheltuiala { get; set; }
        public List<SelectListItem> Proces = new List<SelectListItem>();
        public string NumeProces { get; set; }

        public CheltuialaViewModel() { }

        public CheltuialaViewModel(Cheltuiala cheltuiala, List<Proces> proces) 
        {
            Cheltuiala = cheltuiala;
            NumeProces = cheltuiala.Proces.Nume;
            foreach (var proc in proces)
            {
                Proces.Add(new SelectListItem { Text = proc.Nume });
            }
        }
        public CheltuialaViewModel( List<Proces> proces)
        {            
            foreach (var proc in proces)
            {
                Proces.Add(new SelectListItem { Text = proc.Nume });
            }
        }
    }
}
