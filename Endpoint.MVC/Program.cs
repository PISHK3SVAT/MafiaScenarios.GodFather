using BusinessLogic;

using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var players = new List<Player>()
{
    new Player
    {
        Id=1,
        Name="محمد جواد",
    },
    new Player
    {
        Id=2,
        Name="رقیه",
    },
    new Player
    {
        Id=3,
        Name="آسیه",
    },
    new Player
    {
        Id=4,
        Name="معصومه",
    },
    new Player
    {
        Id=5,
        Name="مریم",
    },
    new Player
    {
        Id=6,
        Name="زینب",
    },
    new Player
    {
        Id=7,
        Name="مرضیه",
    },
    new Player
    {
        Id=8,
        Name="مهسا",
    },
    new Player
    {
        Id=9,
        Name="لیلا",
    },
    new Player
    {
        Id=10,
        Name="ریحانه",
    },
    new Player
    {
        Id=11,
        Name="زهرا",
    },
};
builder.Services.AddSingleton(new GameService(players));
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
