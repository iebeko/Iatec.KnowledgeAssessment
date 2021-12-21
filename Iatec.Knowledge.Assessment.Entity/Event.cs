using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Entity
{
    public class Event
    {
        [Key]
        public Guid IdEvent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public TypeEvents TypeEvent { get; set; }
        public string UserOwner { get; set; }
        public bool IsDeleted { get; set; }
        public bool  IsShareable { get; set; }
    }
    
    public enum TypeEvents 
    {
        Exclusivo,Compartilhado
    }
}
