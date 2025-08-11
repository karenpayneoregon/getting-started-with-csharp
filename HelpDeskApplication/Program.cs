using Microsoft.Extensions.Options;
using Serilog;
using SpecialValidatorsLibrary.Classes;
using SpecialValidatorsLibrary.Models;

namespace HelpDeskApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureSerilog(builder);

        // Add services to the container.
        builder.Services.AddRazorPages();


        // Bind configuration section to FileSettings
        builder.Services.AddOptions<RequiredDirectories>()
            .Bind(builder.Configuration.GetSection(nameof(FileSettings)));

        // using IValidateOptions<T>:
        builder.Services.AddSingleton<IValidateOptions<RequiredDirectories>, DirectoryOptionsValidation>();
        builder.Services.AddOptions<RequiredDirectories>()
            .ValidateOnStart();
        
        var fileSettings = builder.Configuration.GetSection(nameof(FileSettings)).Get<FileSettings>();

        // Define the path where key-per-file secrets are stored
        var secretsPath = fileSettings?.SecretsDirectory;

        if (Directory.Exists(secretsPath))
        {
            builder.Configuration.AddKeyPerFile(secretsPath, optional: true, reloadOnChange: true);
            builder.Services.Configure<HelpDesk>(builder.Configuration);
        }


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }

    /// <summary>
    /// Configures Serilog as the logging provider for the application.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> used to configure the application's services and middleware.
    /// </param>
    /// <remarks>
    /// This method sets up Serilog to log messages to the console and adjusts the minimum logging levels
    /// for specific namespaces such as "Microsoft" and "System". It also integrates Serilog with the application's host.
    /// </remarks>
    private static void ConfigureSerilog(WebApplicationBuilder builder)
    {
        // Configure Serilog to log to the console
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}
