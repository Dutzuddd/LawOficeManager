using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace LicentaSfranciog.Models.ViewModels
{
    public class EventViewModel
    {
        public Eveniment Eveniment { get; set; }
        public List<SelectListItem> Loc = new List<SelectListItem>();
        public string LocationName { get; set; }

        public EventViewModel(Eveniment myevent, List<Loc> locations)
        {
            Eveniment = myevent;
            LocationName = myevent.Location.Name;
            foreach (var loc in locations)
            {
                Loc.Add(new SelectListItem { Text = loc.Name });
            }
        }

        public EventViewModel(List<Loc> locations)
        {
            foreach (var loc in locations)
            {
                Loc.Add(new SelectListItem { Text = loc.Name });
            }
        }
        public EventViewModel()
        {

        }
    }
}
