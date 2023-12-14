using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sanatorium.Controllers
{
    public class InspectorController : Controller
    {
        private readonly sanatoriumContext _db;


        public InspectorController(sanatoriumContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = from person in _db.People
                         join inspector in _db.Inspectors on person.Id equals inspector.UserId
                         select person;

            List<Person> inspertors = result.ToList();
            
            return View(inspertors);
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

        public IActionResult Add()
        {
            var person = new Person();
            return View(person);
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();
            _db.Inspectors.Add(new Inspector() { UserId = person.Id });
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var person = _db.People.Single(c => c.Id == id);
            var inspector = _db.Inspectors.Single(c => c.UserId == id);
            var pairs = _db.AlcoholicInspectors.Where(c => c.InspectorId == id);

            _db.AlcoholicInspectors.RemoveRange(pairs);
            _db.SaveChanges();
            _db.Inspectors.Remove(inspector);
            _db.SaveChanges();
            _db.People.Remove(person);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
