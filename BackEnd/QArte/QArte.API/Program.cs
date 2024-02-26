
using QArte.Persistance;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QArte.Services.ServiceInterfaces;
using QArte.Services.Services;
using Stripe;
using QArte.API.MiddleWare;
using Microsoft.OpenApi.Models;
//sing Swashbuckle.Swagger;
//new
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Quartz;
using QArte.Services.Services.quartzPayouts;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "You api title", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
});


var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");

builder.Services.AddDbContext<QArteDBContext>(
               options => options.UseSqlServer(connectionString));

//builder.Services.AddTransient<IStripeService, QArte.Services.Services.StripeService>();
//builder.Services.AddTransient<IQRCodeGeneratorService, QArte.Services.Services.QRCodeGeneratorService>();
//builder.Services.AddTransient<IPictureService, PictureService>();
//builder.Services.AddSingleton<IAmazonData, QArte.Services.Services.AmazonData>();


builder.Services.AddTransient<IStripeService,QArte.Services.Services.StripeService>();
builder.Services.AddTransient<IQRCodeGeneratorService,QArte.Services.Services.QRCodeGeneratorService>();
builder.Services.AddTransient<IPictureService, PictureService>();
builder.Services.AddSingleton<IAmazonData,QArte.Services.Services.AmazonData>();

builder.Services.AddTransient<IBankAccountService, QArte.Services.Services.BankAccountService>();
builder.Services.AddTransient<IFeeService, QArte.Services.Services.FeeService>();
builder.Services.AddTransient<IGalleryService, QArte.Services.Services.GalleryService>();
builder.Services.AddTransient<IInvoiceService, QArte.Services.Services.InvoiceService>();
builder.Services.AddTransient<IPageService, QArte.Services.Services.PageService>();
builder.Services.AddTransient<IPaymentMethodsService, QArte.Services.Services.PaymentMethodService>();
builder.Services.AddTransient<IRoleService, QArte.Services.Services.RoleService>();
builder.Services.AddTransient<ISettlementCycleService, QArte.Services.Services.SettlementCycleService>();
builder.Services.AddTransient<IUserService, QArte.Services.Services.UserService>();

builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<ITokennService, TokennService>();


builder.Services.AddTransient<QArte.Services.Services.quartzPayouts.PayoutSchedulerService>();

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddQuartz(q =>
{
    q.AddJobAndTrigger<PayoutSchedulerService>(builder.Configuration);
});
builder.Services.AddQuartzHostedService(options => { options.WaitForJobsToComplete = true; });



builder.Services.AddSqlServer<QArteDBContext>(connectionString);

builder.Services.AddCors(options =>
{
    options.AddPolicy("QarteApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5176", "https://localhost:7191", "http://localhost:5173", "http://localhost:5174", builder.Configuration["URL"]);
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});




var app = builder.Build();
app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors("QarteApp");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();