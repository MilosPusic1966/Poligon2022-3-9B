using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;

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
        public bool TuP(tacka T)
        {
            double max_x = teme[0].x;
            for (int i = 1; i < broj_temena; i++)
            {
                if (teme[i].x > max_x) max_x = teme[i].x;
            }
            tacka K = new tacka(max_x + 1, T.y);
            vektor TK = new vektor(T, K);
            int broj_preseka = 0;
            for (int i = 0; i < broj_temena; i++)
            {
                vektor test = new vektor(teme[i], teme[(i + 1) % broj_temena]);
                if (ravan.seku_se(TK, test)) broj_preseka++;
                if (ravan.pripada_spec(TK, teme[(i+1) % broj_temena]))
                {
                    if (ravan.SIS(teme[i], teme[(i + 2) % broj_temena], T, K) == -1) broj_preseka++;
                }
                Console.WriteLine("presek={0}", broj_preseka);
            }
            if (broj_preseka % 2 == 0) return false;
            return true;
        }
        public poligon omotac() {
            if (this.konveksan()) return this;
            double min_x, min_y;
            min_x = teme[0].x;
            min_y = teme[0].y;
            int indeks = 0;
            for (int i = 1; i < broj_temena; i++)
            {
                if (teme[i].x < min_x)
                {
                    min_x = teme[i].x;
                    min_y = teme[i].y;
                    indeks = i;
                }
                else
                {
                    if (teme[i].x==min_x)
                    {
                        if (teme[i].y < min_y)
                        {
                            min_y= teme[i].y;
                            indeks = i;
                        }
                    }
                }
            }
            Console.WriteLine("Pobedio = {0}", indeks);
            List<tacka> hull = new List<tacka>();
            hull.Add(teme[indeks]);
            int indeks2 = 0;
            double min_ugao = 180;
            for (int i = 1; i < broj_temena; i++)
            {
                double temp_x = teme[(indeks+i) % broj_temena].x-teme[indeks].x;
                double temp_y = teme[(indeks + i) % broj_temena].y - teme[indeks].y;
                double temp_ugao = Math.Atan2(temp_y, temp_x);
                if (temp_ugao < min_ugao)
                {
                    min_ugao = temp_ugao;
                    indeks2 = i;
                }
            }
            hull.Add(teme[indeks2]);
            Console.WriteLine("Dodata {0}", indeks2);
            while (indeks2 != indeks)
            {
                min_ugao = 180;
                int indeks3 = 0;
                tacka poc = teme[indeks2];
                for (int brojac = indeks2+1; brojac<indeks2+broj_temena ; brojac++)
                {
                    tacka kraj = teme[brojac % broj_temena];
                    double temp_x = kraj.x - poc.x;
                    double temp_y = kraj.y - poc.y;
                    double temp_ugao = Math.Atan2(temp_y, temp_x);
                    if (temp_ugao<min_ugao)
                    {
                        min_ugao = temp_ugao;
                        indeks3 = brojac % broj_temena;
                    }
                }
                // OVDE NEGDE JE PROBLEM!!!
                Console.WriteLine("Dodajem: {0}", indeks3);
                hull.Add(teme[indeks3]);
                indeks2 = indeks3;
            }
            for (int i = 0; i < hull.Count; i++)
            {
                Console.WriteLine("teme {0}, {1}", hull[i].x, hull[i].y);
            }
            return null; 
        }
    }
}
