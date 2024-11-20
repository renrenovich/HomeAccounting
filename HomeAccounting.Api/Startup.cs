using HealthChecks.UI.Client;
using HomeAccounting.Application.Contracts;
using HomeAccounting.Application.Integrations.Contracts;
using HomeAccounting.Application.Integrations.Services;
using HomeAccounting.Application.Services;
using HomeAccounting.Data;
using HomeAccounting.DataAccess.Contracts;
using HomeAccounting.DataAccess.Repositories;
using HomeAccounting.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<HomeAccountingDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("HomeAccountingDb")));
        services.AddControllersWithViews();
        // Добавьте другие сервисы здесь
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHealthChecks();
        services.AddHttpClient();

        services.AddScoped<ICurrencyExchangeService, CurrencyExchangeService>(provider =>
        {
            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
            var baseUrl = Configuration["CurrencyExchangeApi:BaseUrl"];
            return new CurrencyExchangeService(httpClientFactory, baseUrl);
        });;

        services.AddHealthChecks()
            .AddNpgSql(Configuration.GetConnectionString("HomeAccountingDb"));
        services.AddScoped<IPurchaseCategoryService, PurchaseCategoryService>();
        services.AddScoped<IPurchaseService, PurchaseService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPurchaseCategoryRepository, PurchaseCategoryRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        if (env.IsDevelopment())
        {
            app.UseSwagger(); 
            app.UseSwaggerUI();
        }
        

        app.UseHttpsRedirection();

        
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("api/Health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        });
    }
}