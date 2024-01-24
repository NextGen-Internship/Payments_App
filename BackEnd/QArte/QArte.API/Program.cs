using QArte.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.Services.ServiceInterfaces;
using QArte.Services.Services;
using Stripe;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

//cors?

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");

builder.Services.AddDbContext<QArteDBContext>(
               options => options.UseSqlServer(connectionString));


<<<<<<< HEAD
builder.Services.AddTransient<IBankAccountService, BankAccountService>();
builder.Services.AddTransient<IFeeService, FeeService>();
builder.Services.AddTransient<IGalleryService, GalleryService>();
builder.Services.AddTransient<IInvoiceService, InvoiceService>();
builder.Services.AddTransient<IPageService, PageService>();
builder.Services.AddTransient<IPaymentMethodsService, PaymentMethodService>();
builder.Services.AddTransient<IPictureService, PictureService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<ISettlementCycleService, SettlementCycleService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<QRCodeGeneratorService>();

=======
builder.Services.AddTransient<IBankAccountService, QArte.Services.Services.BankAccountService>();
builder.Services.AddTransient<IFeeService, QArte.Services.Services.FeeService>();
builder.Services.AddTransient<IGalleryService, QArte.Services.Services.GalleryService>();
builder.Services.AddTransient<IInvoiceService, QArte.Services.Services.InvoiceService>();
builder.Services.AddTransient<IPageService, QArte.Services.Services.PageService>();
builder.Services.AddTransient<IPaymentMethodsService, QArte.Services.Services.PaymentMethodService>();
builder.Services.AddTransient<IPictureService, QArte.Services.Services.PictureService>();
builder.Services.AddTransient<IRoleService, QArte.Services.Services.RoleService>();
builder.Services.AddTransient<ISettlementCycleService, QArte.Services.Services.SettlementCycleService>();
builder.Services.AddTransient<IUserService, QArte.Services.Services.UserService>();
>>>>>>> cb09d3ba0814b544ce492a1b60f2e37f55fbdcb7

builder.Services.AddMediatR(typeof(Program));


builder.Services.AddSqlServer<QArteDBContext>(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

