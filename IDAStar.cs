using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAStar
{
    public class IDAStar
    {
        public Heurystyka heurystyka;
        public Wezel start;
        public Wezel koniec;
        public int wezlyOdwiedzone;
        public Labirynt labirynt;
        public List<Wezel> sciezka = new List<Wezel>();

        public IDAStar(int startX, int startY, int koniecX, int koniecY, Labirynt labirynt, Heurystyka heur)
        {
            heurystyka = heur;
            start = labirynt.getWezel(startX, startY);
            koniec = labirynt.getWezel(koniecX, koniecY);
            this.labirynt = labirynt;
            wezlyOdwiedzone = 0;
        }

        public double obliczHeurystyke(Wezel a, Wezel b)
        {
            return heurystyka.manhattan(Math.Abs(b.x - a.x), Math.Abs(b.y - a.y));
            //if(){

            //}
        }

        public double obliczKoszt(Wezel a, Wezel b)
        {
            //Console.WriteLine(a.x + " " + a.y + "||" + b.x + " " + b.y);
            return (a.x == b.x || a.y == b.y) ? 1.0 : Math.Sqrt(2.0);
        }

        public Object szukaj(Wezel wezel, double g, double maxGlebokosc, int glebokosc)
        {
            wezlyOdwiedzone++;
            // Console.WriteLine(wezel.x + " " + wezel.y);
            double f = g + obliczHeurystyke(wezel, koniec);

            if (f > maxGlebokosc)
            {
                return (Double)f;
            }

            if (wezel.x == koniec.x && wezel.y == koniec.y)
            {
                //Console.WriteLine(wezel.x + " " + wezel.y); 
                sciezka.Add(new Wezel(wezel.x, wezel.y));
                return wezel;
            }
            
            double min = Double.MaxValue;
            Object t;
            Wezel sasiad;

            Wezel[] sasiedzi = labirynt.pobierzSasiadow(wezel);

            for (int k = 0; k < sasiedzi.Length; ++k)
            {
                sasiad = sasiedzi[k];
                //Console.WriteLine(sasiad.x + " " + sasiad.y);
                t = szukaj(sasiad, g + obliczKoszt(wezel, sasiad), maxGlebokosc, glebokosc + 1);

                try
                {
                    Wezel test = (Wezel)t;
                    //Console.WriteLine(sasiad.x + " " + sasiad.y);
                    this.sciezka.Add(new Wezel(sasiad.x, sasiad.y));
                    return test;
                }
                catch (Exception exc)
                {
                    //Console.WriteLine("Wezel w szukaj");
                    //Console.WriteLine(exc.ToString());
                    try
                    {
                        double x = (Double)t;
                        //Console.WriteLine(x);
                        if (x < min)
                        {
                            min = x;
                        }
                    }
                    catch (Exception excep)
                    {
                        Console.WriteLine("double w szukaj");
                        Console.WriteLine(excep.ToString());
                    }
                }
            }

            return min;
        }

        public List<Wezel> szukajSciezki(int startX, int startY, int koniecX, int koniecY, Labirynt labirynt)
        {
            //this.wezlyOdwiedzone = 0;
            //this.start = new Wezel(startX,startY);
            //this.koniec = new Wezel(koniecX,koniecY);

            double maxGlebokosc = obliczHeurystyke(start, koniec);

            Object t;

            for (int j = 0; true; j++)
            {
                //sciezka = sciezka.cl
                //Array.Clear(sciezka, 0, sciezka.GetLength(0)*sciezka.GetLength(1));
                sciezka.Clear();
                t = szukaj(start, 0, maxGlebokosc, 0);
                //Console.WriteLine("hehe");
                // try catch na sprawdzenie czy nie ma infinity i zwrocenie pustej listy
                try
                {
                    double doub = (Double)t;
                    if (doub.Equals(Double.MaxValue))
                    {
                        sciezka.Clear();
                        return new List<Wezel>();
                    }
                    else
                    {
                        double d = (Double)t;
                        maxGlebokosc = d;
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        Wezel x = (Wezel)t;
                        return sciezka;
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("Wezel w find");
                        Console.WriteLine(exc.ToString());
                        /*try
                        {
                            double d = (Double)t;
                            maxGlebokosc = d;
                        }
                        catch (Exception excep)
                        {
                            Console.WriteLine("double w find");
                            Console.WriteLine(excep.ToString());
                        }*/
                    }
                }
            }
        }
    }

}
