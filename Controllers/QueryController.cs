using Microsoft.AspNetCore.Mvc;

namespace Sanatorium.Controllers
{
    public class QueryController : Controller
    {
        private readonly sanatoriumContext _db;
        public QueryController(sanatoriumContext db)
        {
            _db = db;
        }
        public ActionResult Index() { return View(); }


        public IActionResult GetAlcoholicsInspectors(QueryModel model)
        {
            var alcoholicsInspectorsThatPutHimInBed = _db.AlcoholicInspectors.Where(e => e.AlcoholicId == model.AlcoholicId && e.Date >= model.From && e.Date <= model.To && e.State == 1);
            var inspectorIds = alcoholicsInspectorsThatPutHimInBed.Select(e => e.InspectorId).Distinct().ToList();

            List<int?> inspectorsIDS = new List<int?>() { };
            foreach (var inspectorId in inspectorIds)
            {
                int timesInspectors = 0;
                foreach (var alcoholic in alcoholicsInspectorsThatPutHimInBed)
                {
                    if (alcoholic.InspectorId == inspectorId)
                    { timesInspectors++; }
                }
                if (timesInspectors >= model.Times)
                    inspectorsIDS.Add(inspectorId);
            }

            var inspectors = new List<Person>();
            foreach (var inspectorId in inspectorsIDS)
            {
                var inspector = _db.People.FirstOrDefault(e => e.Id == inspectorId);
                if (inspector != null)
                {
                    inspectors.Add(inspector);
                }
            }

            return View(inspectors);
        }

        public IActionResult GetAlcoholicsBeds(QueryModel model)
        {
            var bedIds = _db.AlcoholicInspectors.Where(e => e.AlcoholicId == model.AlcoholicId && e.Date >= model.From && e.Date <= model.To).DistinctBy(e => e.Id).Select(e => e.BedId);

            var beds = new List<Bed>();
            foreach (var bedID in bedIds)
            {
                var bed = _db.Beds.FirstOrDefault(e => e.Id == bedID);
                if (bed != null)
                {
                    beds.Add(bed);
                }
            }

            return View(beds); ;
        }

        public IActionResult GetAlcoholicsForInspectorTimesPutInBed(QueryModel model)
        {

            var alcoholicsIdsInspectorsThatPutHimInBed = _db.AlcoholicInspectors.Where(e => e.InspectorId == model.InspectorId && e.Date >= model.From && e.Date <= model.To && e.State == 1);
            var alcoholicsIds = alcoholicsIdsInspectorsThatPutHimInBed.Select(e => e.AlcoholicId).Distinct();
            List<Person> alcoholics = new List<Person>() { };
            foreach (var alcoholicId in alcoholicsIds)
            {
                int timesAcloholics = 0;
                foreach (var alcoholic in alcoholicsIdsInspectorsThatPutHimInBed)
                {
                    if (alcoholic.AlcoholicId == alcoholicId)
                    { timesAcloholics++; }
                }
                if (timesAcloholics >= model.Times)
                    alcoholics.Add(_db.People.FirstOrDefault(e => e.Id == alcoholicId));
            }
            return View(alcoholics);
        }

        public IActionResult GetAlcoholicsEscapedBeds(QueryModel model)
        {
            var escapedAlcoholicsBeds = _db.AlcoholicInspectors.Where(e => e.AlcoholicId == model.AlcoholicId && e.Date >= model.From && e.Date <= model.To).ToList();
            var beds = new List<Bed>();
            foreach(var bed in escapedAlcoholicsBeds)
            {
                beds.Add(_db.Beds.FirstOrDefault(e => e.Id == bed.BedId));
            }
            beds = beds.DistinctBy(e =>  e.Id).ToList();
            return View(beds);
        }

        //released > putInBed

        public IActionResult GetAlcoholicsTimesPutInBed(QueryModel model)
        {

            var alcoholicsPutInBed = _db.AlcoholicInspectors.Where(e => e.Date >= model.From && e.Date <= model.To && e.State == 1);
            var alcoholicsIds = alcoholicsPutInBed.Select(e => e.AlcoholicId).Distinct();
            List<Person?> alcoholics = new List<Person?>() { };
            foreach (var alcoholicId in alcoholicsIds)
            {
                int timesAcloholics = 0;
                foreach (var alcoholicInspector in alcoholicsPutInBed)
                {
                    if (alcoholicInspector.AlcoholicId == alcoholicId)
                    { timesAcloholics++; }

                    var alcoholic =  _db.People.FirstOrDefault(e => e.Id == alcoholicId);
                    if (timesAcloholics >= model.Times)
                        alcoholics.Add(alcoholic);
                }
               alcoholics = alcoholics.DistinctBy(e => e.Id).ToList();
            }
            return View(alcoholics);
        }

