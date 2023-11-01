using RequestApplicatioin.DB;
using RequestApplication.Entities;
using RequestApplication.Services.Dto;
using RequestApplication.Services.Mapper;
using RequestApplication.Services.Services;

namespace RequestApplication.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<AppDbContext>();

            builder.Services.AddTransient<IDbRepository<Application>, DbRepository<Application>>();
            builder.Services.AddTransient<IDbRepository<Request>, DbRepository<Request>>();

            builder.Services.Scan(scan =>
                scan.FromAssemblyOf<BaseService<BaseEntity, BaseDto>>()
                    .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
                    .AsSelf()
                    .WithTransientLifetime());

            builder.Services.AddTransient<IApplicationMapper, ApplicationMapper>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Request}/{action=Index}");

            app.Run();
        }
    }
}