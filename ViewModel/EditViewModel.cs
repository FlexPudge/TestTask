using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestApp.Data.Service;
using TestWebApplication.Data.Model;

namespace TestWebApplication.ViewModel
{
    public class EditViewModel : PageModel
    {
        [BindProperty]
        public Analyzer Analyzer { get; set; }

        public  IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             Analyzer = ContextDB.GetContext().Analyzers.Find(id);

            if (Analyzer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(Analyzer obj)
        {
            Analyzer newAnalyzer = ContextDB.GetContext().Analyzers.Find(obj.Id);
            newAnalyzer.Name = Analyzer.Name;
            newAnalyzer.MeasureInterval = Analyzer.MeasureInterval;
            newAnalyzer.Type = Analyzer.Type;

            if (ModelState.IsValid)
            {
                ContextDB.GetContext().Analyzers.Update(newAnalyzer);
                ContextDB.GetContext().SaveChanges();
                TempData["success"] = "Analyzer updated successfully";
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
