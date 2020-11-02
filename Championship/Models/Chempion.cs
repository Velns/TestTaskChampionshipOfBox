using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Championship.Models
{
    public class Chempion
    {
        public static object GetChempionsList()
        {
            using (BattleContext db = new BattleContext())
            {
                List<Battle> battles = db.Battles.ToList();
                
                var wins = from b in battles                    //список перемог
                           group b by b.Boxer1Winner into b1
                           select new
                           {
                               Name = b1.Key,
                               BattlesWin = b1.Count()
                           };
                var losses = from b in battles                  // список поразок
                           group b by b.Boxer2 into b2
                           select new
                           {
                               Name = b2.Key,
                               BattlesLoss = b2.Count()
                           };

                // команди для full outer join немає в linq, тому доведеться зробити вручну
                var leftOuterJoin = from w in wins
                                    join l in losses on w.Name equals l.Name into temp
                                    from l in temp.DefaultIfEmpty()
                                    let BattlesLoss = (l != null) ? l.BattlesLoss : 0
                                    let AmountOfBattle = BattlesLoss + w.BattlesWin
                                    select new
                                    {
                                        w.Name,
                                        w.BattlesWin,
                                        BattlesLoss,
                                        AmountOfBattle,
                                        Ranking = (float)w.BattlesWin/ AmountOfBattle
                                    };
                var rightOuterJoin = from l in losses
                                     join w in wins on l.Name equals w.Name into temp
                                     from w in temp.DefaultIfEmpty()
                                     let BattlesLoss = (l != null) ? l.BattlesLoss : 0
                                     let BattlesWin = (w != null) ? w.BattlesWin : 0
                                     let AmountOfBattle = BattlesWin + l.BattlesLoss 
                                     select new
                                     {
                                         l.Name,
                                         BattlesWin,
                                         BattlesLoss,
                                         AmountOfBattle,
                                         Ranking = (float) BattlesWin / AmountOfBattle
                                     };
                var chempList = leftOuterJoin.Union(rightOuterJoin);    // результуючий список


                return chempList;
            }
            
        }
    }
}