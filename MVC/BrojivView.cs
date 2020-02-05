using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.MVC
{
    public class BrojivView
    {
        public void PrikaziIzbornik()
        {
            IspisiPocetniBroj();
            Console.WriteLine("Izbornik rasporeda sati");
            IspisiPocetniBroj();
            Console.WriteLine("0. Promjena pogleda");
            IspisiPocetniBroj();
            Console.WriteLine("1. Ispis rasporeda sati (kompletan)");
            IspisiPocetniBroj();
            Console.WriteLine("2. Ispis emisija programa i dana (iteratorom)");
            IspisiPocetniBroj();
            Console.WriteLine("3. Ispis vrsta emisija");
            IspisiPocetniBroj();
            Console.WriteLine("4. Promjeni ulogu osobe");
            IspisiPocetniBroj();
            Console.WriteLine("5. Ispis prihoda po danu");
            IspisiPocetniBroj();
            Console.WriteLine("6. Brisanje emisije");
            IspisiPocetniBroj();
            Console.WriteLine("7. Vraćanje prethodnih verzija");
            IspisiPocetniBroj();
            Console.WriteLine("8. Sortiranje po IDu emisije ( samostalna funkcionalnost) ");
            IspisiPocetniBroj();
            Console.Write("ODABERITE: ");
        }

        public int OdabirPrograma()
        {
            var odabirPrograma = 0;
            IspisiPocetniBroj();
            Console.WriteLine("Unesite traženi program");
            odabirPrograma = int.Parse(Console.ReadLine()) - 1;
            return odabirPrograma;
        }

        public int OdabirDana()
        {
            var odabirDana = 0;
            IspisiPocetniBroj();
            Console.WriteLine("Unesite traženi dan ");
            odabirDana = int.Parse(Console.ReadLine()) - 1;
            return odabirDana;
        }

        public void IspisiEmisije(string emisija)
        {
            IspisiPocetniBroj();
            Console.WriteLine(emisija);

        }
        public static void IspisiPocetniBroj()
        {
            string ispis="["+
            String.Format("{0:00000}", Controller.brojacLinija)+"]";
            Controller.brojacLinija++;
            Console.Write(ispis);
           
        }
        public void IspisiDan(Dan dan)
        {
            IspisiPocetniBroj();
            Console.WriteLine("Raspored za " + dan);
        }
        public void IspisiVrsteHeader()
        {
            IspisiPocetniBroj();
            Console.WriteLine("Mogući tipovi su");
            
          
        }

        public void IspisVrste(string vrsta)
        {
            IspisiPocetniBroj();
            Console.WriteLine(vrsta);

        }
        public void IspisiImePrograma(string imePrograma)
        {
            IspisiPocetniBroj();
            Console.WriteLine(imePrograma);
        }
        public void IspisPromjeneUlogaHeader()
        {
            IspisiPocetniBroj();
            Console.WriteLine("PROMJENA ULOGE OSOBI");
            IspisiPocetniBroj();
            Console.WriteLine("Popis svih osoba i pripadnih uloga:");
        }

        public void IspisiSveOsobeUloge(string osobeUloge)
        {
            IspisiPocetniBroj();
            Console.WriteLine(osobeUloge);
        }
        public void IspisiOdabirOsobe()
        {
            IspisiPocetniBroj();
            Console.WriteLine("Odaberite ID osobe za promjenu:");
        }
        public void IspisOdabirStareUloge()
        {
            IspisiPocetniBroj();
            Console.WriteLine("Odaberite ulogu za promjenu");
        }

        public void IspisOdabirNoveUloge()
        {
            IspisiPocetniBroj();
            Console.WriteLine("Odaberite novu ulogu");
        }

        public void OdabirProgramaPrihod()
        {
            IspisiPocetniBroj();
            Console.WriteLine("Unesite traženi program");
        }

        public void OdabirDanaPrihod()
        {
            
            IspisiPocetniBroj();
            Console.WriteLine("Unesite traženi dan ");
            
        }
        public static void IspisiEmisijePrihoda(string prihodi)
        {
            IspisiPocetniBroj();
            Console.WriteLine(prihodi);
        }
        public static void IspisiPrihodEmisije(string prihodi)
        {
            IspisiPocetniBroj();
            Console.WriteLine(prihodi);
        }
        public  void IspisOdabiraIDEmisije()
        {
            IspisiPocetniBroj();
            Console.WriteLine("Unesite traženi id emisije");
        }
        public void IspisPrethodnihVerzijaHeader()
        {
            IspisiPocetniBroj();
            Console.WriteLine("Popis prethodnih verzija");
        }
        public void IspisPrethodnihVerzijaFooter()
        {
            IspisiPocetniBroj();
            Console.WriteLine("Odaberite ID prethodne verzije");
        }
        public void IspisPrethodnihVerzija(string prethodna)
        {
            IspisiPocetniBroj();
            Console.WriteLine(prethodna);
        }
    }
}
