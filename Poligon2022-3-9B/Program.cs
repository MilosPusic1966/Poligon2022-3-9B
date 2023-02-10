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
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
