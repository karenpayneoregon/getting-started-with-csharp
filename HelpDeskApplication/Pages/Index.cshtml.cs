using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using SpecialValidatorsLibrary.Models;

namespace HelpDeskApplication.Pages;
public class IndexModel(IOptionsSnapshot<HelpDesk> helpdeskSnapshot) : PageModel
{

    private readonly IOptionsSnapshot<HelpDesk> _helpdeskSnapshot = helpdeskSnapshot;

    public void OnGet()
    {
    }
}
