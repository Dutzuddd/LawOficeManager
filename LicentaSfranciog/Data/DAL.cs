using LicentaSfranciog.Models;
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
    }
    public class DAL : IDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //client data access layer methods
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

        //Proces methods implementation
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
    }
}
