using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace LicentaSfranciog.Models.ViewModels
{
    public class SesiuneLucruViewModel
    {
        public SesiuneLucru SesiuneLucru { get; set; }

        public List<SelectListItem> Proces = new List<SelectListItem>();
        public string NumeProces { get; set; }

        public SesiuneLucruViewModel() 
        {

        }
        public SesiuneLucruViewModel(SesiuneLucru sesiuneLucru, List<Proces> proces)
        {
            SesiuneLucru = sesiuneLucru;
            NumeProces = sesiuneLucru.Proces.Nume;
            foreach (var proc in proces)
            {
                Proces.Add(new SelectListItem { Text = proc.Nume });
            }
        }
        public SesiuneLucruViewModel(List<Proces> proces)
        {
            foreach (var proc in proces)
            {
                Proces.Add(new SelectListItem { Text = proc.Nume });
            }
        }
    }
}
