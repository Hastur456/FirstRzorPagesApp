using FirstRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace FirstRazorPages.Pages
{
	[IgnoreAntiforgeryToken]
	public class EditModel : PageModel
	{
		public ApplicationContext context;

		[BindProperty]
		public User? Person { get; set; }

		public EditModel(ApplicationContext db)
		{
			context = db;
		}

		public async Task<IActionResult> OnGetAsync(int id)
		{
			Person = await context.Users.FindAsync(id);

			if (Person == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			context.Users.Update(Person!);
			await context.SaveChangesAsync();
			return RedirectToPage("UsersInform");
		}
	}
}
