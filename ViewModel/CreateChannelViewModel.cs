using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TestApp.Data.Service;
using TestWebApplication.Data.Model;

namespace TestWebApplication.ViewModel
{
    public class CreateChannelViewModel : PageModel
    {
        [BindProperty]
        public Channel Channel { get; set; }
        public List<IsHot> SelectedChannel { get; set; }
        public void OnGetAsync()
        {
            SelectedChannel = new List<IsHot> ()
            {
                new IsHot { Id="true", Name="true" },
                new IsHot { Id="false", Name="false" },
            };

        }
        public IActionResult OnPostAsync()
        {
            Channel channel = new Channel()
            {
                Name = Channel.Name,
                IsHot = Channel.IsHot
            };

            if (ModelState.IsValid)
            {
                ContextDB.GetContext().Channels.Update(channel);
                ContextDB.GetContext().SaveChanges();
                TempData["success"] = "1";
                return RedirectToPage();
            }
            return Page();
        }
    }
}
