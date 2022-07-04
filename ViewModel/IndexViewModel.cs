using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Data.Service;
using TestWebApplication.Data.Model;

namespace TestWebApplication.ViewModel
{
    public class IndexViewModel : PageModel
    {
        private List<Analyzer> analyzers;
        public List<Analyzer> Analyzers
        {
            get => analyzers;
            set => analyzers = value;
        }
        public void OnGet()
        {
            Analyzers = ContextDB.GetContext().Analyzers.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            AnalyzerChannel analyzerChannel = ContextDB.GetContext().AnalyzerChannels.FirstOrDefault(x=>x.Idanalyzer == id);
            var analyzer = await ContextDB.GetContext().Analyzers.FindAsync(id);

            if (analyzer != null)
            {
                ContextDB.GetContext().AnalyzerChannels.Remove(analyzerChannel);
                ContextDB.GetContext().Analyzers.Remove(analyzer);
                await ContextDB.GetContext().SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
