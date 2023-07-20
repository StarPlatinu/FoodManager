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

		public void OnGet(string searchQuery)
		{
            if (!string.IsNullOrEmpty(searchQuery))
            {
                SearchQuery = searchQuery;
                MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType").Where(p => p.Name.Contains(SearchQuery));
                CategoryList = _unitOfWork.Category.GetAll(orderby: u => u.OrderBy(c => c.DisplayOrder));

                List<Category> cat = CategoryList.ToList();

                for(int i = 0; i < cat.Count; i++)
                {
                    bool check = false;
                    foreach (var item in MenuItemList)
                    {
                        if (cat[i].Id == item.CategoryId)
                        {
                            check = false;
                            break;
                        }
                        else
                        {
                            check = true;
                        }
                    }
                    if (check)
                    {
                        cat.Remove(cat[i]);
                    }
                }
                CategoryList = cat;
            }
            else
            {
                MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
                CategoryList = _unitOfWork.Category.GetAll(orderby: u => u.OrderBy(c => c.DisplayOrder));
            }
		}
	}
}
