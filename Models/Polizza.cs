using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    public class Polizza
    {
        public int NumeroID { get; set; }
        public DateTime DataStipula { get; set; }
        public float ImportoAssicurato { get; set; }
        public float RataMensile { get; set; }

        public string CodiceFiscaleID { get; set; }
        public Cliente Cliente { get; set; }



        public override string ToString()
        {
            return $" Numero:{NumeroID} -DataStipula: {DataStipula}-ImportoAssicurato:{ImportoAssicurato}-RataMensile: {RataMensile}-cliente:{Cliente}";


        }
    }
}
