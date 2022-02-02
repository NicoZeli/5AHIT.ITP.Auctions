using Domain.Repository;
using EFCAT.Service.Authentication;
using EFCAT.Service.Storage;
using Microsoft.EntityFrameworkCore;
using Model.Configuration;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<AuctionDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new System.Version("8.0.25")))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
);

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSingleton(builder.Configuration.GetSection("MailConnection").GetSection("DefaultMail").Get<MailSettings>());
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddLocalStorage();
builder.Services.AddHttpClient();
builder.Services.AddAuthenticationService<AuctionAuthentication>();


var app = builder.Build();

using (var context = app.Services.CreateScope().ServiceProvider.GetService<AuctionDbContext>()) {
    if (context == null) return;
    //context.Database.Migrate();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();