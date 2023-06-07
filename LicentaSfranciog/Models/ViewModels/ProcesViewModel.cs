using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace LicentaSfranciog.Models.ViewModels
{
    public class ProcesViewModel
    {
        public Proces Proces { get; set; }
        public List<SelectListItem> Client { get; set; } = new List<SelectListItem>();
        public string NumeClient { get; set; }

        public ProcesViewModel(Proces myProces,List<Client> clients)
        {
            Proces = myProces;
            NumeClient = myProces.Client.Nume;
            foreach(var cl in clients)
            {
                Client.Add(new SelectListItem { Text = cl.Nume });
            }
        }

        public ProcesViewModel(List<Client> clients)
        {            
            foreach (var cl in clients)
            {
                Client.Add(new SelectListItem { Text = cl.Nume });
            }
        }
        public ProcesViewModel()
        {

        }
    }
}
