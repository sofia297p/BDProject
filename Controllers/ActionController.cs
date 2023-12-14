using Microsoft.AspNetCore.Mvc;

namespace Sanatorium.Controllers
{
    public class ActionsController : Controller
    {
        private readonly sanatoriumContext _db;
        public ActionsController(sanatoriumContext db)
        {
            _db = db; 
        }

        public ActionResult Index() { return View(); }

        [HttpPost]
        public IActionResult PutAlcoholicInBed(int inspectorId, int alcoholicId, int bedId)
        {
            var pair = new AlcoholicInspector() { Date = DateTime.Now, InspectorId = inspectorId, AlcoholicId = alcoholicId, State = 1, BedId = bedId }; // 1 = in bed, 2 = released, 3 = escaped
            _db.AlcoholicInspectors.Add(pair);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult ReleaseAlcoholicInBed(int inspectorId, int alcoholicId, int bedId)
        {
            var pair = new AlcoholicInspector() { Date = DateTime.Now, InspectorId = inspectorId, AlcoholicId = alcoholicId, State = 2, BedId = bedId }; // 1 = in bed, 2 = released, 3 = escaped
            _db.AlcoholicInspectors.Add(pair);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult EscapeAlcoholicFromBed(int bedId, int inspectorId, int alcoholicId)
        {
            var pair = new AlcoholicInspector() { Date = DateTime.Now, InspectorId = inspectorId, AlcoholicId = alcoholicId, State = 3, BedId = bedId }; // 1 = in bed, 2 = released, 3 = escaped
            _db.AlcoholicInspectors.Add(pair);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Drink(QueryModel model)
        {
            var alcoholics = new List<int>();
            foreach (var id in  model.AlcoholicIds.Split(','))
            {
                alcoholics.Add(int.Parse(id));
            }
            var group = new Groupa() { GroupName = "alcoholics" };
            _db.Groupas.Add(group);
            _db.SaveChanges();
            foreach (var alcoholic in alcoholics)
            {
                _db.GroupAlcoholics.Add(new GroupAlcoholic() { GroupId = group.Id, AlcoholicId = alcoholic });
            }
            _db.DrinkProcesses.Add(new DrinkProcess() { DrinkTypeId = model.DrinkId, GroupAlcoholicId = group.Id, Date = DateTime.Now });
            _db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult LostConsciousness(int alcoholicId)
        {
            var alcoholic = _db.Alcoholics.FirstOrDefault(a => a.Id == alcoholicId);
            if (alcoholic == null)
                return BadRequest();

            alcoholic.Consciousness = !alcoholic.Consciousness;
            _db.Alcoholics.Update(alcoholic);
            _db.SaveChanges();
            return Ok(alcoholic);
        }
    }
}
