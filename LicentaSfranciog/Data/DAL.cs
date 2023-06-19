using LicentaSfranciog.Models;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace LicentaSfranciog.Data
{
    public interface IDAL
    {
        //client data access layer methods
        public List<Client> GetClients();       
        public Client GetClient(int id);
        public void CreateClient(Client client);
        public void UpdateClient(IFormCollection form);
        public void DeleteClient(int id);

        //proces data access layer methods
        public List<Proces> GetProcese();
        public List<Proces> GetMyProces(int clientId);
        public Proces GetProces(int id);
        public void CreateProces(IFormCollection form);
        public void UpdateProces(IFormCollection form);
        public void DeleteProces(int id);

        //Agenda(Calendar&events) methods
        public List<Eveniment> GetEvenimente();
        public List<Eveniment> GetEvenimenteleMele(string userId);
        public Eveniment GetEveniment(int id);
        public void CreateEveniment(IFormCollection form);
        public void UpdateEveniment(IFormCollection form);
        public void DeleteEveniment(int id);
        public List<Loc> GetLocatii();
        public Loc GetLoc(int id);
        public void CreateLoc(Loc location);
        public void DeleteLoc(int id);

        //Termene DAL methods
        public List<Termen> GetTermene();
        public List<Termen> GetTermenByProces(int procesId);
        public Termen GetTermen(int id);
        public void CreateTermen(IFormCollection form);
        public void UpdateTermen(IFormCollection form);
        public void DeleteTermen(int id);

        //SesiunLucru DAL methods
        public List<SesiuneLucru> GetSesiuniProces(int procesId);
        public SesiuneLucru GetSesiune(int id);
        public void CreateSesiune(IFormCollection form);
        public void UpdateSesiune(IFormCollection form);
        public void DeleteSesiune(int id);
        
        //Factura DAL methods
        public List<Factura> GetFacturi();
        public List<Factura> GetFacturiByProces(int procesId);
        public Factura GetFactura(int id);
        public void CreateFactura(IFormCollection form);
        public void UpdateFactura(IFormCollection form);
        public void DeleteFactura(int id);

        //Contact DAL methhods
        public List<Contact> GetContacte();
        public Contact GetContact(int id);
        public void CreateContact(Contact contact);        
        public void DeleteContact(int id);

        //Cheltuieli Data Access Layer methods
        public List<Cheltuiala> GetCheltuieliProces(int procesId);
        public Cheltuiala GetCheltuiala(int id);
        public void CreateCheltuiala(IFormCollection form);
        public void UpdateCheltuiala(IFormCollection form);
        public void DeleteCheltuiala(int id);

        //Rapoarte DAL
        public List<Raport> GetRapoarte();
        public List<Raport> GetRaportByProces(int procesId);
        public Raport GetRaport(int id);
        public void CreateRaport(IFormCollection form);       
        public void DeleteRaport(int id);

    }
    public class DAL : IDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //client data access layer methods implementation
        public List<Client> GetClients()
        {
            return db.Client.ToList();            
        }        
        
        public Client GetClient(int id)
        {
            return db.Client.FirstOrDefault(x => x.Id == id);
        }
        public void CreateClient(Client client)
        {                      
            db.Client.Add(client);
            db.SaveChanges();
        }
        public void UpdateClient(IFormCollection form)
        {
            var myclient = db.Client.FirstOrDefault(x => x.Id == int.Parse(form["Id"]));
            myclient.UpdateClient(form);
            db.Entry<Client>(myclient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var myClient = db.Client.Find(id);
            db.Client.Remove(myClient);
            db.SaveChanges();
        }

        //Proces DAL methods implementation
        public List<Proces> GetProcese()
        {
            return db.Proces.ToList();
        }
        public List<Proces> GetMyProces(int clientId)
        {
            return db.Proces.Where(x => x.Client.Id == clientId).ToList();
        }
        public Proces GetProces(int id)
        {
            return db.Proces.FirstOrDefault(x => x.Id == id);
        }
        public void CreateProces(IFormCollection form)
        {
            var numeclient = form["Client"].ToString();
            var newProces = new Proces(form, db.Client.FirstOrDefault(x => x.Nume == numeclient));            
            db.Proces.Add(newProces);
            db.SaveChanges();
        }
        public void UpdateProces(IFormCollection form)
        {
            var procesId = int.Parse(form["Proces.Id"]);
            var numeclient = form["client"].ToString();
            var myproces = db.Proces.FirstOrDefault(x => x.Id == procesId);
            var clientP = db.Client.FirstOrDefault(x => x.Nume == numeclient);
            myproces.UpdateProces(form, clientP);
            db.Entry<Proces>(myproces).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteProces(int id)
        {
            var myproces = db.Proces.Find(id);
            db.Proces.Remove(myproces);
            db.SaveChanges();
        }
        //Agenda methods implementation
        public List<Eveniment> GetEvenimente()
        {
            return db.Evenimente.ToList();
        }
        public List<Eveniment> GetEvenimenteleMele(string userId)
        {
            return db.Evenimente.Where(x => x.User.Id == userId).ToList();
        }
        public Eveniment GetEveniment(int id)
        {
            return db.Evenimente.FirstOrDefault(x => x.Id == id);
        }
        public void CreateEveniment(IFormCollection form)
        {
            var locname = form["Loc"].ToString();
            var newEvent = new Eveniment(form, db.Locatii.FirstOrDefault(x => x.Name == locname));
            db.Evenimente.Add(newEvent);
            db.SaveChanges();
        }
        public void UpdateEveniment(IFormCollection form)
        {
            var eventid = int.Parse(form["Eveniment.Id"]);
            var locname = form["Loc"].ToString();
            var myEvent = db.Evenimente.FirstOrDefault(x => x.Id == eventid);
            var location = db.Locatii.FirstOrDefault(x => x.Name == locname);
            myEvent.UpdateEveniment(form, location);
            db.Entry<Eveniment>(myEvent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteEveniment(int id)
        {
            var myEvent = db.Evenimente.Find(id);
            db.Evenimente.Remove(myEvent);
            db.SaveChanges();
        }
        public List<Loc> GetLocatii()
        {
            return db.Locatii.ToList();
        }
        public Loc GetLoc(int id)
        {
            return db.Locatii.Find(id);
        }
        public void CreateLoc(Loc location)
        {
            db.Locatii.Add(location);
            db.SaveChanges();
        }
        public void DeleteLoc(int id)
        {
            var myLoc = db.Locatii.Find(id);
            db.Locatii.Remove(myLoc);
            db.SaveChanges();
        }

        //Termene methods implementation
        public List<Termen> GetTermene()
        {
            return db.Termene.ToList();
        }
        public List<Termen> GetTermenByProces(int procesId)
        {
            return db.Termene.Where(x => x.Proces.Id == procesId).ToList();
        }
        public Termen GetTermen(int id)
        {
            return db.Termene.FirstOrDefault(x => x.Id == id);
        }
        public void CreateTermen(IFormCollection form)
        {
            var numeproces = form["Proces"].ToString();
            var numeloc = form["Loc"].ToString();
            var newTermen = new Termen(form, db.Proces.FirstOrDefault(x => x.Nume == numeproces),
                db.Locatii.FirstOrDefault(x => x.Name == numeloc));
            db.Termene.Add(newTermen);
            db.SaveChanges();
        }
        public void UpdateTermen(IFormCollection form)
        {
            var termenId = int.Parse(form["Termen.Id"]);
            var numeproces = form["Proces"].ToString();
            var numeloc = form["Loc"].ToString();
            var mytermen = db.Termene.FirstOrDefault(x => x.Id == termenId);
            var myproces = db.Proces.FirstOrDefault(x => x.Nume == numeproces);
            var myloc = db.Locatii.FirstOrDefault(x => x.Name == numeloc);
            mytermen.UpdateTermen(form, myproces, myloc);
            db.Entry<Termen>(mytermen).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteTermen(int id)
        {
            var mytermen = db.Termene.Find(id);
            db.Termene.Remove(mytermen);
            db.SaveChanges();
        }

        //SesiuneLucru methods implementation
        public List<SesiuneLucru> GetSesiuniProces(int procesId)
        {
            return db.SeiuniDosar.Where(x => x.Proces.Id == procesId).ToList();
        }
        public SesiuneLucru GetSesiune(int id)
        {
            return db.SeiuniDosar.FirstOrDefault(x => x.Id == id);
        }
        public void CreateSesiune(IFormCollection form)
        {
            var numeproces = form["Proces"].ToString();
            var newSesiune = new SesiuneLucru(form, db.Proces.FirstOrDefault(x => x.Nume == numeproces));
            db.SeiuniDosar.Add(newSesiune);
            db.SaveChanges();
        }
        public void UpdateSesiune(IFormCollection form)
        {
            var sesiuneId = int.Parse(form["SesiuneLucru.Id"]);
            var numeproces = form["Proces"].ToString();
            var sesiuneaMea = db.SeiuniDosar.FirstOrDefault(x => x.Id == sesiuneId);
            var ProcesSesiune = db.Proces.FirstOrDefault(x => x.Nume == numeproces);
            sesiuneaMea.UpdateSesiuneLucru(form, ProcesSesiune);
            db.Entry<SesiuneLucru>(sesiuneaMea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteSesiune(int id)
        {
            var sesiune = db.SeiuniDosar.Find(id);
            db.SeiuniDosar.Remove(sesiune);
            db.SaveChanges();
        }

        //Factura methods implementation
        public List<Factura> GetFacturi()
        {
            return db.Facturi.ToList();
        }
        public List<Factura> GetFacturiByProces(int procesId)
        {
            return db.Facturi.Where(x => x.Proces.Id == procesId).ToList();
        }
        public Factura GetFactura(int id)
        {
            return db.Facturi.FirstOrDefault(x => x.Id == id);
        }
        public void CreateFactura(IFormCollection form)
        {
            var numeproces = form["Proces"].ToString();
            var numeclient = form["Client"].ToString();
            var newFactura = new Factura(form, db.Proces.FirstOrDefault(x => x.Nume == numeproces),
                db.Client.FirstOrDefault(x => x.Nume == numeclient));
            db.Facturi.Add(newFactura);
            db.SaveChanges();
        }
        public void UpdateFactura(IFormCollection form)
        {
            var facturaId = int.Parse(form["Factura.Id"]);
            var numeproces = form["Proces"].ToString();
            var numeclient = form["Client"].ToString();
            var myFactura = db.Facturi.FirstOrDefault(x => x.Id == facturaId);
            var myproces = db.Proces.FirstOrDefault(x => x.Nume == numeproces);
            var myclient = db.Client.FirstOrDefault(x => x.Nume == numeclient);
            myFactura.UpdateFactura(form, myproces, myclient);
            db.Entry<Factura>(myFactura).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteFactura(int id)
        {
            var FacturaMea = db.Facturi.Find(id);
            db.Facturi.Remove(FacturaMea);
            db.SaveChanges();
        }

        //Contact DAL methods implementation
        public List<Contact> GetContacte()
        {
            return db.Contact.ToList();
        }
        public Contact GetContact(int id)
        {
            return db.Contact.FirstOrDefault(x => x.Id == id);
        }
        public void CreateContact(Contact contact)
        {
            db.Contact.Add(contact);
            db.SaveChanges();
        }
        public void DeleteContact(int id)
        {
            var myContact = db.Contact.Find(id);
            db.Contact.Remove(myContact);
            db.SaveChanges();
        }

        //Cheltuieli dal methods implementation
        public List<Cheltuiala> GetCheltuieliProces(int procesId) 
        {
            return db.Cheltuieli.Where(x => x.Proces.Id == procesId).ToList();
        }
        public Cheltuiala GetCheltuiala(int id)
        {
            return db.Cheltuieli.FirstOrDefault(x => x.Id == id);
        }
        public void CreateCheltuiala(IFormCollection form)
        {
            var numeproces = form["Proces"].ToString();
            var newCheltuiala = new Cheltuiala(form, db.Proces.FirstOrDefault(x => x.Nume == numeproces));
            db.Cheltuieli.Add(newCheltuiala);
            db.SaveChanges();
        }
        public void UpdateCheltuiala(IFormCollection form)
        {
            var cheltuialaId = int.Parse(form["Cheltuiala.Id"]);
            var numeproces = form["Proces"].ToString();
            var cheltuialaMea = db.Cheltuieli.FirstOrDefault(x => x.Id == cheltuialaId);
            var ProcesCheltuiala = db.Proces.FirstOrDefault(x => x.Nume == numeproces);
            cheltuialaMea.UpdateCheltuiala(form, ProcesCheltuiala);
            db.Entry<Cheltuiala>(cheltuialaMea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteCheltuiala(int id)
        {
            var cheltuiala = db.Cheltuieli.Find(id);
            db.Cheltuieli.Remove(cheltuiala);
            db.SaveChanges();
        }

        public List<Raport> GetRapoarte()
        {
            return db.Rapoarte.ToList();
        }
        public List<Raport> GetRaportByProces(int procesId)
        {
            return db.Rapoarte.Where(x => x.Proces.Id == procesId).ToList();
        }
        public Raport GetRaport(int id)
        {
            return db.Rapoarte.FirstOrDefault(x => x.Id == id);
        }
        public void CreateRaport(IFormCollection form)
        {
            var numeproces = form["Proces"].ToString();            
            var newRaport = new Raport( db.Proces.FirstOrDefault(x => x.Nume == numeproces));
            db.Rapoarte.Add(newRaport);
            db.SaveChanges();
        }
        public void DeleteRaport(int id)
        {
            var myraport = db.Rapoarte.Find(id);
            db.Rapoarte.Remove(myraport);
            db.SaveChanges();
        }
    }
}
