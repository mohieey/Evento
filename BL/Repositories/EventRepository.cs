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
    public class EventRepository : BaseRepository<Event>
    {
        private DbContext _DbContext;

        public EventRepository(DbContext DbContext) : base(DbContext)
        {
            this._DbContext = DbContext;
        }

        public List<Event> GetAllEvents()
        {
            return GetAll().Include(e => e.Host.user).ToList();
        }

        public Event InsertEvent(Event @event)
        {
            return Insert(@event);
        }

        public void UpdateEvent(Event @event)
        {
            Update(@event);
        }

        public void DeleteEvent(int id)
        {
            Delete(id);
        }

        public bool CheckEventExists(Event @event)
        {
            return GetAny(e => e.ID == @event.ID);
        }

        public Event GetEventById(int id)
        {
            return GetFirstOrDefault(e => e.ID == id);
        }
    }
}
