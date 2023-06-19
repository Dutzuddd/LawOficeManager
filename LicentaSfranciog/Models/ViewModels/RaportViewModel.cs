using Microsoft.AspNetCore.Mvc.Rendering;

namespace LicentaSfranciog.Models.ViewModels
{
    public class RaportViewModel
    {
        public Raport Raport { get; set; }
        public List<SelectListItem> Proces = new List<SelectListItem>();

        public RaportViewModel() { }

        public RaportViewModel(List<Proces> procese)
        {
            foreach (var proc in procese)
            {
                Proces.Add(new SelectListItem { Text = proc.Nume });
            }
        }
    }
}
