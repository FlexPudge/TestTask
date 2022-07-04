using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TestApp.Data.Service;
using TestWebApplication.Data.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace TestWebApplication.ViewModel
{
    public class CreateAnalyzerViewModel : PageModel
    {
        [BindProperty]
        public Analyzer Analyzer { get; set; }
        public void OnGetAsync()
        {

        }
        public IActionResult OnPostAsync()
        {
            if (Analyzer != null)
            {
                Analyzer newAnalyzer = new Analyzer()
                {
                    Name = Analyzer.Name,
                    MeasureInterval = Analyzer.MeasureInterval,
                    Type = Analyzer.Type
                };

                if (ModelState.IsValid)
                {
                    ContextDB.GetContext().Analyzers.Update(newAnalyzer);
                    ContextDB.GetContext().SaveChanges();
                    TempData["success"] = "Analyzer updated successfully";
                    return RedirectToPage("./Index");
                }
            }
            return Page();
        }
    }
}
