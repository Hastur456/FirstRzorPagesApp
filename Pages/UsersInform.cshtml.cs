using FirstRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RazorPagesApp.Models;

namespace FirstRazorPages.Pages
{
    public class UsersInformModel : PageModel
    {
		ApplicationContext? context;
		public List<User> Users { get; set; } = new();
		public UsersInformModel(ApplicationContext db)
		{
			context = db;
		}
		public void OnGet()
		{
			Users = context!.Users.AsNoTracking().ToList();
		}

		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			var user = await context!.Users.FindAsync(id);

			if (user != null)
			{
				context.Users.Remove(user);
				await context.SaveChangesAsync();
			}

			return RedirectToPage("UsersInform");
		}
	}
}
