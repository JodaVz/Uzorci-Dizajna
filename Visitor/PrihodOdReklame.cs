using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite_Raspored;
using marvertus_zadaca_3.MVC;

namespace marvertus_zadaca_3.Visitor
{
    public class PrihodOdReklame:IVisitor
    {
        private static int suma = 0;
        public void Visit(Element element)
        {
            EmisijaRasporeda emisija = element as EmisijaRasporeda;
            if (emisija.VrstaEmisije.MaksTrajanjeReklame >= 1)
            {
                if (Controller.trenutniPogled == 2)
                {
                    BrojivView.IspisiPocetniBroj();
                }
                emisija.Ispisi();
                suma = emisija.VrstaEmisije.MaksTrajanjeReklame + suma;
                if (Controller.trenutniPogled == 2)
                {
                    BrojivView.IspisiPrihodEmisije("Prihodi od emisija: " + suma);
                }

                if (Controller.trenutniPogled==1)
                {
                    DefaultView.IspisiPrihodEmisije("Prihodi od emisija: " + suma);
                }
            }

        }

        public static void ResetirajSumu()
        {
            suma = 0;
        }

    }
}
