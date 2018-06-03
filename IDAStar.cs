using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IDAStar
{
    public class IDAStar
    {
        public Heurystyka heurystyka;
        public string wybranaHeurystyka;
        public Wezel start;
        public Wezel koniec;
        public int wezlyOdwiedzone;
        public Labirynt labirynt;
        public List<Wezel> sciezka = new List<Wezel>();
        public double kosztAkcji;
        public event EventHandler zglosZdarzenie;
        public List<Wezel> testowane = new List<Wezel>();
        public int opoznienie,iloscPowodzen,iloscNiepowodzen,lacznaDlugoscSciezki;
        public bool uplynalCzasWykonywania = false;
        public DateTime czasKoncowy;
        public int maxCzasWykonania;

        public IDAStar(int startX, int startY, int koniecX, int koniecY, Labirynt labirynt, string wybranaHeurystyka, double kosztAkcji = 1.0, int opoznienie = 0)
        {
            this.opoznienie = opoznienie;
            this.kosztAkcji = kosztAkcji;
            heurystyka = new Heurystyka();
            this.wybranaHeurystyka = wybranaHeurystyka;
            start = labirynt.getWezel(startX, startY);
            koniec = labirynt.getWezel(koniecX, koniecY);
            this.labirynt = labirynt;
            wezlyOdwiedzone = 0;
            iloscPowodzen = 0;
            iloscNiepowodzen = 0;
            lacznaDlugoscSciezki = 0;
            maxCzasWykonania = 0;
        }

        public double obliczHeurystyke(Wezel a, Wezel b)
        {
            switch (wybranaHeurystyka)
            {
                case "euclidean":
                    return heurystyka.euclidean(Math.Abs(b.x - a.x), Math.Abs(b.y - a.y));
                case "chebyshev":
                    return heurystyka.chebyshev(Math.Abs(b.x - a.x), Math.Abs(b.y - a.y));
                default:
                    return heurystyka.manhattan(Math.Abs(b.x - a.x), Math.Abs(b.y - a.y));
            }
        }

        public double obliczKoszt(Wezel a, Wezel b)
        {
            return (a.x == b.x || a.y == b.y) ? 1.0 : Math.Sqrt(2.0);
        }

        public Object szukaj(Wezel wezel, double g, double maxGlebokosc, int glebokosc)
        {
            if (maxCzasWykonania != 0 && DateTime.Compare(DateTime.Now, czasKoncowy) > 0)
            {
                uplynalCzasWykonywania = true;
                return new List<Wezel>();
            }

            wezlyOdwiedzone++;

            double f = g + obliczHeurystyke(wezel, koniec) * kosztAkcji;

            if (wezel.x == koniec.x && wezel.y == koniec.y)
            {
                sciezka.Add(new Wezel(wezel.x, wezel.y));
                //lacznaDlugoscSciezki += sciezka.Count;
                iloscPowodzen++;
                return wezel;
            }

            if (f > maxGlebokosc)
            {
                iloscNiepowodzen++;
                return f;
            }

            double min = Double.PositiveInfinity;
            Object t;
            Wezel sasiad;

            Wezel[] sasiedzi = labirynt.pobierzSasiadow(wezel);

            for (int k = 0; k < sasiedzi.Length; ++k)
            {
                sasiad = sasiedzi[k];
                testowane.Add(sasiad);
                lacznaDlugoscSciezki += testowane.Count;

                if (opoznienie > 0)
                {
                    zglosZdarzenie(testowane, null);
                    Thread.Sleep(opoznienie);
                }
                
                t = szukaj(sasiad, g + obliczKoszt(wezel, sasiad), maxGlebokosc, glebokosc + 1);

                try // Wezel
                {
                    Wezel test = (Wezel)t;
                    sciezka.Add(new Wezel(sasiad.x, sasiad.y));
                    //lacznaDlugoscSciezki += sciezka.Count;
                    iloscPowodzen++;
                    return test;
                }
                catch (Exception exc) // Double
                {
                    try
                    {
                        iloscNiepowodzen++;
                        testowane.Remove(sasiad);
                        lacznaDlugoscSciezki += testowane.Count;
                        if (opoznienie > 0)
                        {
                            zglosZdarzenie(testowane, null);
                            Thread.Sleep(opoznienie);
                        }
                        double x = (Double)t;
                        if (x < min)
                        {
                            min = x;
                        }
                    }
                    catch(Exception ex){ // nic z powyzszych
                    }
                }
            }
            return min;
        }

        public List<Wezel> szukajSciezki(int startX, int startY, int koniecX, int koniecY, Labirynt labirynt, int maxCzasWykonywania = 0)
        {
            maxCzasWykonania = maxCzasWykonywania;

            if (maxCzasWykonania != 0)
            {
                czasKoncowy = DateTime.Now.AddSeconds(maxCzasWykonywania);
            }
            
            double maxGlebokosc = obliczHeurystyke(start, koniec) * kosztAkcji;

            Object t;

            for (;;)
            {
                // przekroczono max czas wykonania - 30sek
                if(maxCzasWykonania != 0 && DateTime.Compare(DateTime.Now,czasKoncowy) > 0)
                {
                    uplynalCzasWykonywania = true;
                    return new List<Wezel>();
                }

                sciezka.Clear();

                t = szukaj(start, 0, maxGlebokosc, 0);

                try // Double
                {
                    double doub = (Double)t;
                    
                    if (Double.IsPositiveInfinity(doub))
                    {
                        sciezka.Clear();
                        iloscNiepowodzen++;
                        return new List<Wezel>();
                    }
                    else
                    {
                        double d = (Double)t;
                        maxGlebokosc = d;
                    }
                }
                catch (Exception e) // Wezel
                {
                    try
                    {
                        Wezel x = (Wezel)t;
                        iloscPowodzen++;
                        return sciezka;
                    }
                    catch (Exception exc) // nic z powyzszych
                    {
                        return new List<Wezel>();
                    }
                }
            }
        }
    }
}