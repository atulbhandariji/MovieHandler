using MovieHander.DAL;
using MovieLibrary.MovieDALDBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//dependency injection
builder.Services.AddScoped<IMovieData, MovieData>();
builder.Services.AddScoped<IMovieDALData, MovieDALData>();


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
    pattern: "{controller=Movie}/{action=ShowMovieList}/{id?}");

app.Run();
