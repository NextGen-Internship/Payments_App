using QArte.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;
using QArte.Persistance.PersistanceModels;
using MediatR;
using QArte.Services.ServiceInterfaces;
using QArte.Services.Services;
using QArte.Persistance.PersistanceConfigurations;
using Stripe;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");

builder.Services.AddDbContext<QArteDBContext>(
               options => options.UseSqlServer(connectionString));


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
builder.Services.AddTransient<QArte.Services.Services.QRCodeGeneratorService>();
builder.Services.AddTransient<QArte.Services.Services.StripeService>();
builder.Services.AddTransient< QArte.Services.Services.TokenService>();


builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSqlServer<QArteDBContext>(connectionString);


//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<QArteDBContext>()
//    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Secret"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("QarteApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5176", "https://localhost:7191", "http://localhost:5173");

        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("QarteApp");

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(jwt =>
//{
//    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);

//    jwt.SaveToken = true;
//    jwt.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = false, // for dev
//        ValidateAudience = false,//for dev
//        RequireExpirationTime = false, //for dev - need to be updated when refresh token is added
//        ValidateLifetime = true
//    };
//});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//            .AddEntityFrameworkStores<QArteDBContext>();
