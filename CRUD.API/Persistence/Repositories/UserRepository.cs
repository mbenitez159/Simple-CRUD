using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CRUD.API.Core.Domain;
using CRUD.API.Core.Repositories;

namespace CRUD.API.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context)
        {

        }

        public DataBaseContext DBContext
        {
            get { return _context as DataBaseContext; }
        }
    }
}