        public IActionResult GetAllPairsForInspectorAndAlcoholic(QueryModel model)
        {
            var alcoholicsInspectors = _db.AlcoholicInspectors.Where(e => e.Date >= model.From && e.Date <= model.To && e.InspectorId == model.InspectorId && e.AlcoholicId == model.AlcoholicId);
            return View(alcoholicsInspectors);
        }

        public IActionResult EscapedTotalByMonth()
        {
            var date = DateTime.Now;
            var escapedInJanuary = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/01/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/02/01").AddDays(-1)).Count();
            var escapedInFebruary = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/02/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/03/01").AddDays(-1)).Count();
            var escapedInMarch = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/03/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/04/01").AddDays(-1)).Count();
            var escapedInApril = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/04/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/05/01").AddDays(-1)).Count();
            var escapedInMay = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/05/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/06/01").AddDays(-1)).Count();
            var escapedInJune = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/06/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/07/01").AddDays(-1)).Count();
            var escapedInJuly = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/07/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/08/01").AddDays(-1)).Count();
            var escapedInAugust = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/08/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/09/01").AddDays(-1)).Count();
            var escapedInSeptember = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/09/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/10/01").AddDays(-1)).Count();
            var escapedInOctober = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/10/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/11/01").AddDays(-1)).Count();
            var escapedInNovember = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/11/01") && e.State == 3 && e.Date <= DateTime.Parse("2023/12/01").AddDays(-1)).Count();
            var escapedInDecember = _db.AlcoholicInspectors.Where(e => e.Date >= DateTime.Parse("2023/12/01") && e.State == 3 && e.Date <= DateTime.Parse("2024/01/01").AddDays(-1)).Count();

            return View(new List<(string, int)> { new("January", escapedInJanuary), new ("February", escapedInFebruary),
                new ("March", escapedInMarch), new ("April", escapedInApril), new ("May", escapedInMay), new ("June", escapedInJune),
                new ("July", escapedInJuly), new ("August", escapedInAugust), new ("September", escapedInSeptember), new ("October", escapedInOctober),
                new ("November", escapedInNovember), new ("December", escapedInDecember)});
        }

        public IActionResult GetInspectorsReleasedLessThenPutToBed(QueryModel model)
        {
            var alcoholicsInspectorsThatPutHimInBed = _db.AlcoholicInspectors.Where(e => e.AlcoholicId == model.AlcoholicId && e.State == 1);
            var alcoholicsInspectorsThatReleasedHimFromBed = _db.AlcoholicInspectors.Where(e => e.AlcoholicId == model.AlcoholicId && e.State == 2);
            List<int> inspectorsPutIDS = new List<int>() { };
            List<int> inspectorsReleasedIDS = new List<int>() { };

            foreach (var inspectorPut in alcoholicsInspectorsThatPutHimInBed)
            {
                if (inspectorPut.InspectorId != null)
                    inspectorsPutIDS.Add((int)inspectorPut.InspectorId);
            }

            foreach (var inspectorRelease in alcoholicsInspectorsThatReleasedHimFromBed)
            {
                if (inspectorRelease.InspectorId != null)
                    inspectorsReleasedIDS.Add((int)inspectorRelease.InspectorId);
            }

            List<int> inspectorsIDS = new List<int>() { };

            foreach (var inspectorId in inspectorsPutIDS)
            {
                if (_db.AlcoholicInspectors.Where(e => e.InspectorId == inspectorId && e.AlcoholicId == model.AlcoholicId && e.State == 1).Count()
                    > _db.AlcoholicInspectors.Where(e => e.InspectorId == inspectorId && e.AlcoholicId == model.AlcoholicId && e.State == 2).Count())
                {
                    inspectorsIDS.Add(inspectorId);
                }
            }

            List<Person> inspectors = new List<Person>() { };

            foreach (var inspectorId in inspectorsIDS)
            {
                var inspector = _db.People.FirstOrDefault(e => e.Id == inspectorId);
                if (inspector != null)
                {
                    inspectors.Add(inspector);
                }
            }

            return View(inspectors);
        }
    }
}
