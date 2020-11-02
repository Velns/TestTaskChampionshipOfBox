using Championship.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Championship.Controllers
{
    public class HomeController : Controller
    {
        private BattleContext db = new BattleContext();
        
        [HttpPost]
        public void EditBattle(Battle battle)
        {
            db.Entry(battle).State = EntityState.Modified;
            db.SaveChanges();
        }

        [HttpPost]
        public void CreateBattle(Battle battle)
        {
            db.Battles.Add(battle);
            db.SaveChanges();
        }

        [HttpPost]
        public void DeleteBattle(int id)
        {
            Battle battle = db.Battles.Find(id);
            db.Battles.Remove(battle);
            db.SaveChanges();
        }
            
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Edit()
        {
            return View();
        }
       
        public ActionResult Chempionsip()
        {
            return View();
        }
        public string GetDataBattles()
        {
            return JsonConvert.SerializeObject(db.Battles.ToList());
        }

        public string GetDataChempions()
        {
            return JsonConvert.SerializeObject(Championship.Models.Chempion.GetChempionsList());
        }
    }
}