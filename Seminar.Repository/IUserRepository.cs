using Seminar.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seminar.Repository
{
    public interface IUserRepository
    {
        MSystemUser GetAll();
    }
}
