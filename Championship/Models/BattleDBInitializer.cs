using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Championship.Models
{
    // клас для заповнення бд тестовими даними
    // для запуску потрібно розкомітити стрічку "Database.SetInitializer(new BattleDBInitializer());"
    // в файлі Championship\Global.asax
    public class BattleDBInitializer : DropCreateDatabaseAlways<BattleContext>
    {
        protected override void Seed(BattleContext db)
        {
            db.Battles.Add(new Battle { AmountOfRounds = 1, Boxer1Winner = "BoxerA", Boxer2 = "BoxerB", RefereePoints = 1, Date = new DateTime(2001, 1, 1, 1, 1, 1) });
            db.Battles.Add(new Battle { AmountOfRounds = 2, Boxer1Winner = "BoxerB", Boxer2 = "BoxerA", RefereePoints = 2, Date = new DateTime(2002, 2, 2, 2, 2, 2) });
            db.Battles.Add(new Battle { AmountOfRounds = 3, Boxer1Winner = "BoxerC", Boxer2 = "BoxerD", RefereePoints = 3, Date = new DateTime(2003, 3, 3, 3, 3, 3) });
            db.Battles.Add(new Battle { AmountOfRounds = 4, Boxer1Winner = "BoxerB", Boxer2 = "BoxerD", RefereePoints = 4, Date = new DateTime(2004, 4, 4, 4, 4, 4) });
            
            base.Seed(db);
        }
    }
}