using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    internal class Vita : Polizza 
    {
        public int AnniDelAssicurato { get; set; }


        public override string ToString()
        {
            return base.ToString() + $" AnniDelAssicurato: {AnniDelAssicurato}";
        }
    }
}
