using FirstRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace FirstRazorPages.Pages
{
	[IgnoreAntiforgeryToken]
	public class CreateModel : PageModel
    {
		ApplicationContext context;

		public User Person { get; set; } = new();
        public CreateModel(ApplicationContext db)
        {
            context = db;
		}

		public async Task<IActionResult> OnPostAsync(string? userName, int age)
        {
			Person.UserName = userName;
			Person.Age = age;
			context.Users.Add(Person);
            await context.SaveChangesAsync();
            return RedirectToPage("UsersInform");
        }
    }
}
