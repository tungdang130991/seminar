using Seminar.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seminar.Repository.MySQL
{

    public class CommonRepository
    {
        public CommonRepository(SeminarDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public SeminarDbContext DbContext { get; set; }
    }
}
