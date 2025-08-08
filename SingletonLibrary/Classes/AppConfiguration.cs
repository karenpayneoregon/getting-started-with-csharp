using ConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;
using SingletonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLibrary.Classes;
public sealed class AppConfiguration
{
    private static readonly Lazy<AppConfiguration> _lazyInstance = new(() => new AppConfiguration());
    public static AppConfiguration Instance { get; } = _lazyInstance.Value;


    /// <summary>
    /// Gets the HelpDesk configuration details, including contact phone number and email address.
    /// </summary>
    /// <remarks>
    /// This property provides access to the HelpDesk configuration, which includes the phone number and email address.
    /// These values are retrieved from the application's configuration source and default to "Unknown" if not specified.
    /// </remarks>
    public HelpDesk HelpDesk { get; }



    private AppConfiguration()
    {

        HelpDesk = Configuration.ReadSection<HelpDesk>(nameof(HelpDesk));

    }
}

