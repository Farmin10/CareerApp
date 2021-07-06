using career.DAL.Abstract;
using career.DAL.DataAccess.EntityFramework;
using career.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DAL.Concrete.EntityFramework
{
    public class EfFileDal : EfEntityRepositoryBase<File>, IFileDal
    {
        CareerContext _context;

        public EfFileDal(CareerContext context) : base(context)
        {
            _context = context;
        }

    }
}
