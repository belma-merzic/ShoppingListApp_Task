using Microsoft.EntityFrameworkCore;
using ShoppingListApp_API.Filters;
using ShoppingListApp_API.Services;
using ShoppingListApp_API.Services.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IShopperService, ShopperService>();  
builder.Services.AddTransient<IItemService, ItemService>();  
builder.Services.AddTransient<IShoppingListService, ShoppingListService>();  


builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(IShoppingListService));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
