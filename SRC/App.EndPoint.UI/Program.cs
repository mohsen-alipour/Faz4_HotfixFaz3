using App.Domain.AppServices.Account;
using App.Domain.AppServices.BaseData;
using App.Domain.AppServices.Customer;
using App.Domain.AppServices.Expert;
using App.Domain.Core.Account.Contacts.AppService;
using App.Domain.Core.Account.Contacts.Repositories;
using App.Domain.Core.Account.Contacts.Service;
using App.Domain.Core.BaseData.Contacts.AppService;
using App.Domain.Core.BaseData.Contacts.Repositories;
using App.Domain.Core.BaseData.Contacts.Service;
using App.Domain.Core.BaseData.Entity;
using App.Domain.Core.Customer.Contacts.AppService;
using App.Domain.Core.Customer.Contacts.Repositories;
using App.Domain.Core.Customer.Contacts.Service;
using App.Domain.Core.Expert.Contacts.AppService;
using App.Domain.Core.Expert.Contacts.Repositories;
using App.Domain.Core.Expert.Contacts.Service;
using App.Domain.Services.Account;
using App.Domain.Services.BaseData;
using App.Domain.Services.Customer;
using App.Domain.Services.Expert;
using App.Infrastructures.Database.SqlServer;
using App.Infrastructures.Repositoy.Ef.Account;
using App.Infrastructures.Repositoy.Ef.BaseData;
using App.Infrastructures.Repositoy.Ef.Customer;
using App.Infrastructures.Repositoy.Ef.Expert;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionstring")));

builder.Services.AddIdentity<AppUser, IdentityRole<int>>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            //options.SignIn.RequireConfirmedEmail = false;
            //to do
            //options.SignIn.RequireConfirmedPhoneNumber = false;

            //options.User.AllowedUserNameCharacters
            //options.User.RequireUniqueEmail

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            //options.Password.RequiredUniqueChars = 1;

        })
    .AddEntityFrameworkStores<AppDbContext>();


#region BaseData category
builder.Services.AddScoped<ICateguryAppService, CateguryAppService>();
builder.Services.AddScoped < ICateguryService ,CateguryService> ();
builder.Services.AddScoped<ICateguryRepository, CateguryRepository>();
#endregion BaseData category
#region BaseData service
builder.Services.AddScoped<IServiceAppService, ServiceAppService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
#endregion BaseData service
#region Account
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion
#region Order
builder.Services.AddScoped<IOrderAppService, OrderAppService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
#endregion
#region File
builder.Services.AddScoped<IAppFileAppService, AppFileAppService>();
builder.Services.AddScoped<IAppFileService, AppFileService>();
builder.Services.AddScoped<IAppFileRepository, AppFileRepository>();
#endregion
#region Service Comment
builder.Services.AddScoped<IServiceCommentAppService, ServiceCommentAppService>();
builder.Services.AddScoped<IServiceCommentService, ServiceCommentService>();
builder.Services.AddScoped<IServiceCommentRepository,ServiceCommentRepository>();
#endregion Service Comment
#region ExpertFavoriteCategoryAppService
builder.Services.AddScoped<IExpertFavoriteCategoryAppService, ExpertFavoriteCategoryAppService>();
builder.Services.AddScoped<IExpertFavoriteCategoryService , ExpertFavoriteCategoryService>();
builder.Services.AddScoped<IExpertFavoriteCategoryRepository, ExpertFavoriteCategoryRepository>();
#endregion
#region Bid
builder.Services.AddScoped<IBidAppService, BidAppService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//      name: "areas",
//      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );
//});

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
