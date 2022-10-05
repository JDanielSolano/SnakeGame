using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake
{

    // Representa cada parte del cuerpo del 'Snake', derivada de 'ParteJuego'

    class ParteCuerpo : ParteJuego
    {
        public Direccion dir
        {
            get;
            set;
        }

        //Constructor

        //Coordenada X de la parte del cuerpo
        //Coordenada Y de la parte del cuerpo
        //Dirección es la parte del cuerpo que está moviéndose
        public ParteCuerpo(int X, int Y, Direccion direccion) : base(X, Y)
        {
            dir = direccion;
        }

        // Constructor que asigna la posición a 'nada' por defecto
        //Coordenada X de la parte del cuerpo
        //Coordenada Y de la parte del cuerpo
        public ParteCuerpo(int X, int Y) : base(X, Y)
        {
            dir = Direccion.nada;
        }
    }
}
