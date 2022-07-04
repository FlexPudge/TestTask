using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using TestApp.Data.Service;
using TestWebApplication.Data.Model;

namespace TestWebApplication.ViewModel
{
    public class EditChannelViewModel : PageModel
    {
        [BindProperty]
        public Channel Channel { get; set; }
        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Channel = ContextDB.GetContext().Channels.Find(id);
            

            if (Channel == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPostAsync(Analyzer obj)
        {
            Channel newChannel = ContextDB.GetContext().Channels.Find(obj.Id);
            newChannel.Name = Channel.Name;
            newChannel.IsHot = Channel.IsHot;

            if (ModelState.IsValid)
            {
                ContextDB.GetContext().Channels.Update(newChannel);
                ContextDB.GetContext().SaveChanges();
                TempData["success"] = "Analyzer updated successfully";
                return RedirectToPage();
            }
            return Page();
        }
    }
}
