using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Poligon2022_3_9B
{
    internal class poligon
    {
        int broj_temena;
        tacka[] teme;
        public poligon(int n)
        {
            broj_temena = n;
            teme = new tacka[n];
            for (int i = 0; i < n; i++)
            {
                teme[i] = new tacka();
            }
        }
        public poligon() { }
        public static poligon unos()
        {
            Console.WriteLine("Unesite broj temena");
            int n = Convert.ToInt32(Console.ReadLine());
            poligon novi = new poligon(n);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("unesite x za teme T({0})=", i + 1);
                novi.teme[i].x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("unesite y za teme T({0})=", i + 1);
                novi.teme[i].y = Convert.ToDouble(Console.ReadLine());
            }
            return novi;
        }
        public void stampa()
        {
            Console.WriteLine("Poligon sa {0} temena:", broj_temena);
            for (int i = 0; i < broj_temena; i++)
            {
                Console.WriteLine("Teme {0}=({1}, {2})", i, teme[i].x, teme[i].y);
            }
        }
        public void snimi()
        {
            StreamWriter izlaz = new StreamWriter("poligon.txt");
            izlaz.WriteLine(broj_temena);
            for (int i = 0; i < broj_temena; i++)
            {
                izlaz.WriteLine(teme[i].x);
                izlaz.WriteLine(teme[i].y);
            }
            izlaz.Close();
            izlaz.Dispose();
        }
        public void snimi(string putanja)
        {

        }
        public static poligon ucitaj()
        {
            StreamReader ulaz = new StreamReader("poligon.txt");
            int n = Convert.ToInt32(ulaz.ReadLine());
            poligon novi = new poligon(n);
            for (int i = 0; i < n; i++)
            {
                novi.teme[i].x = Convert.ToDouble(ulaz.ReadLine());
                novi.teme[i].y = Convert.ToDouble(ulaz.ReadLine());
            }
            return novi;
        }
        public bool prost()
        {
            for (int i = 0; i < broj_temena - 1; i++)
            {
                for (int j = i + 1; j < broj_temena; j++)
                {
                    if (tacka.jednake(teme[i], teme[j]))
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < broj_temena - 2; i++)
            {
                vektor prvi = new vektor(teme[i], teme[i + 1]);
                for (int j = i + 2; j < broj_temena; j++)
                {
                    if (i == 0 && (j == (broj_temena - 1))) continue;
                    vektor drugi = new vektor(teme[j], teme[(j + 1) % broj_temena]);
                    if (ravan.seku_se(prvi, drugi)) return false;
                }
            }
            return true;
        }
        public double povrsina() {
            if (prost() == false)
            {
                Console.WriteLine("Poligon nije prost!");
                return 0;
            }
            double plus = 0;
            double minus = 0;
            for (int i = 0; i < broj_temena; i++)
            {
                plus += teme[i].x * teme[(i + 1) % broj_temena].y;
                minus += teme[(i + 1) % broj_temena].x * teme[i].y;
            }
            double povrsina = Math.Abs(plus - minus) / 2;
            return povrsina;
        }
        public bool konveksan() {
            int T = 0;
            for (int i = 0; i < broj_temena; i++)
            {
                vektor prvi = new vektor(teme[i], teme[(i + 1) % broj_temena]);
                vektor drugi = new vektor(teme[(i + 1) % broj_temena], teme[(i + 2) % broj_temena]);
                double proizv = ravan.VP(prvi, drugi);
                if (proizv > 0) T++;
            }
            if (T == broj_temena || T == 0) return true;
            return false; 
        }  
        public poligon omotac() { return null; }
    }
}
