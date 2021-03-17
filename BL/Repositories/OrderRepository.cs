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
    public class OrderRepository : BaseRepository<Order>
    {
        private DbContext _DbContext;

        public OrderRepository(DbContext DbContext) : base(DbContext)
        {
            this._DbContext = DbContext;
        }

        public List<Order> GetAllOrder()
        {
            return GetAll().ToList();
        }

        public Order InsertOrder(Order order)
        {
            return Insert(order);
        }

        public void UpdateOrder(Order order)
        {
            Update(order);
        }

        public void DeleteOrder(int id)
        {
            Delete(id);
        }

        public bool CheckOrderExists(Order order)
        {
            return GetAny(o => o.ID == order.ID);
        }

        public Order GetOrderById(int id)
        {
            return GetFirstOrDefault(o => o.ID == id);
        }
    }
}
