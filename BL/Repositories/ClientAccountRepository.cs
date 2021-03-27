using DAL;
using DAL.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class ClientAccountRepository : AccountRepository
    {
        private ApplicationDBContext _DbContext;

        public ClientAccountRepository(DbContext db) : base(db)
        {
            _DbContext = new ApplicationDBContext();
        }

        public ClientUser AddAsAClient(ClientUser client)
        {            
            ClientUser newClient = _DbContext.ClientUsers.Add(client);
            try
            {
                _DbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }


            //ClientUser newClient = _DbContext.ClientUsers.Add(client);

            //_DbContext.SaveChanges();

            return newClient;
        }

        public List<ClientUser> GetAllClientUser()
        {
            return _DbContext.ClientUsers.ToList();
        }

        public ClientUser GetClientById(string id)
        {
            ClientUser client = _DbContext.ClientUsers.SingleOrDefault(c => c.Id == id);
            return client;

        }

        public void UpdateClientUser(ClientUser clientUser)
        {
            DbEntityEntry dbEntityEntry = _DbContext.Entry(clientUser);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _DbContext.ClientUsers.Attach(clientUser);
            }
            dbEntityEntry.State = EntityState.Modified;
            _DbContext.SaveChanges();
        }

        public List<ClientUser> GetAllClients()
        {
            return _DbContext.ClientUsers.Include(c=>c.orders).Include(c=>c.user).ToList();
        }
    }
}
