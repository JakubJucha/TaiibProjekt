using BLL_Business_Logic_Layer_.Implementations;
using BLL_Business_Logic_Layer_.Interfaces;
using Microsoft.CodeAnalysis;
using ProjektTaiib.DAL.Repositories;
using ProjektTaiib.DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjektTaiibDbContext>();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IUserService,BLLUserService>();
builder.Services.AddScoped<IDetailedInformationService,BLLDetailedInformationService>();
builder.Services.AddScoped<IEventService, BLLEventService>();
builder.Services.AddScoped<ISponsorService, BLLSponsorService>();
builder.Services.AddScoped<ITicketService,BLLTicketService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
