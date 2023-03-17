using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligon2022_3_9B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            poligon P1=null;
            int izbor = 1;
            while (izbor > 0)
            {
                Console.WriteLine("Unesite :");
                Console.WriteLine("1: Unos");
                Console.WriteLine("2: Snimi");
                Console.WriteLine("3: Ucitaj");
                Console.WriteLine("4: Stampa");
                Console.WriteLine("5: Prost");
                Console.WriteLine("6: Povrsina");
                Console.WriteLine("7: Konveksan");
                Console.WriteLine("8: Tacka unutra");
                Console.WriteLine("9: Proba");
                Console.WriteLine("10: Omotac");
                Console.WriteLine("11: Omotac 2");
                Console.WriteLine("0: Kraj");
                Console.WriteLine("Vas izbor je:");
                izbor = Convert.ToInt32(Console.ReadLine());
                switch (izbor)
                {
                    case 0:
                        break;
                    case 1:
                        P1 = poligon.unos();
                        break;
                    case 2:
                        P1.snimi();
                        break;
                    case 3:
                        P1=poligon.ucitaj();
                        break;
                    case 4:
                        P1.stampa();
                        break;
                    case 5:
                        Console.WriteLine("Prost={0}", P1.prost());
                        break;
                    case 6:
                        Console.WriteLine("Povrsina={0}", P1.povrsina());
                        break;
                    case 7:
                        Console.WriteLine("Konveksan={0}", P1.konveksan());
                        break;
                    case 8:
                        Console.WriteLine("X koordinata tacke=");
                        double x_T = Convert.ToDouble(Console.ReadLine());
                        double y_T = Convert.ToDouble(Console.ReadLine());
                        tacka T = new tacka(x_T, y_T);
                        Console.WriteLine("Pripada={0}", P1.TuP(T));
                        break;
                    case 9:
                        tacka a = new tacka(1, 3);
                        tacka b = new tacka(3, 0);
                        tacka c = new tacka(1, 1);
                        tacka d = new tacka(0, 0);
                        vektor ab = new vektor(a, b);
                        vektor cd = new vektor(c, d);
                        Console.WriteLine("Presek = {0}", ravan.seku_se(ab, cd));
                        break;
                    case 10:
                        P1.omotac();
                        break;
                    case 11:
                        P1.hull2();
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
