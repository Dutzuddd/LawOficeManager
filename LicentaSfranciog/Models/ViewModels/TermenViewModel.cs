using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace LicentaSfranciog.Models.ViewModels
{
    public class TermenViewModel
    {
        public Termen Termen { get; set; }
        public List<SelectListItem> Proces  = new List<SelectListItem>();
        public List<SelectListItem> Loc = new List<SelectListItem>();

        public TermenViewModel(Termen myTermen, List<Proces> procese, List<Loc> locuri)
        {
            Termen = myTermen;            
            foreach (var proc in procese)
            {
                Proces.Add(new SelectListItem { Text = proc.Nume });
            }
            foreach (var loc in locuri)
            {
                Loc.Add(new SelectListItem { Text = loc.Name });
            }
        }
        public TermenViewModel(List<Proces> procese, List<Loc> locuri)
        {
            foreach (var proc in procese)
            {
                Proces.Add(new SelectListItem { Text = proc.Nume });
            }
            foreach (var loc in locuri)
            {
                Loc.Add(new SelectListItem { Text = loc.Name });
            }
        }
        public TermenViewModel()
        {

        }
    }
}
