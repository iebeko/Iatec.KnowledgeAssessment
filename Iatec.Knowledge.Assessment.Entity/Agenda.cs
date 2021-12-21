using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Entity
{
    public class Agenda
    {
        public int IdAgenda { get; set; }
        public int IdUser { get; set; }
        public virtual IEnumerable<Eventos> EventosList{ get; set; }
    }
}
