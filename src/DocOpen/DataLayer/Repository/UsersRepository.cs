using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DocOpen.Data
{

    public class UsersRepository : DataRepository<User>, IUsersRepository
    {
        public UsersRepository(DocOpenContext context) : base(context)
        {
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}