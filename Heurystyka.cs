using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAStar
{
    public class Heurystyka
    {
        public Heurystyka()
        {
        }

        public double manhattan(double x, double y)
        {
            return x + y;
        }

        public double euclidean(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        public double chebyshev(double x, double y)
        {
            return Math.Max(x, y);
        }

    }
}
