using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligon2022_3_9B
{
    internal class vektor
    {
        // MORA POCETAK I KRAJ, INACE NE ZNAMO DA LI SE SEKU!!
        public tacka a, b;
        public vektor(tacka a, tacka b) 
        { 
            this.a = new tacka(a, b);
        }
        public vektor(tacka a)
        {
            this.a = a;
        }
        public void stampaj()
        {
            Console.WriteLine("vektor: x={0} y={1}", a.x, a.y); 
        }
        public double ugao(vektor a, vektor b)
        {
            return 0;
        }

    }
}
