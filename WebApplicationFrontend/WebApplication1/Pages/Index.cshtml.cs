using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
   
        public void OnGet()
        {
            
        }
        public IActionResult OnGetTasks()
		{
            return Redirect("/Tasks");
		}
        public IActionResult OnGetSearch()
		{
            return Redirect("/Search");
		}

    }
}
