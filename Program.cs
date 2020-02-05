using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.MVC;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var provjera=Izbornik.UcitajDatoteke(args);
            if (provjera)
            {
                Controller c= new Controller();
               // Izbornik.OdabirOpcija();
                
            }

            Console.Read();

        }
        //TODO
        //1. Dodaj vlastitu funkcionalnost sa Chainom
        //2. MVC; 2 pogleda; pogled 1 originalni; pogled 2 ispisuje na pocetku linije 00001++
        //3. Visitor za izračun broja minuta reklama                                                DONE 1h+2h
        //4. obrisati emisiju prema njegovom jednoznacom broju                                      DONE 1h
        //5. Ispisati broj pohranjivanja podataka (Memento)                                         DONE 3H
        //6. Vratiti stanje stvari na pocetno (Memento)                                             DONE 4h
        //7. Izvršiti vlastitu funkcionalnost
        //8. Promjeniti pogled
        //9. 

    }
}
