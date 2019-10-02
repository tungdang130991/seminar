using Seminar.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seminar.Repository.MySQL
{
    public class SeminarRepository : CommonRepository, ISeminarRepository
    {
        public SeminarRepository(SeminarDbContext dbContext):base(dbContext)
        {
        }
    }
}
