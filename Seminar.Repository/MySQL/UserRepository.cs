using Seminar.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seminar.Repository.MySQL
{
    public class UserRepository : CommonRepository, IUserRepository
    {
        public UserRepository(SeminarDbContext dbContext):base(dbContext)
        {
        }

        public MSystemUser GetAll()
        {
            return null;
        }
    }
}
