using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAStar
{
    public class Wezel
    {
        public int x;
        public int y;
        public bool odblokowane;
        public double t = Double.MaxValue;
        public double f;

        public Wezel(int x, int y, bool odblokowane = true)
        {
            this.x = x;
            this.y = y;
            this.odblokowane = odblokowane;
        }
    }

}
