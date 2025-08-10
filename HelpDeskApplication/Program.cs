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

        // Configure Serilog to log to the console
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.Configure<HelpDesk>(builder.Configuration.GetSection(nameof(HelpDesk)));

        var fileSettings = builder.Configuration.GetSection(nameof(FileSettings)).Get<FileSettings>();

        // Define the path where key-per-file secrets are stored
        var secretsPath = fileSettings.SecretsDirectory;

        if (Directory.Exists(secretsPath))
        {
            builder.Configuration.AddKeyPerFile(secretsPath, optional: true, reloadOnChange: true);
        }

        // Bind configuration section to FileSettings
        builder.Services.AddOptions<RequiredDirectories>()
            .Bind(builder.Configuration.GetSection(nameof(FileSettings)));

        // using IValidateOptions<T>:
        builder.Services.AddSingleton<IValidateOptions<RequiredDirectories>, DirectoryOptionsValidation>();
        builder.Services.AddOptions<RequiredDirectories>()
            .ValidateOnStart();

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
}
