using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAStar
{
    public class Grid
    {
        public int wymiar;
        public Wezel[,] wezly;

        public Grid(int wymiar)
        {
            this.wymiar = wymiar;
            wezly = stworzWezly(wymiar);
        }

        public Wezel[,] stworzWezly(int wymiar)
        {
            Wezel[,] wezly = new Wezel[wymiar, wymiar];
            for (int i = 0; i < wymiar; ++i)
            {
                for (int j = 0; j < wymiar; ++j)
                {
                    wezly[i, j] = new Wezel(j, i);
                }
            }

            return wezly;
        }

        public Wezel getWezel(int x, int y)
        {
            return this.wezly[y, x];
        }

        public bool jestOdblokowane(int x, int y)
        {
            return jestWSrodku(x, y) && wezly[y, x].odblokowane;
        }

        public bool jestWSrodku(int x, int y)
        {
            return (x >= 0 && x < wymiar) && (y >= 0 && y < wymiar);
        }

        public void ustawOdblokowane(int x, int y, bool odblokowane)
        {
            wezly[y, x].odblokowane = odblokowane;
        }

        public Wezel[] pobierzSasiadow(Wezel Wezel)
        {
            int x = Wezel.x;
            int y = Wezel.y;

            List<Wezel> listaSasiadow = new List<Wezel>();
            Wezel[,] wezly = this.wezly;

            // ↑
            if (this.jestOdblokowane(x, y - 1))
            {
                listaSasiadow.Add(wezly[y - 1, x]);
            }
            // →
            if (this.jestOdblokowane(x + 1, y))
            {
                listaSasiadow.Add(wezly[y, x + 1]);
            }
            // ↓
            if (this.jestOdblokowane(x, y + 1))
            {
                listaSasiadow.Add(wezly[y + 1, x]);
            }
            // ←
            if (this.jestOdblokowane(x - 1, y))
            {
                listaSasiadow.Add(wezly[y, x - 1]);
            }

            int ilosc = listaSasiadow.Count;
            Wezel[] sasiedzi = new Wezel[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                sasiedzi[i] = listaSasiadow.ElementAt(i);
            }

            return sasiedzi;
        }

        public Grid kopiuj()
        {

            int wymiar = this.wymiar;
            Wezel[,] stareWezly = this.wezly;

            Grid nowyGrid = new Grid(wymiar);
            Wezel[,] noweWezly = new Wezel[wymiar, wymiar];

            for (int i = 0; i < wymiar; ++i)
            {
                for (int j = 0; j < wymiar; ++j)
                {
                    noweWezly[i, j] = new Wezel(j, i, stareWezly[i, j].odblokowane);
                }
            }

            nowyGrid.wezly = noweWezly;

            return nowyGrid;
        }

        public void wypisz()
        {
            for (int i = 0; i < this.wymiar; ++i)
            {
                for (int j = 0; j < this.wymiar; ++j)
                {
                    Console.WriteLine(this.wezly[i, j].x + " " + this.wezly[i, j].y + " " + this.wezly[i, j].odblokowane);
                }
            }
        }
    }

}
