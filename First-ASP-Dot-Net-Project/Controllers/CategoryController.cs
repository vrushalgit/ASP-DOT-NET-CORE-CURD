using First_ASP_Dot_Net_Project.Data;
using First_ASP_Dot_Net_Project.Models;
using Microsoft.AspNetCore.Mvc;


namespace First_ASP_Dot_Net_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Home page of Category for displaying Categories
        public IActionResult Index()
        {
            IEnumerable<Category> objCatergoryList = _db.Categories;
            return View(objCatergoryList);
        }

        // Showing Add Category page
        // GET 
        public IActionResult Create()
        {
            return View();
        }

        //adding new Categories
        // POST 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and display order could not be same");
            }
            else if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET
        [HttpGet]
         public IActionResult Edit(int? id)
         {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
         }
        //adding new Categories
        // POST 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and display order could not be same");
            }
            else if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);

        }
        // GET
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //adding new Categories
        // POST 

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj); 
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
