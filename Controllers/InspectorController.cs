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

            List<Person> inspeсtors = result.ToList();
            return View(inspeсtors);


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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
