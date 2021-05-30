using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Pages.Search
{
    public class SearchModel : PageModel
    {
		public SearchModel()
		{
            //VacancyTypes = new SelectList(new string[] { "IT", "���������" });
            //Cities = new SelectList(new string[] { "������", "���", "������", "�������" });
		}

        //[BindProperty]
        public SelectList Cities { get; set; } = new SelectList(new string[] { ""});
        //[BindProperty]
        public SelectList VacancyTypes { get; set; } = new SelectList(new string[] { "" });
        //[BindProperty]
        public SelectList Metro { get; set; } = new SelectList(new string[] { "" });
        public IEnumerable<VacancyModel> Vacancies { get; set; } = new List<VacancyModel> {
            new VacancyModel
        {
            Name = "��������",
            Link = "https://www.gazprom.ru",
            Salary = 500,
            Experience = "5 ���"
            }
        };
        public void OnGet()
        {
            VacancyTypes = new SelectList(new string[] { "IT", "���������" });
            Cities = new SelectList(new string[] { "������", "���", "������", "�������" });
        }

        public ActionResult OnPostRedirectHH(string data)
		{
            //System.Diagnostics.Process.Start(data);
            return Page();
        }
    }
}
