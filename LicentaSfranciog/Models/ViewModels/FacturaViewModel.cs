using Microsoft.AspNetCore.Mvc.Rendering;

namespace LicentaSfranciog.Models.ViewModels
{
    public class FacturaViewModel
    {
        public Factura Factura { get; set; }
        public List<SelectListItem> Proces = new List<SelectListItem>();
        public List<SelectListItem> Client = new List<SelectListItem>();

        public FacturaViewModel() { }   

        public FacturaViewModel(Factura factura, List<Proces> procese, List<Client> clienti)
        {
            Factura = factura;
            foreach (var proc in procese)
            {
                Proces.Add(new SelectListItem { Text = proc.Nume });
            }
            foreach (var cl in clienti)
            {
                Client.Add(new SelectListItem { Text = cl.Nume });
            }
        }

        public FacturaViewModel(List<Proces> procese, List<Client> clienti)
        {
            
            foreach (var proc in procese)
            {
                Proces.Add(new SelectListItem { Text = proc.Nume });
            }
            foreach (var cl in clienti)
            {
                Client.Add(new SelectListItem { Text = cl.Nume });
            }
        }
    }
}
