using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Entity
{
    public class Eventos
    {
        [Key]
        public Guid IdEvento { get; set; }
        public string Nome { get; set; }
        public string Descripcao { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public TipoEventos TipoEvento { get; set; }
        public string UserOwner { get; set; }
        public bool IsDeleted { get; set; }
    }
    
    public enum TipoEventos 
    {
        Exclusivo,Compartilhado
    }
}
