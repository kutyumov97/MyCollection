using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCollection.Data;
using MyCollection.Interfaces;
using MyCollection.Models;

namespace MyCollection.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IPhotoService _photoService;
        public CollectionController(ApplicationDbContext db, IPhotoService photoService)
        {
            _db = db;
            _photoService = photoService;
        }


        public IActionResult Index(string id)
        {
            if (User.IsInRole("admin") && id != null)
            {
                GlobalVariables.SelectedUserId = id;
            }
            var collections = _db.Collections.Where(x => x.AppUserId == GlobalVariables.SelectedUserId);
            return View(collections);
        }
        
        
        public IActionResult AllCollections()
        {
            var collections = _db.Collections.OrderBy(x => x.Name);
            return View(collections.ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionViewModel collectionVM)
        {
            if (!ModelState.IsValid) return View(collectionVM);
            var result = await _photoService.AddPhotoAsync(collectionVM.Image);
            var collection = new Collection
            {
                Name = collectionVM.Name,
                Description = collectionVM.Description,
                Theme = collectionVM.Theme,
                AppUserId = GlobalVariables.SelectedUserId,
                FieldName1 = collectionVM.FieldName1, FieldName2 = collectionVM.FieldName2, FieldName3 = collectionVM.FieldName3,
                TypeField1 = collectionVM.TypeField1, TypeField2 = collectionVM.TypeField2, TypeField3 = collectionVM.TypeField3,              
            };
            if (collectionVM.Image != null) collection.Image = result.Url.ToString();
            _db.Collections.Add(collection);
            _db.SaveChanges();
            TempData["success"] = "Collection created successfully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            GlobalVariables.CollectionId = id;
            var collection = _db.Collections.Find(id);
            var collectionVM = new EditCollectionViewModel
            {
                Name = collection.Name,
                Description = collection.Description,
                Theme = collection.Theme,
                //ImageURL = collection.Image,
            };
            return View(collectionVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCollectionViewModel collectionVM)
        {
            if (!ModelState.IsValid) return View("Edit", collectionVM);           
            var collection = _db.Collections.Find(id);
            //if (collection.Image != null) await _photoService.DeletePhotoAsync(collection.Image);                
            //var photoResult = await _photoService.AddPhotoAsync(collectionVM.Image);
            //if (photoResult.Error != null) return View("Edit", collectionVM);
            collection.Name = collectionVM.Name;
            collection.Description = collectionVM.Description;
            collection.Theme = collectionVM.Theme;
            collection.AppUserId = GlobalVariables.SelectedUserId;         
            //if (collectionVM.ImageURL != null) collection.Image = photoResult.Url.ToString();
            _db.Collections.Update(collection);
            _db.SaveChanges();
            TempData["success"] = "Collection updated successfully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Del(int id)
        {
            GlobalVariables.CollectionId = id;
            var obj = _db.Collections.Find(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Del(Collection obj)
        {           
            _db.Collections.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Collection deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
