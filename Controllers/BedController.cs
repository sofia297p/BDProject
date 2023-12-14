using Microsoft.AspNetCore.Mvc;

namespace Sanatorium.Controllers
{
    public class BedController : Controller
    {
        private readonly sanatoriumContext _db;
        public BedController(sanatoriumContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Beds.ToList());

        }
        public IActionResult Update(int id)
        {
            var bed = _db.Beds.FirstOrDefault(c => c.Id == id);
            return View(bed);
        }

        [HttpPost]
        public IActionResult Update(Bed bed)
        {
            _db.Beds.Update(bed);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            var bed = new Bed();
            return View(bed);
        }

        [HttpPost]
        public IActionResult Add(Bed bed)
        {
            _db.Beds.Add(bed);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var bed = _db.Beds.Single(c => c.Id == id);
            _db.Beds.Remove(bed);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
