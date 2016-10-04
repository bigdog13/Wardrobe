using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe.ViewController;

namespace Wardrobe.Models
{
    public class OutfitsController : Controller
    {
        private WardrobeContext db = new WardrobeContext();

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.Bottom).Include(o => o.Shoe).Include(o => o.Top);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create()
        {

            Outfit outfit = new Outfit();
            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottomId = new SelectList(db.Bottoms, "BottomId", "BottomName", outfit.BottomOutfitID);
            ViewBag.ShoeId = new SelectList(db.Shoes, "ShoeId", "ShoeName", outfit.ShoeOutfitID);
            ViewBag.TopId = new SelectList(db.Tops, "TopId", "TopName", outfit.TopOutfitID);
            ViewBag.SeasonOutfitID = new SelectList(db.Seasons, "SeasonID", "SeasonName", outfit.SeasonOutfitID);
            ViewBag.OccasionOutfitID = new SelectList(db.Occasions, "OccasionID", "OccasionName", outfit.OccasionOutfitID);

            OutfitViewModel outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,
                // Look up all accessories, then converts them into
                // SelectListItem objects
                AllAccessories = (from a in db.Accessories
                                  select new SelectListItem
                                  {
                                      Value = a.AccessoryID.ToString(),
                                      Text = a.AccessoryName
                                  })
            };

            return View(outfitViewModel);
        }
        //{
        //    ViewBag.BottomOutfitID = new SelectList(db.Bottoms, "BottomID", "BottomName");
        //    ViewBag.ShoeOutfitID = new SelectList(db.Shoes, "ShoeID", "ShoeName");
        //    ViewBag.TopOutfitID = new SelectList(db.Tops, "TopID", "TopName");

        //    return View();
        //}

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitID,OutfitName,TopOutfitID,BottomOutfitID,ShoeOutfitID,SeasonOutfitID,OccasionOutfitId")] Outfit outfit, List<int> SelectedAccessories)
        {
            if (ModelState.IsValid)
            {
                var newOutfit = outfit;

                newOutfit.TopOutfitID = outfit.TopOutfitID;
                newOutfit.OutfitName = outfit.OutfitName;
                newOutfit.BottomOutfitID = outfit.BottomOutfitID;
                newOutfit.ShoeOutfitID = outfit.ShoeOutfitID;
                newOutfit.SeasonOutfitID = outfit.SeasonOutfitID;
                newOutfit.OccasionOutfitID = outfit.OccasionOutfitID;
                
                

                foreach (int i in SelectedAccessories)
                {
                    newOutfit.Accessories.Add(db.Accessories.Find(i));
                }
                db.Outfits.Add(newOutfit);
                //db.Entry(outfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottomOutfitID = new SelectList(db.Bottoms, "BottomID", "BottomName", outfit.BottomOutfitID);
            ViewBag.ShoeOutfitID = new SelectList(db.Shoes, "ShoeID", "ShoeName", outfit.ShoeOutfitID);
            ViewBag.TopOutfitID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopOutfitID);
            ViewBag.SeasonOutfitID = new SelectList(db.Seasons, "SeasonID", "SeasonName", outfit.SeasonOutfitID);
            ViewBag.OccasionOutfitID = new SelectList(db.Occasions, "OccasionID", "OccasionName", outfit.OccasionOutfitID);
            return View(outfit);
        }

        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Outfits.Add(outfit);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.BottomOutfitID = new SelectList(db.Bottoms, "BottomID", "BottomName", outfit.BottomOutfitID);
        //    ViewBag.ShoeOutfitID = new SelectList(db.Shoes, "ShoeID", "ShoeName", outfit.ShoeOutfitID);
        //    ViewBag.TopOutfitID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopOutfitID);
        //    return View(outfit);
        //}

        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottomId = new SelectList(db.Bottoms, "BottomId", "BottomName", outfit.BottomOutfitID);
            ViewBag.ShoeId = new SelectList(db.Shoes, "ShoeId", "ShoeName", outfit.ShoeOutfitID);
            ViewBag.TopId = new SelectList(db.Tops, "TopId", "TopName", outfit.TopOutfitID);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName", outfit.SeasonOutfitID);
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName", outfit.OccasionOutfitID);

            OutfitViewModel outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,
                // Look up all accessories, then converts them into
                // SelectListItem objects
                AllAccessories = (from a in db.Accessories
                                  select new SelectListItem
                                  {
                                      Value = a.AccessoryID.ToString(),
                                      Text = a.AccessoryName
                                  })
            };

            return View(outfitViewModel);
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitID,OutfitName,TopOutfitID,BottomOutfitID,ShoeOutfitID,SeasonOutfitID,OccasionOutfitId")] Outfit outfit, List<int> SelectedAccessories)
        {
            if (ModelState.IsValid)
            {
                var existingOutfit = db.Outfits.Find(outfit.OutfitID);

                existingOutfit.TopOutfitID = outfit.TopOutfitID;
                existingOutfit.OutfitName = outfit.OutfitName;
                existingOutfit.BottomOutfitID = outfit.BottomOutfitID;
                existingOutfit.ShoeOutfitID = outfit.ShoeOutfitID;
                existingOutfit.SeasonOutfitID = outfit.SeasonOutfitID;
                existingOutfit.OccasionOutfitID = outfit.OccasionOutfitID;

                existingOutfit.Accessories.Clear();

                foreach (int i in SelectedAccessories)
                {
                    existingOutfit.Accessories.Add(db.Accessories.Find(i));
                }

                //db.Entry(outfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottomOutfitID = new SelectList(db.Bottoms, "BottomID", "BottomName", outfit.BottomOutfitID);
            ViewBag.ShoeOutfitID = new SelectList(db.Shoes, "ShoeID", "ShoeName", outfit.ShoeOutfitID);
            ViewBag.TopOutfitID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopOutfitID);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName", outfit.SeasonOutfitID);
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName", outfit.OccasionOutfitID);
            return View(outfit);
        }

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            db.Outfits.Remove(outfit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
