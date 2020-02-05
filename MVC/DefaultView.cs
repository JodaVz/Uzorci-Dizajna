using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.MVC
{
    public class DefaultView
    {
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik rasporeda sati");
            Console.WriteLine("0. Promjena pogleda");
            Console.WriteLine("1. Ispis rasporeda sati (kompletan)");
            Console.WriteLine("2. Ispis emisija programa i dana (iteratorom)");
            Console.WriteLine("3. Ispis vrsta emisija");
            Console.WriteLine("4. Promjeni ulogu osobe");
            Console.WriteLine("5. Ispis prihoda po danu");
            Console.WriteLine("6. Brisanje emisije");
            Console.WriteLine("7. Vraćanje prethodnih verzija");
            Console.WriteLine("8. Sortiranje po IDu emisije ( samostalna funkcionalnost) ");
            Console.Write("ODABERITE: ");
        }

        public int OdabirPrograma()
        {
            var odabirPrograma = 0;
            Console.WriteLine("Unesite traženi program");
            odabirPrograma = int.Parse(Console.ReadLine()) - 1;
            return odabirPrograma;
        }

        public int OdabirDana()
        {
            var odabirDana = 0;
            Console.WriteLine("Unesite traženi dan ");
            odabirDana = int.Parse(Console.ReadLine()) - 1;
            return odabirDana;
        }

        public void IspisiEmisije(string emisija)
        {
            Console.WriteLine(emisija);

        }

        public void IspisiDan(Dan dan)
        {
            Console.WriteLine("Raspored za " + dan);
        }

        public void IspisiVrsteHeader()
        {
            Console.WriteLine("Mogući tipovi su");
            
        }

        public void IspisVrste(string vrsta)
        {
            Console.WriteLine(vrsta);

        }

        public void IspisiImePrograma(string imePrograma)
        {
            Console.WriteLine(imePrograma);

        }

        public void IspisPromjeneUlogaHeader()
        {
            Console.WriteLine("PROMJENA ULOGE OSOBI");
            Console.WriteLine("Popis svih osoba i pripadnih uloga:");
        }

        public void IspisiSveOsobeUloge(string osobeUloge)
        {
            Console.WriteLine(osobeUloge);
        }

        public void IspisiOdabirOsobe()
        {
            Console.WriteLine("Odaberite ID osobe za promjenu:");
        }

        public void IspisOdabirStareUloge()
        {
            Console.WriteLine("Odaberite ulogu za promjenu");
        }

        public void IspisOdabirNoveUloge()
        {
            Console.WriteLine("Odaberite novu ulogu");
        }
        public void OdabirProgramaPrihod()
        {
           
            Console.WriteLine("Unesite traženi program");
        }

        public void OdabirDanaPrihod()
        {
            Console.WriteLine("Unesite traženi dan ");

        }

        public static void IspisiEmisijePrihoda(string prihodi)
        {
            Console.WriteLine(prihodi);
        }
        public static void IspisiPrihodEmisije(string prihodi)
        {
            Console.WriteLine(prihodi);
        }

        public  void IspisOdabiraIDEmisije()
        {
            Console.WriteLine("Unesite traženi id emisije");
        }

        public void IspisPrethodnihVerzijaHeader()
        {
            Console.WriteLine("Popis prethodnih verzija");
        }
        public void IspisPrethodnihVerzijaFooter()
        {
            Console.WriteLine("Odaberite ID prethodne verzije");
        }
        public void IspisPrethodnihVerzija(string prethodna)
        {
            Console.WriteLine(prethodna);
        }
    }
}
