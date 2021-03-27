using AutoMapper;
using BL.ViewModels;
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

        public List<HostUser> GetAllHosts()
        {
            return _DbContext.HostUsers.ToList();
        }
    }
}
