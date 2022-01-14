using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    public class Furto : Polizza
    {
        public int PercentualeCoperta { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" PercentualeCoperta: {PercentualeCoperta}";
        }
    }
}
