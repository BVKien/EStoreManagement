using BusinessObject.Models; // Using models 
using Repository.Members;
using Repository.Categories;
using Repository.OrderDetails;
using Repository.Orders;
using Repository.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<eStoreContext>(); // Add services db context - Bui Van Kien
builder.Services.AddRazorPages();

// Bui Van Kien
builder.Services.AddSession(); // Add session
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Category repository
builder.Services.AddScoped<IMemberRepository, MemberRepository>(); // Member repository
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>(); // Order detail repository
builder.Services.AddScoped<IOrderRepository, OrderRepository>(); // Order repository
builder.Services.AddScoped<IProductRepository, ProductRepository>(); // Product repository 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession(); // Use session - Bui Van Kien
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
