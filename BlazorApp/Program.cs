using Blazored.Toast;
using Dominus.Application;
using HL.Proxy.Api;
using HL.Security;
using Dominus.Web.HttpClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog(((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration)));

builder.Services.Configure<List<Tenant>>( builder.Configuration.GetSection("Tenants"));

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

builder.Services.AddDevExpressBlazor(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Small;
});

builder.Services.AddBlazoredToast();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFromAll",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyOrigin()
        .AllowAnyHeader());
});

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //options.Cookie.Name = "auth_blazorPM";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        //options.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects; //Esto hace que se agregue la propriedad $type Si esta configurado como ".Object" a las respuestas JSON
        //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects; // Esto hace que se agregue la propiedad $id a las respuestas JSON
        options.SerializerSettings.ContractResolver = new DefaultContractResolver(); //Esto hace que las propiedades de las respuestas JSON se conviertan en CamelCase 
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
        options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fff";
    });
                //.AddJsonOptions(configure =>
                //{
                //    configure.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                //    configure.JsonSerializerOptions.PropertyNamingPolicy = null;
                //    configure.JsonSerializerOptions.AllowTrailingCommas = true;
                //    configure.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                //});
builder.Services.AddHLSecurity();
//builder.Services.AddDominusEngine();

builder.WebHost.UseWebRoot("wwwroot");

builder.WebHost.UseStaticWebAssets();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowFromAll");

//app.UseHttpsRedirection();

app.UseCookiePolicy();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();

app.MapControllers();
app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

var serverApiCore = builder.Configuration["Services:DefaulApi"];

DApp.ServiceUrl = serverApiCore;

Localization.DefaultLanguage = "1";

DApp.LoadTenants(new DmsLogicProxy(DApp.ServiceUrl, "").GetTenants());

var resources = new DmsLogicProxy(DApp.ServiceUrl, "" ).GetResources();

Localization.AddResources(resources);

//var token = new DmsLogicProxy(DApp.Tenants[0].Services["DefaultApi"], "").GetToken(new WebApi.Models.LoginModel { UserName = "admin@enigma.com", Password = "admin", TenantId = "https://localhost:7060" });

//var dataGetAll = new DmsLogicProxy(DApp.Tenants[0].Services["DefaultApi"], token.Token).GetDomainLogic<Account>().FindAll();

//var dataGelAllWhere = new DmsLogicProxy(DApp.Tenants[0].Services["DefaultApi"], token.Token).GetDomainLogic<Account>().FindAll(x => x.Active == true && x.Id != 0);

//var dataGelAllWhere1 = new DmsLogicProxy(DApp.Tenants[0].Services["DefaultApi"], token.Token).GetDomainLogic<Account>().FindAll(null);

//var dataGelAllWhere2 = new DmsLogicProxy(DApp.Tenants[0].Services["DefaultApi"], token.Token).GetDomainLogic<CommonLanguageResource>().FindAll(x=> x.ResourceKey=="Button.Back");

//var dataGelAllWhere3 = new DmsLogicProxy(DApp.Tenants[0].Services["DefaultApi"], token.Token).GetDomainLogic<CommonLanguageResource>().FindById(x => x.ResourceKey == "Button.Back");




app.Run();  