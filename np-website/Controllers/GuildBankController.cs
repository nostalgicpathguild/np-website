using np_website.Models.GuildBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace np_website.Controllers
{
    [RoutePrefix("guild-bank")]
    public class GuildBankController : Controller
    {
        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        [Route("tools", Name = "GuildBankTools")]
        public ActionResult Tools()
        {
            return View();
        }

        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        [Route("tools/review", Name = "GuildBankReviewDump")]
        public ActionResult ReviewDump()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var items = db.InventoryItems.Where(f => f.Imported == false);
                var characters = items.Select(f => f.CharacterName).Distinct().ToList();
                var viewModel = new ReviewDumpModel();
                viewModel.ImportedItems = new List<ReviewDumpItemModel>();

                foreach (var character in characters)
                {

                    foreach (var item in items.Where(f => f.CharacterName == character))
                    {
                        var currentCount = db.InventoryItems.Where(f => f.CharacterName == character && f.Imported == true && f.Active == true && f.ItemId == item.ItemId).Select(f => f.Count).FirstOrDefault();

                        viewModel.ImportedItems.Add(new ReviewDumpItemModel()
                        {
                            CharacterName = item.CharacterName,
                            Location = item.Location,
                            Name = item.Name,
                            ItemId = item.ItemId,
                            Count = item.Count,
                            Slots = item.Slots,
                            PreviousCount = currentCount
                        });
                    }

                    var itemIds = items.Select(f => f.ItemId).Distinct();
                    var missingItems = db.InventoryItems.Where(f => f.CharacterName == character && f.Imported == true && f.Active == true && !itemIds.Contains(f.ItemId)).Select(f => f.ItemId).ToList();


                    foreach (var id in missingItems)
                    {
                        var item = db.InventoryItems.FirstOrDefault(f => f.CharacterName == character && f.Imported == true && f.Active == true && f.ItemId == id);
                        var currentCount = db.InventoryItems.Where(f => f.CharacterName == character && f.Imported == true && f.Active == true && f.ItemId == id).Sum(f => f.Count);

                        viewModel.ImportedItems.Add(new ReviewDumpItemModel()
                        {
                            CharacterName = item.CharacterName,
                            Location = item.Location,
                            Name = item.Name,
                            ItemId = item.ItemId,
                            Count = 0,
                            Slots = item.Slots,
                            PreviousCount = currentCount
                        });
                    }
                }

                return View(viewModel);
            }

        }

        [SiteAuthorize(UserLevels = new int[] { 6, 7 })]
        public ActionResult UploadDump(DumpUploadModel viewModel)
        {
            try
            {
                var inventory = viewModel.ProcessFiles();

                using (var db = new Database.NPGuildEntities())
                {
                    // Remove parsed but not imported items from the database.
                    var removeItems = db.InventoryItems.Where(f => f.Imported == false);
                    db.InventoryItems.RemoveRange(removeItems);
                    db.SaveChanges();

                    // Add each item to the database, setting imported = false.
                    foreach(var item in inventory)
                    {
                        db.InventoryItems.Add(new Database.InventoryItem()
                        {
                            CharacterName = item.CharacterName,
                            Location = item.Location,
                            Name = item.Name,
                            ItemId = item.ID,
                            Count = item.Count, 
                            Slots = item.Slots,
                            Active = true,
                            Public = true,
                            Imported = false
                        });
                    }

                    db.SaveChanges();
                }

                return RedirectToRoute("GuildBankReviewDump");
            }
            catch (Exception ex)
            {

                var msg = string.Empty;
                while (ex != null)
                {
                    msg += ex.Message + "<br />";
                    ex = ex.InnerException;
                }

                ModelState.AddModelError(string.Empty, msg);
                
            }

            return View("Tools");
        }
    }
}
