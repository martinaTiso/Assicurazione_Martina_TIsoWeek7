using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    internal class RCauto : Polizza
    {
        [MaxLength(5)]
        public string Targa { get; set; }
        public int Cilindrata { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Targa: {Targa} Cilindrata : {Cilindrata}";
        }
    }
}
