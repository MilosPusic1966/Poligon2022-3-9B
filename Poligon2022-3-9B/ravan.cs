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
        public static int VP(vektor a, vektor b) { return 0; }
        public static int SIS(tacka a, tacka b, tacka c, tacka d)
        {
            // vraca 0 "sa iste strane cd"
            // vraca 1 "jedna tacka lezi na vektoru cd"
            // vraca -1 "sa raznih strana cd"
            return 0;
        }
        public static int seku_se(vektor x, vektor y)
        {
            // ako je SIS (x.a, x.b, y.a, y.b) * SIS (y.a, y.b, x.a, x.b) = 0 -> ne seku se
            return 0;
        }
    }
}
