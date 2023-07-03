using FoodManager.Model;
using FoodManager.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodManager.Pages.Admin.Categories
{
	[BindProperties]
	public class IndexModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public IEnumerable<Category> Categories { get; set; }
		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void OnGet()
        {
			Categories = _unitOfWork.Category.GetAll();
        }
    }
}
