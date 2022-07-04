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
    public class ChannelViewModel : PageModel
    {
        [BindProperty]
        public Analyzer Analyzer { get; set; }
        

        private List<AnalyzerChannel> analyzerChannels;
        public List<AnalyzerChannel> AnalyzerChannels
        {
            get => analyzerChannels;
            set => analyzerChannels = value;
        }
        private IEnumerable<Channel> channels;
        public IEnumerable<Channel> Channels
        {
            get => channels;
            set
            {
                channels = value;
            }
        }
        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Analyzer = ContextDB.GetContext().Analyzers.Find(id);

            AnalyzerChannels = ContextDB.GetContext().AnalyzerChannels
                .Include(x => x.IdchannelNavigation)
                .Include(x => x.IdanalyzerNavigation).Where(x => x.Idanalyzer == id).ToList();

            Channels = ContextDB.GetContext().Channels.ToList();


            if (Analyzer == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var delete = await ContextDB.GetContext().AnalyzerChannels.FindAsync(id);

            if (delete != null)
            {
                ContextDB.GetContext().AnalyzerChannels.Remove(delete);
                await ContextDB.GetContext().SaveChangesAsync();
            }

            return RedirectToPage();
        }
        public void UpdateHeadling (int id)
        {
            
        }
    }
}
