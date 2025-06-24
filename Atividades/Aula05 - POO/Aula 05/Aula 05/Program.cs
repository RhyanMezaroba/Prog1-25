using Modelo;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

FillCustomerData();
FillProductData();

app.Run();

static void FillCustomerData()
{
    for(int i = 1; i < 10; i++)
    {
        Customer customer = new() // forma para facilitar e economizar código
        {
            Id = i, Name = $"Customer {i}",
            HomeAddress = new Address()
            {
                Id = i,
                AddressType = "Casa",
                City = "São Paulo",
                Country = "Brasil",
                State = "SP",
                PostalCode = "01000-000",
                Street1 = "Rua X da Casa",
                Street2 = "Apto 101"
            }
        };

        CustomerData.Customer.Add(customer);

    }
}

static void FillProductData()
{
    for (int i = 1; i < 10; i++)
    {
        Product product = new() // forma para facilitar e economizar código
        {
            Id = i,
            ProductName = $"Product {i}",
            CurrentPrice = i * 10.0f,
            Description = $"Description for Product {i}"
        };

        ProductData.Product.Add(product);
    }
}