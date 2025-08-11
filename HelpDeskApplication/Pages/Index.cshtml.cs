using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;
using SpecialValidatorsLibrary.Models;

namespace HelpDeskApplication.Pages;
public class IndexModel(IOptionsSnapshot<HelpDesk> helpdeskSnapshot) : PageModel
{
    public void OnGet()
    {
        Log.Information(helpdeskSnapshot.Value.Phone);
        Log.Information(helpdeskSnapshot.Value.Email);
    }
}
