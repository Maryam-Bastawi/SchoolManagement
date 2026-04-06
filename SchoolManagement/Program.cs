using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application;
    using SchoolManagement.Infrastructure;
using SchoolManagement.Infrastructure.Context;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddInfrastructureServices(builder.Configuration);

    builder.Services.AddApplicationServices();

    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate(); 
    }

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
 pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();