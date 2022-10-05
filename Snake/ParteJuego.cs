using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    // Representa la unidad gráfica del juego

    class ParteJuego
    {
        private Puntos Posicion;

        // Obtiene la posición del punto

        public Puntos GetPosicion()
        {
            return Posicion;
        }

        // Se mueve la parte de juego mediante la adición de la posición actual con la posición del punto

        public void AgregarPosicion(Puntos point)
        {
            Posicion.X += point.X;
            Posicion.Y += point.Y;
        }

        // Asigna la posición de la parte

        public void SetPosicion(Puntos punto)
        {

            Posicion = punto;
        }

        // Constructor
        // Coordenada X de la parte
        // Coordenada Y de la parte
        public ParteJuego(int X, int Y)
        {
            Posicion = new Puntos(X, Y);
        }
    }
}
