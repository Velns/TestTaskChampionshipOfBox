using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Championship.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public int? AmountOfRounds { get; set; }
        public int? RefereePoints { get; set; }
        public DateTime? Date { get; set; }
        public String Boxer1Winner { get; set; }  //переможець завжди перший боксер
        public String Boxer2 { get; set; }

    }

}