using AutoMapper;
using BL.ViewModels;
using DAL;
using DAL.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class HostAccountRepository : AccountRepository
    {
        private ApplicationDBContext _DbContext;

        public HostAccountRepository(DbContext db):base(db)
        {
            _DbContext = new ApplicationDBContext();
        }

        public HostUser AddAsAHost(HostUser host)
        {
            _DbContext.HostUsers.Add(host);

            _DbContext.SaveChanges();

            return host;
        }

        //public List<HostUser> GetAllHostUser()
        //{
        //    return _DbContext.HostUsers.ToList();
        //}

        public HostUser GetHostById(string id)
        {
            HostUser hostUser = _DbContext.HostUsers.SingleOrDefault(c => c.Id == id);
            return hostUser;
        }

        public void UpdateHostUser(HostUser hostUser)
        {
            DbEntityEntry dbEntityEntry = _DbContext.Entry(hostUser);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _DbContext.HostUsers.Attach(hostUser);
            }
            dbEntityEntry.State = EntityState.Modified;
            _DbContext.SaveChanges();
        }

        public List<HostUser> GetAllHosts()
        {
            return _DbContext.HostUsers.ToList();
        }
    }
}
