using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    /// X-Y representan la localización de los puntos
    class Puntos
    {
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }

        // Constructor
        // Cordenada X del punto
        // Cordenada Y del punto
        public Puntos(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
