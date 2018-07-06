using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KanbanBoard.SqlRepository;
using KanbanBoardCore;
using KanbanAPI.Filters;
using AutoMapper;
using KanbanAPI.ViewModels;

namespace KanbanAPI
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
            services.AddMvc();
            services.AddCors(options=>{
                options.AddPolicy("AllowAllHeaders",
                                  builder => {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                });
            });
            
            services.AddAuthorization(options=>{
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            
            services.AddAuthentication(o=>{
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>{
                options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "test",
                    ValidAudience = "test",
                    IssuerSigningKey = new SymmetricSecurityKey( Encoding.ASCII.GetBytes("secretesecretesecretesecretesecretesecrete"))

                };
            });

            
            services.AddDbContext<ApplicationDbContext>( options => options.UseSqlServer(@"Data Source=localhost\SQLexpress,1401;Initial Catalog=Kanban_Dev;User ID=sa;Password=e58@t4Ie"));

            services.AddIdentity<UserEntity, KanbanRoles>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IUserRepository, SqlUserRepository>();
            services.AddTransient<UserService, UserService>();
            services.AddTransient<IProjectRepository, SqlProjectRepository>();
            services.AddTransient<ProjectService, ProjectService>();

            services.AddMvc(options =>
            {
                options.Filters.Add(new ApiValidationFilterAttribute());
            });
            
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
                cfg.AddProfile(new SqlMapperConfiguraiton());
            });

            InitializeAutoMapper();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllHeaders");
            app.UseStaticFiles();
            

            app.UseAuthentication();


            app.UseMvc();

        }

        private void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserDetail, UserEntity>().ReverseMap();
                cfg.CreateMap<Project, DbProject>().IncludeBase<CoreObject, KanbanEntity>() .ReverseMap();
                cfg.CreateMap<ProjectStage, DbProjectStage>().ReverseMap();
                cfg.CreateMap<ProjectTask, DbProjectTask>().ReverseMap();
                cfg.CreateMap<ProjectViewModel, Project>();
                cfg.CreateMap<StageViewModel, ProjectStage>();
            });
        }
    }
}
