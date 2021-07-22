using career.DAL.Concrete.EntityFramework.Mappings;
using career.DAL.DataAccess;
using career.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DAL.Concrete.EntityFramework
{
    public class CareerContext:DbContext
    {
        public CareerContext(DbContextOptions<CareerContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<VacancyType> VacancyTypes { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyInformation> VacancyInformation { get; set; }
        public DbSet<VacancyRequirement> VacancyRequirements { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Departmant> Departmants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppealMap());
            modelBuilder.ApplyConfiguration(new DepartmantMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new FileMap());
            modelBuilder.ApplyConfiguration(new NewsMap());
            modelBuilder.ApplyConfiguration(new PictureMap());
            modelBuilder.ApplyConfiguration(new PositionMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new VacancyMap());
            modelBuilder.ApplyConfiguration(new VacancyInformationMap());
            modelBuilder.ApplyConfiguration(new VacancyRequirementMap());
            modelBuilder.ApplyConfiguration(new VacancyTypeMap());
        }
    }
}
