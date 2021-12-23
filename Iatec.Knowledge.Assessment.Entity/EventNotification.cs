using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Entity
{
    public class EventNotification
    {
        public int IdEventNotification { get; set; }
        public int IdUser { get; set; }
        public int IdEvent { get; set; }
        public bool IsAcepted { get; set; }
    }
}
