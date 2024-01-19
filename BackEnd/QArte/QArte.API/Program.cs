using QArte.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.Services.ServiceInterfaces;
using QArte.Services.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");

builder.Services.AddDbContext<QArteDBContext>(
               options => options.UseSqlServer(connectionString));


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

