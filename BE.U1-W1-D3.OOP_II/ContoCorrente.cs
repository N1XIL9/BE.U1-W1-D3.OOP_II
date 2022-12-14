using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BE.U1_W1_D3.OOP_II
{
    internal class ContoCorrente

        // PROPRIETA'
    {
        private string _correntista;

        public string Correntista
        {
            get { return _correntista;}
            set { _correntista = value; }
        }

        private double _saldo;

        public double Saldo 
        {
            get { return _saldo; }
            set { _saldo = 0; }
        }

        private bool _contoAperto ;

        public bool ContoAperto
        {
            get { return _contoAperto; }
            set { _contoAperto = false; }
        }


        // METODI


        public void menuIniziale()
        {
            // INIZIO MENU

            Console.WriteLine("");
            Console.WriteLine("===========================================");
            Console.WriteLine("===== B A N CA  C E N T R A L E  U E ======");
            Console.WriteLine("===========================================");
            Console.WriteLine("");


            Console.WriteLine("");
            Console.WriteLine("============ B E N V E N U TO =============");
            Console.WriteLine("");
            Console.WriteLine("SCEGLI UN OPZIONE :");
            Console.WriteLine("");
            Console.WriteLine("1. APRI UN CONTO CORRENTE");
            Console.WriteLine("2. FAI UN PRELIEVO");
            Console.WriteLine("3. FAI UN VERSAMENTO");
            Console.WriteLine("4. ESCI");

            Console.WriteLine("");

            // DICHIARARE VARIABILE PER POTER FARE LA SCELTA 
            int scelta = int.Parse(Console.ReadLine());

            // CON UN COSTRUTTO IF - ESLE
            if (scelta == 1)
            {
                apriConto();
            }
            else if (scelta == 2)
            {
                prelievo();
            }
            else if (scelta == 3)
            {
                versamento();
            }else if (scelta == 4)
            {
                close();
            }
            else
            {
                Console.WriteLine("HAI SELEZIONATO UNA VOCE NON VALIDA");
                menuIniziale();
            }
        }
            // FINE MENU
    
        public void apriConto()
        {
            Console.WriteLine("");
            Console.WriteLine("Inserisci Nome e Cognome");
            string Correntista = Console.ReadLine();
            Console.WriteLine("Fai un versamento di almeno euro 1000,00.");
            Console.WriteLine("Importo da versare:");
            double importo = double.Parse(Console.ReadLine());
            while (importo < 1000) 
            {
                Console.WriteLine("ATTENZIONE! HAI INSERITO UN IMPORTO INFERIORE A ERUO 1000,00");

                Console.WriteLine("Importo da versare:");
                importo = double.Parse(Console.ReadLine());
            }
            
                _saldo = importo;

                Console.WriteLine("OPERAZIONE AVVENUTA CON SUCCESSO");
                Console.WriteLine($" Conto corrente di {Correntista}");
                Console.WriteLine($" Saldo euro: {Saldo}");
                _contoAperto = true;
                menuIniziale(); 
        }

        public void versamento()
        {
            Console.WriteLine("");
            if (_contoAperto == true)
            {
            Console.WriteLine("INSERISCI L'IMPORTO DA VERSARE");
            double importoVersamento = double.Parse(Console.ReadLine());
                
            _saldo += importoVersamento;
                Console.WriteLine($"IL TUO SALDO AGGIORNATO E' DI EURO: {Saldo}");
                menuIniziale();

              
            }else { Console.WriteLine("ATTENZIONE, DEVI PRIMA APRIRE UN NUOVO CONTO");
                menuIniziale();
            };
            Console.WriteLine("");


        }

        public void prelievo()
        {
            Console.WriteLine("");
            if (_contoAperto == true)
            {
                Console.WriteLine("INSERISCI L'IMPORTO DA PRELEVARE");
                double importoPrelievo = double.Parse(Console.ReadLine());
                if(importoPrelievo >= _saldo)
                {
                    Console.WriteLine($"ATTENZIONE! OPERAZIONE NON VALIDA.IL TUO SALDO E' DI EURO: {_saldo} ");
                    prelievo();
                } else
                {

                _saldo -= importoPrelievo;
                Console.WriteLine($"IL TUO SALDO AGGIORNATO E' DI EURO: {Saldo}");
                    menuIniziale();
                }
                
            }
            else
            {
                Console.WriteLine("APRI IL CONTO");
                menuIniziale();
            };
            Console.WriteLine("");
        }

        // PER CHIUDERE L'APPLICAZIONE
        public void close()
        {
            Console.WriteLine("========= A R R I V E D E R C I ========");
            Thread.Sleep(6000);

            Environment.Exit(0);
        }
    }
  
}




