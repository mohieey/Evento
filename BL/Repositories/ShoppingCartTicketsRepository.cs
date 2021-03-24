using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class ShoppingCartTicketsRepository: BaseRepository<ShoppingCartTicket>
    {
        private DbContext _DbContext;

        public ShoppingCartTicketsRepository(DbContext DbContext) : base(DbContext)
        {
            this._DbContext = DbContext;
        }

        public List<Ticket> getTicketsByShoppingCartId(int id)
        {
            return GetAll().Include(sct => sct.ticket)
                .Where(sct => sct.shoppingCartId == id)
                .Select(sct=>sct.ticket)
                .ToList();
        }

        public void ClearShoppingCart(int shoppingCartId)
        {
            RemoveRange(GetWhere(s=>s.shoppingCartId == shoppingCartId).ToList());
        }
    }
}
