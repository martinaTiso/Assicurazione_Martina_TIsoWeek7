using Assicurazione.Models;
using Assicurazione.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione
{
    public static class Menu
    {
        static IRepositoryCliente repoCliente = new RepositoryCliente();
        static IRepositoryPolizza repoPolizza = new RepositoryPolizza();
        public static bool Start()
        {
            Console.WriteLine("Benvenuto");
            Console.WriteLine("1. Aggiungi Cliente");
            Console.WriteLine("2. Aggiungi Polizza");
            Console.WriteLine("3. Visualizza dati");
            Console.WriteLine("4. Per uscire");
            int scelta = -1;
            Console.Write("Scelta ->");
            bool verifica = Int32.TryParse(Console.ReadLine(), out scelta);
            while (scelta > 4 || scelta < 0 || verifica == false)
            {
                Console.WriteLine("Inserisci un valore corretto");
                verifica = Int32.TryParse(Console.ReadLine(), out scelta);
            }
            return GestireScelta(scelta);
        }
        private static bool GestireScelta(int scelta)
        {
            bool continua = true;
            switch (scelta)
            {
                case 1:
                    AggiungiCliente();
                    break;
                case 2:
                    AggiungiPolizza();
                    break;
                case 3:
                    Stampa();
                    break;
               
                default:
                    continua = false;
                    Console.WriteLine("Arrivederci");
                    break;
            }
            return continua;
        }
        private static void Stampa()
        {
            Console.WriteLine("Quale entità vuoi stampare?");
            Console.WriteLine("1. Clienti- 2. Polizze");
            int scelta = int.Parse(Console.ReadLine());
            if (scelta == 1)
            {
                var clienti = repoCliente.GetAll();
                StampaCollection<Cliente>(clienti);
            }
            else 
            {
                var polizze = repoPolizza.GetAll();
                StampaCollection<Polizza>(polizze);
            }
            
            }
        private static void StampaCollection<T>(ICollection<T> collection) where T : class
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("Lista vuota");
                return;
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
        private static void AggiungiCliente()
        {
            Console.Write("Codice Fiscale del Cliente: ");
            string codiceFiscale = Console.ReadLine();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci l'indirizzo: ");
            string indirizzo= Console.ReadLine();
            
                Cliente cliente = new Cliente()
                {
                    CodiceFiscaleID = codiceFiscale,
                    Nome = nome,
                    Cognome = cognome,
                    Indirizzo = indirizzo,
                    
                };
                repoCliente.Create(cliente);
                Console.WriteLine("Cliente aggiunto");
            }

        
        private static void AggiungiPolizza()
        {
            Polizza polizzaDaAggiungere = new Polizza();
            Console.WriteLine("Inserisci il Numero");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci DataStipula");
            DateTime dataStipula = DateTime.Parse(Console.ReadLine());
         
            Console.WriteLine("Inserisci l'importoAssicurato");

            float importoAssicurato;
            bool verificaImporto = float.TryParse(Console.ReadLine(), out importoAssicurato);
            while (!verificaImporto || importoAssicurato < 0)
            {
                verificaImporto = float.TryParse(Console.ReadLine(), out importoAssicurato);
            }
            var polizze = repoPolizza.GetAll();
            foreach (var item in polizze)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Inserire codice fiscale:");
            string codicefiscale = Console.ReadLine();
            Console.WriteLine("Che tipo di polizza vuoi inserire? 1-rc auto 2-vita 3-furto");
                int tipoPolizza;
               
                bool verifica = Int32.TryParse(Console.ReadLine(), out tipoPolizza);
                while (tipoPolizza > 4 || tipoPolizza < 0 || verifica == false)
                {
                    Console.WriteLine("Inserisci un valore corretto");
                    verifica = Int32.TryParse(Console.ReadLine(), out tipoPolizza);
                }

                if (tipoPolizza == 1)
                {
                    Console.WriteLine("Inserisci la Targa");
                    string targa = Console.ReadLine();
                    Console.WriteLine("Inserisci la cilindrata");
                int cilindrata = int.Parse(Console.ReadLine());
                    polizzaDaAggiungere = new RCauto()
                    {
                        Targa = targa,
                        Cilindrata = cilindrata,
                        CodiceFiscaleID = codicefiscale,
                        
                    };
                }
                else if (tipoPolizza == 2)
                {
                    Console.WriteLine("Inserisci Anni dell'Assicurato");
                    int anniDelAssicurato = int.Parse(Console.ReadLine());
                polizzaDaAggiungere = new Vita()
                    {
                        AnniDelAssicurato = anniDelAssicurato,
                        CodiceFiscaleID = codicefiscale,

                };
                } 
            else 
                    {
                Console.WriteLine("Inserisci la percentuale coperta");
                int percentualecoperta = int.Parse(Console.ReadLine());
                polizzaDaAggiungere = new Furto()
                {
                    PercentualeCoperta = percentualecoperta,
                    CodiceFiscaleID = codicefiscale,

                };

            }
                repoPolizza.Create(polizzaDaAggiungere);
                Console.WriteLine("Polizza aggiunta");
            }
        }
    }
   





   

