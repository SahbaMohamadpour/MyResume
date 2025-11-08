using App.DataAccess.Services.CertificateServiceFolder;
using App.DataAccess.Services.ExprienceServiceFolder;
using App.DataAccess.Services.HobbiesServiceFolder;
using App.DataAccess.Services.LanguageServiceFolder;
using App.DataAccess.Services.personalInfoServiceFolder;
using App.DataAccess.Services.ProjrctServiceFolder;
using App.DataAccess.Services.SkillServiceFolder;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        IConfiguration _config = builder.Configuration;

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<DataContext>(option =>
        {
            option.UseSqlServer(_config["ConnectionStrings:Connection"]);
        });




        builder.Services.AddScoped< ISkillService,SkillService>();
        builder.Services.AddScoped<IProjectService,ProjectService>();
        builder.Services.AddScoped<IPersonalInfoService, PersonalInfoService>();
        builder.Services.AddScoped<ILanguageService, LanguageService>();
        builder.Services.AddScoped<IHobbyService, HobbyService>();
        builder.Services.AddScoped<IExprienceService, ExprienceService>();
        builder.Services.AddScoped<ICertificateService , CertificateService>();






   var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.Run();
    }
}