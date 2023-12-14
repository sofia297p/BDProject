using Microsoft.AspNetCore.Mvc;

namespace Sanatorium.Controllers
{
    public class DrinkController : Controller
    {
        private readonly sanatoriumContext _db;
        public DrinkController(sanatoriumContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.DrinkTypes.ToList());
        }

        public IActionResult Update(int myParam)
        {
            var drink = _db.DrinkTypes.FirstOrDefault(c => c.Id == myParam);
            return View(drink);
        }

        [HttpPost]
        public IActionResult Update(DrinkType drink)
        {
            var update = _db.DrinkTypes.Single(e => e.Id == drink.Id);
            update.AlcoholDegree = drink.AlcoholDegree;
            update.Name = drink.Name;
            _db.DrinkTypes.Update(update);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            var drink = new DrinkType();
            return View(drink);
        }

        [HttpPost]
        public IActionResult Add(DrinkType drink)
        {
            _db.DrinkTypes.Add(drink);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var drink = _db.DrinkTypes.Single(c => c.Id == id);
            var drinkProcesses = _db.DrinkProcesses.Where(c => c.DrinkTypeId == id);

            _db.DrinkProcesses.RemoveRange(drinkProcesses);
            _db.SaveChanges();
            _db.DrinkTypes.Remove(drink);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
