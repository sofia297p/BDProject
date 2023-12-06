﻿using Microsoft.AspNetCore.Mvc;
using Sanatorium.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

           List<Person> alcoholics = result.ToList();

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
    }
}
