using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace myWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string StudentName { get; private set; } = "PageModel in C#";
    private readonly myWebApp.Data.SchoolContext _context;

    public IndexModel(ILogger<IndexModel> logger, myWebApp.Data.SchoolContext context)
    {
        _logger = logger;
        _context= context;
    }

    public void OnGet()
    { try
    {
    var s =_context.Students?.Where(d=>d.ID==1).FirstOrDefault();
    this.StudentName =
    $"{s?.FirstMidName} {s?.LastName}";  
    }
    catch (System.Exception ex)
    {
           this.StudentName =
            $"error occured"; 
        _logger.LogError(ex.Message,ex);
    }

    }
}

