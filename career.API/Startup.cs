using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using career.BLL.Abstract;
using career.BLL.Concrete;
using career.DAL.Abstract;
using career.DAL.Concrete.EntityFramework;
using career.DAL.DataAccess;
using career.DAL.DataAccess.EntityFramework;
using career.DAL.DependencyResolvers;
using career.DAL.Extensions;
using career.DAL.Mappings;
using career.DAL.Utilities.IoC;
using career.DAL.Utilities.Security.Encryption;
using career.DAL.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace career.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddTransient<CareerContext>();

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddScoped<IVacancyTypeService, VacancyTypeManager>();
            services.AddTransient<IVacancyTypeDal, EfVacancyTypeDal>();

            services.AddScoped<IDepartmantService, DepartmantManager>();
            services.AddTransient<IDepartmantDal, EfDepartmantDal>();

            services.AddScoped<IPositionDal, EfPositionDal>();
            services.AddTransient<IPositionService, PositionManager>();

            services.AddScoped<IVacancyService, VacancyManager>();
            services.AddTransient<IVacancyDal, EfVacancyDal>();

            services.AddScoped<IUserDal, EfUserDal>();
            services.AddTransient<IUserService, UserManager>();

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();


            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddTransient<IEmployeeDal, EfEmployeeDal>();

            services.AddScoped<IPictureService, PictureManager>();
            services.AddTransient<IPictureDal, EfPictureDal>();

            services.AddScoped<IProjectDal, EfProjectDal>();
            services.AddTransient<IProjectService, ProjectManager>();


            services.AddScoped<IUnitOfWork,UnitOfwork>();

            services.AddScoped<IVacancyInformationService, VacancyInformationManager>();
            services.AddTransient<IVacancyInformationDal, EfVacancyInformationDal>();

            services.AddTransient<IVacancyRequirementService, VacancyRequirementManager>();
            services.AddTransient<IVacancyRequirementDal, EfVacancyRequirementDal>();

            services.AddTransient<IFileService, FileManager>();
            services.AddTransient<IFileDal, EfFileDal>();

            services.AddDbContext<CareerContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
                    };
                });
            services.AddDependencyResolvers(new ICoreModule[] {
            new CoreModule()
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "career.API", Version = "v1" });
            });


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                                  {
                                      builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "career.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
