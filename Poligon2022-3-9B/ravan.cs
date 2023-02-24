using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;

namespace Poligon2022_3_9B
{
    internal class ravan
    {
        public static double VP(vektor prvi, vektor drugi) {
            double part1 = (prvi.b.x - prvi.a.x) * (drugi.b.y - drugi.a.y);
            double part2 = (drugi.b.x - drugi.a.x) * (prvi.b.y -prvi.a.y);
            return part1 - part2;
        }
        public static int SIS(tacka a, tacka b, tacka c, tacka d)
        {
            vektor prvi = new vektor(a, b);
            vektor drugi = new vektor(a, c);
            double VP1 = VP(prvi, drugi);

            vektor treci = new vektor(a, d);
            double VP2 = VP(prvi, treci);
            if (VP1 * VP2 == 0) return 1;
            if (VP1 * VP2 > 0) return 0;
            return -1;
            // vraca 0 "sa iste strane cd"
            // vraca 1 "jedna tacka lezi na vektoru cd"
            // vraca -1 "sa raznih strana cd"
        }
        public static bool seku_se(vektor x, vektor y)
        {
            // ako je SIS (x.a, x.b, y.a, y.b) * SIS (y.a, y.b, x.a, x.b) = 0 -> ne seku se
            if (SIS(x.a, x.b, y.a, y.b) * SIS(y.a, y.b, x.a, x.b) == 0) return false;
            else return true;
        }
    }
}
