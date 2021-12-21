using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iatec.Knowledge.Assessment.Entity
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Alias { get; set; }
        public string PhoneNumber { get; set; }
    }
}
