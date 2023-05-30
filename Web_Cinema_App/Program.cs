using Web_Cinema_App.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//Даёт доступ DataContext в проекте
builder.Services.AddDbContext<DataContextCinema>();
builder.Services.AddDbContext<DataContextCinemaRoom>();
builder.Services.AddDbContext<DataContextFilm>();
builder.Services.AddDbContext<DataContextGenre>();
builder.Services.AddDbContext<DataContextPlace>();
builder.Services.AddDbContext<DataContextSession>();
builder.Services.AddDbContext<DataContextTicket>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=MainPage}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "{controller=AdminPanel}/{action=AdminPanelView}/{id?}");

app.Run();
