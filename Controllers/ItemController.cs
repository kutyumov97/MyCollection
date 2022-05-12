using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCollection.Data;
using MyCollection.Models;

namespace MyCollection.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }        


        public async Task<IActionResult> Index(int id, string UserId, string searchString, string tag, string name, SortState sortOrder = SortState.NameAsc)
        {            
            var items = _db.Items.Where(x => x.CollectionId == id);
            
            if (String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(tag) && String.IsNullOrEmpty(name))
            {                
                if (UserId != null) GlobalVariables.SelectedCollectionAutorId = UserId;
                if (id != 0) GlobalVariables.CollectionId = id;
                var collections = _db.Collections.Find(GlobalVariables.CollectionId);
                GlobalVariables.FieldName1 = collections.FieldName1;
                GlobalVariables.TypeField1 = collections.TypeField1;
                GlobalVariables.FieldName2 = collections.FieldName2;
                GlobalVariables.TypeField2 = collections.TypeField2;
                GlobalVariables.FieldName3 = collections.FieldName3;
                GlobalVariables.TypeField3 = collections.TypeField3;

                ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
                ViewData["TagSort"] = sortOrder == SortState.TagAsc ? SortState.TagDesc : SortState.TagAsc;
                items = sortOrder switch
                {
                    SortState.NameDesc => items.OrderByDescending(s => s.Name),
                    SortState.TagAsc => items.OrderBy(s => s.Tags),
                    SortState.TagDesc => items.OrderByDescending(s => s.Tags),                    
                    _ => items.OrderBy(s => s.Name),
                };
            }
            else if (!String.IsNullOrEmpty(searchString))
            {
                items = _db.Items.FullTextSearchQuery(searchString);
                var collections = _db.Collections.FullTextSearchQuery(searchString);
                foreach (var obj in collections)
                {
                    var collectionItems = _db.Items.Where(x => x.CollectionId == obj.Id);
                    items = items.Concat(collectionItems).Distinct().OrderBy(x => x.Name);
                }
            }
            else if (!String.IsNullOrEmpty(tag) && !String.IsNullOrEmpty(name))
            {
                items = items.Where(s => s.Name.Contains(name) && s.Tags.Contains(tag));
            }
            else if (!String.IsNullOrEmpty(tag) || !String.IsNullOrEmpty(name))
            {
                items = items.Where(s => s.Name.Contains(name) || s.Tags.Contains(tag));
            }
            return View(await items.AsNoTracking().ToListAsync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Tags, int? AddInt1, int? AddInt2, int? AddInt3,
            string? AddString1, string? AddString2, string? AddString3, string? AddText1, string? AddText2, string? AddText3,
            DateTime? AddTime1, DateTime? AddTime2, DateTime? AddTime3, bool? AddBool1, bool? AddBool2, bool? AddBool3)
        {
            if (!ModelState.IsValid) return View();
            _db.Items.Add(new Item
            {
                Name = Name, 
                Tags = Tags, 
                CollectionId = GlobalVariables.CollectionId, 
                AppUserId = GlobalVariables.SelectedUserId, 
                AddInt1 = AddInt1, AddInt2 = AddInt2, AddInt3 = AddInt3,           
                AddString1 = AddString1, AddString2 = AddString2, AddString3 = AddString3, 
                AddText1 = AddText1, AddText2 = AddText2, AddText3 = AddText3,
                AddTime1 = AddTime1, AddTime2 = AddTime2, AddTime3 = AddTime3, 
                AddBool1 = AddBool1, AddBool2 = AddBool2, AddBool3 = AddBool3
            });
            _db.SaveChanges();
            TempData["success"] = "Item created successfully";
            return RedirectToAction("Index", new { id = GlobalVariables.CollectionId });
        }


        public IActionResult Details(int id)
        {
            //GlobalVariables.ItemId = id;
            var obj = _db.Items.Find(id);
            return View(obj);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var obj = _db.Items.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(int id, string Name, string Tags, int? AddInt1, int? AddInt2, int? AddInt3,
            string? AddString1, string? AddString2, string? AddString3, string? AddText1, string? AddText2, string? AddText3,
            DateTime? AddTime1, DateTime? AddTime2, DateTime? AddTime3, bool? AddBool1, bool? AddBool2, bool? AddBool3)
        {
            if (!ModelState.IsValid) return View();
            var obj = _db.Items.Find(id);
            obj.Name = Name;
            obj.Tags = Tags;
            obj.AddInt1 = AddInt1; obj.AddInt2 = AddInt2; obj.AddInt3 = AddInt3;
            obj.AddString1 = AddString1; obj.AddString2 = AddString2; obj.AddString3 = AddString3;
            obj.AddText1 = AddText1; obj.AddText2 = AddText2; obj.AddText3 = AddText3;
            obj.AddTime1 = AddTime1; obj.AddTime2 = AddTime2; obj.AddTime3 = AddTime3;
            obj.AddBool1 = AddBool1; obj.AddBool2 = AddBool2; obj.AddBool3 = AddBool3;
            _db.SaveChanges();
            TempData["success"] = "Item updated successfully";
            return RedirectToAction("Index", new { id = GlobalVariables.CollectionId });
        }


        [HttpGet]
        public ActionResult Del(int id)
        {
            var itemFromDb = _db.Items.Find(id);
            return View(itemFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Del(Item obj)
        {
            _db.Items.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Item deleted successfully";
            return RedirectToAction("Index", new { id = GlobalVariables.CollectionId });
        }

        
        //public async Task<IActionResult> Search(string keyword)
        //{
        //    var results = await _elasticClient.SearchAsync<Item>(
        //        s => s.Query(
        //            q => q.QueryString(
        //                d => d.Query('*' + keyword + '*')
        //            )
        //        ).Size(10)
        //    );

        //    return View(results.Documents.ToList());
        //}
    }
}

