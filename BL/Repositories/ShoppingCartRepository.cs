using AutoMapper;
using BL.Bases;
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
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>
    {
        private DbContext _DbContext;

        public ShoppingCartRepository(DbContext DbContext) : base(DbContext)
        {
            this._DbContext = DbContext;
        }

        public ShoppingCart GetShoppingCartByUserId(string Id)
        {
            return GetWhere(s => s.ClientId == Id)
                .Include(s => s.ShoppingCartTickets)
                .FirstOrDefault();
        }
    }
}
