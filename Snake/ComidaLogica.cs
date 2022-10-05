using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{

    // Administra puntos de comida, destrucción y detección de choque.
    class ComidaLogica
    {
        private Random r = new Random(); // Usado para generar variables aleatorias en esta clase
        private List<Comida> PuntosDeComida = new List<Comida>(); // Colección de todos los puntos de comida activos en el juego
        private const int RadioCirculo = 20; // Tamaño de los puntos de la comida 
        private int juegoAncho; // Tamaño de la ventana de juego en píxeles para asegurar el trazo del programa contra la pantalla
        private int juegoAlto;


        public ComidaLogica(int JuegoAncho, int JuegoAlto)
        {
            juegoAncho = JuegoAncho;
            juegoAlto = JuegoAlto;
        }


        // Dibuja los puntos de comida
        public void Personalizar(Graphics Canvas)
        {
            // Dibujar los puntos
            Brush ColorDeSnake = Brushes.Crimson;
            foreach (Comida Pellet in PuntosDeComida)
            {
                Puntos PartPos = Pellet.GetPosicion();
                Canvas.FillEllipse(ColorDeSnake, new Rectangle(PartPos.X + (RadioCirculo / 4), PartPos.Y + (RadioCirculo / 4), RadioCirculo / 2, RadioCirculo / 2));
            }
        }

        // Añade puntos de comida al juego
        public void AnadirComidaAleaotoria()
        {
            int X = r.Next(juegoAncho - RadioCirculo); // Posiciones X y Y aleatorias.
            int Y = r.Next(juegoAlto - RadioCirculo);
            int ix = (X / RadioCirculo); // Usado para ajustar la cuadrícular
            int iy = Y / RadioCirculo;
            X = ix * RadioCirculo; // Posiciones X / Y
            Y = iy * RadioCirculo;
            PuntosDeComida.Add(new Comida(X, Y)); // Guarda el objeto de punto comida
        }


        // Override para añadir alimentos en cantidades
        // Cantidad de comida por añadir
        public void AnadirComidaAleatorio(int Amount)
        {
            for (int i = 0; i < Amount; i++)
            {
                AnadirComidaAleaotoria();
            }
        }

       
        // Determina si el rectángulo dado cruza con cualquier punto de alimentos existentes
        public bool IsRectanguloIntersectado(Rectangle rect, bool RemoverComida)
        {
            foreach (Comida Pellet in PuntosDeComida) // Revisa cada punto de comida
            {
                Puntos PartPos = Pellet.GetPosicion();

                // Revisa intersección existente de rectángulo con puntos de comida
                if (rect.IntersectsWith(new Rectangle(PartPos.X, PartPos.Y, RadioCirculo, RadioCirculo)))
                {
                    if (RemoverComida) 
                        PuntosDeComida.Remove(Pellet);
                    return true;
                }
            }
            return false;
        }
    }
}
