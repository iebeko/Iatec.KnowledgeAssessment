using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Entity
{
   public class AgendaEventos
    {
        [Key]
        public int IdAgendaEventos { get; set; }
        public int IdEvento { get; set; }
       
        public int IdAgenda { get; set; }
        public string NomeEvento { get; set; }
        public string Mes { get; set; }
        public string MesLiteral { get; set; }
        public int Year { get; set; }
        public DateTime DataEvento { get; set; }
        
    }
}
