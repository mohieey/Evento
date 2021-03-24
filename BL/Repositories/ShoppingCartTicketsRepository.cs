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
    }
}
