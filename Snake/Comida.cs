using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    // Representa cada comida, clase derivada de 'ParteJuego'

    class Comida : ParteJuego
    {
       
        // Coordenada X del punto de la comida
        // Coordenada Y del punto de la comida
        public Comida(int X, int Y) : base(X, Y)
        {

        }
    }
}
