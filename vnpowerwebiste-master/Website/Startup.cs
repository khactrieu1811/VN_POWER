using AutoMapper;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Business.IRepostitory;
using Business.Repository;
using Business.Utils;
using Common;
using Entities.DAL;
using Entities.Entities;
using Model.Mapper;
using Website.Api;
using Website.Handlers;
using Website.LocalizationResources;
using Website.Models;
using Website.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;

namespace Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {

            var cultures = new[]
           {
                new CultureInfo("vi"),
                new CultureInfo("en"),
            };

            services.AddControllersWithViews()
                 .AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
                 {
                     ops.UseAllCultureProviders = false;
                     ops.ResourcesPath = "LocalizationResources";
                     ops.RequestLocalizationOptions = o =>
                     {
                         o.SupportedCultures = cultures;
                         o.SupportedUICultures = cultures;
                         o.DefaultRequestCulture = new RequestCulture("en");
                     };
                 });
            services.AddDbContext<VNPowerContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<List<Permission>>(Configuration.GetSection("Permissions"));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
           .AddEntityFrameworkStores<VNPowerContext>()
           .AddDefaultTokenProviders();
            services.AddHttpClient();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddCookie(cfg => cfg.SlidingExpiration = true)
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes
               };
           });

            //Mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {

                mc.AddProfile(new MappingProfile());

            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Demo", Version = "v1" });
            });

            //AddScoped Repository
            #region  Add Repository Core
            services.AddTransient<IAccountInitialize, AccountInitialize>();
            //services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IRoleMenuPermissionRepository, RoleMenuPermissionRepository>();
            services.AddScoped<INavigationMenuRepository, NavigationMenuRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();      
            services.AddScoped<IDataAccessService, DataAccessService>();
            services.AddScoped<ITokenService, TokenService>();
            #endregion

            #region  Add Repository

            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPostTagRepository, PostTagRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IScholarshipRepository, ScholarshipRepository>();
            services.AddScoped<IScholarshipTypeRepository, ScholarshipTypeRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ImagesController>();
       
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryProductRepository, CategoryProductRepository>();
            #endregion

            services.AddScoped<IEmailSender, EmailSender>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policyCorrectUser =>
                {
                    policyCorrectUser.Requirements.Add(new AuthorizationRequirement());
                });
            });
            services.AddSignalR();
            services.Configure<CaptchaSettings>(Configuration.GetSection("Captcha"));
            services.AddTransient<CaptchaVerificationService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAccountInitialize accountInitialize)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<VNPowerContext>();
                context.Database.Migrate();
                serviceScope.ServiceProvider.GetRequiredService<ITokenService>();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            //  app.UseCors(options => options.AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            accountInitialize.SeedData();
            accountInitialize.Initialize(app);
            DbInitializer.Seed(app);

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response;
                var endpointFeature = context.HttpContext.Features[typeof(IEndpointFeature)] as IEndpointFeature;
                var endpoint = endpointFeature?.Endpoint;

                if ((response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                    response.StatusCode == (int)HttpStatusCode.Forbidden) && !endpoint.DisplayName.Contains("Api"))
                    response.Redirect("/admin/signin");
            });
            app.UseMiddleware<JWTInHeaderMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "Admins",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
