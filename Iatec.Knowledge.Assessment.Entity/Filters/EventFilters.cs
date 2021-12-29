using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Entity.Filters
{
   public class EventFilters
    {

        public string Name { get; set; }
        public string UserOwner { get; set; }
            public bool? IsSharable { get; set; }
            public DateTime? Date { get; set; }
            public string Place { get; set; }
            public int? Participants { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? TypeEvent { get; set; }
        

    }
}
