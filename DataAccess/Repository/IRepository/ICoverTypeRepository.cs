using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository:IBaseRepository<CoverType>
    {
        void Update(CoverType coverType);

    }
}
