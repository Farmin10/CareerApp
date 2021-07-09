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
    public class EfAppealDal: EfEntityRepositoryBase<Appeal>,IAppealDal
    {
        CareerContext _context;

        public EfAppealDal(CareerContext context) : base(context)
        {
            _context = context;
        }

        public List<Appeal> GetAll()
        {
           var result= _context.Appeals.Include(x => x.Vacancy).Where(x => x.VacancyId == x.Vacancy.VacancyId).ToList();
            return result;
        }
    }
}
