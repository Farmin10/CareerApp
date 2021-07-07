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
    public class EfUserDal:EfEntityRepositoryBase<User>,IUserDal
    {
        CareerContext _context;

        public EfUserDal(CareerContext context) : base(context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            var result= _context.Users.Include(x => x.Employee).Where(x => x.EmployeeId == x.Employee.EmployeeId).ToList();
            return result;
        }
    }
}
