using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligon2022_3_9B
{
    internal class tacka
    {
        public double x, y;
        public tacka(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public tacka() { }
        public double getX() { return x; }
        public double getY() { return y; }
        public void setX(double x) { this.x = x;} 
        public void setY(double y) { this.y = y; }
        public double r(tacka a)
        {
            return Math.Sqrt(x*x+y*y);
        }
        public double ugao(tacka a)
        {
            return Math.Atan2(y, x);
        }
        public tacka (tacka a, tacka b)
        {
            this.x = b.x - a.x;
            this.y = b.y - a.y;
        }
    }
}
