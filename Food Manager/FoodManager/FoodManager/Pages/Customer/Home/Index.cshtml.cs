using FoodManager.Model;
using FoodManager.Repository;
using FoodManager.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodManager.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public string SearchQuery { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<MenuItem> MenuItemList { get; set; }
		public IEnumerable<Category> CategoryList { get; set; }

		public void OnGet()
		{
			MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
			CategoryList = _unitOfWork.Category.GetAll(orderby: u => u.OrderBy(c => c.DisplayOrder));
		}

		public IActionResult OnPost(string search)
		{

            MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
            CategoryList = _unitOfWork.Category.GetAll(orderby: u => u.OrderBy(c => c.DisplayOrder));

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                return Page();
            }
            else
            {
                return RedirectToPage("Error");
            }
        }
	}
}
