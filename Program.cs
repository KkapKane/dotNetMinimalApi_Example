<<<<<<< HEAD

using MinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

=======
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
>>>>>>> 5b3b7a35c2955186d31a79f546e06e61c1ab6eff

var app = builder.Build();

// Configure the HTTP request pipeline.
<<<<<<< HEAD
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

async Task<List<SuperHero>> GetAllHeroes(DataContext context) => await context.SuperHeroes.ToListAsync();

app.MapGet("/", () => "Welcome to the DB!");

app.MapGet("/superhero", async (DataContext context) => await context.SuperHeroes.ToListAsync());

app.MapGet("/superhero/{id}", async (DataContext context, int id) =>
await context.SuperHeroes.FindAsync(id) is SuperHero hero ?
Results.Ok(hero) :
Results.NotFound("sorry, hero not found"));

app.MapPost("/superhero", async (DataContext context, SuperHero hero) =>
{
    context.SuperHeroes.Add(hero);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllHeroes(context));
});

app.Run();





=======
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
>>>>>>> 5b3b7a35c2955186d31a79f546e06e61c1ab6eff
