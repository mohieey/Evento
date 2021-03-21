using DAL;
using DAL.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            client.shoppingCart = new ShoppingCart();

            ClientUser newClient = _DbContext.ClientUsers.Add(client);

            _DbContext.SaveChanges();

            return newClient;
        }

        public ClientUser GetClientById(string id)
        {
            return _DbContext.ClientUsers.Find(id);
        }
    }
}
