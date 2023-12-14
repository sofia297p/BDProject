using Microsoft.AspNetCore.Mvc;


namespace Sanatorium.Controllers
{
    public class AlcoholicController : Controller
    {
        private readonly sanatoriumContext _db;
        public AlcoholicController(sanatoriumContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = from person in _db.People
                         join alcoholic in _db.Alcoholics on person.Id equals alcoholic.UserId
                         select person;

            var alcoholics = result.ToList();


            return View(alcoholics);

        }
        public IActionResult Update(int myParam)
        {
            var person = _db.People.FirstOrDefault(c => c.Id == myParam);
            return View(person);
        }

        [HttpPost]
        public IActionResult Update(Person person)
        {
            _db.People.Update(person);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add(int myParam)
        {
            var person = new Person();
            return View(person);
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();
            _db.Alcoholics.Add(new Alcoholic() { Consciousness = true, UserId = person.Id });
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var person = _db.People.Single(c => c.Id == id);
            var alcoholic = _db.Alcoholics.Single(c => c.UserId == id);
            var pairs = _db.AlcoholicInspectors.Where(c => c.AlcoholicId == id);

            _db.AlcoholicInspectors.RemoveRange(pairs);
            _db.SaveChanges();
            _db.Alcoholics.Remove(alcoholic);
            _db.SaveChanges();
            _db.People.Remove(person);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

      
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Person person)
        {
            _db.People.Add(person);
            
            _db.SaveChanges();
            var alcoholic = new Alcoholic
            {
               
                UserId = person.Id,
                Consciousness = true
            };

           
            _db.Alcoholics.Add(alcoholic);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var person = _db.People.FirstOrDefault(c => c.Id == id);
            return View(person);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var person = _db.People.FirstOrDefault(c => c.Id == id);

            // Видалення пов'язаних записів в таблиці "alcoholic"
            var alcoholics = _db.Alcoholics.Where(a => a.UserId == id);
            _db.Alcoholics.RemoveRange(alcoholics);

            // Видалення запису "person"
            _db.People.Remove(person);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
