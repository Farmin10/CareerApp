﻿using career.DAL.Abstract;
using career.DAL.DataAccess.EntityFramework;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DAL.Concrete.EntityFramework
{
    public class EfNewsDal:EfEntityRepositoryBase<News>,INewsDal
    {
        CareerContext _context;

        public EfNewsDal(CareerContext context) : base(context)
        {
            _context = context;
        }
    }
}
