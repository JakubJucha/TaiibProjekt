using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.UserR;
using ProjektTaiib.DAL.Repositories.DetailedInformationR;
using System.Text;
using System.Text.Json.Serialization;
using ProjektTaiib.DAL.Repositories.EventR;
using ProjektTaiib.DAL.Repositories.SponsorR;
using ProjektTaiib.DAL.Repositories.TicketR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5168",
        ValidAudience = "http://localhost:4200",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superTajneHas³osuperTajneHas³osuperTajneHas³o"))
    };
});
builder.Services.AddControllers().AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjektTaiibDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDetailedInformationRepository, DetailedInformationRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ISponsorRepository, SponsorRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();



app.UseRouting();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
