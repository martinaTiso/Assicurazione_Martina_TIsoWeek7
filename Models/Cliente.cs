using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Models
{
    internal class Cliente
    {

        public string CodiceFiscaleID { get; set; }

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }

        public ICollection<Polizza> Polizze { get; set; } = new List<Polizza>();

        //public float GetSpesaTotale()
        //{
        //    return Polizza.Sum(p => p.RataMensile);
        //}

        public override string ToString()
        {
            return $"{CodiceFiscaleID} - {Nome}{Cognome}";


        }
    }
}
