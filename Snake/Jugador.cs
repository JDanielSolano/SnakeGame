using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    // Representa la dirección del jugador

    public enum Direccion
    {
        izquierda,
        derecha,
        arriba,
        abajo,
        nada
    }

    // Clase que contiene la lógica de control para el jugador

    class Jugador
    {
        private List<ParteCuerpo> SnakePartes = new List<ParteCuerpo>(); // Colección de partes del cuerpo del 'Snake' 
        private const int RadioCirculo = 20; // Determina el tamaño del cuerpo
        private Direccion DireccionMovida = Direccion.nada; // Dirección de la cabeza
        private int SegmentosPendientes; // Número de partes del cuerpo en la cola que se añade a la serpiente
        private Snake fmrSnake = null; // Almacena el form


        // Constructor

        // Form para el juego
        public Jugador(Snake FormSnake)
        {
            // Agrega 3 partes del cuerpo a la serpiente porque la serpiente comienza siendo pequeña
            SnakePartes.Add(new ParteCuerpo(100, 0, Direccion.derecha));
            SnakePartes.Add(new ParteCuerpo(80, 0, Direccion.derecha));
            SnakePartes.Add(new ParteCuerpo(60, 0, Direccion.derecha));

            // Dirección inicial
            DireccionMovida = Direccion.derecha;

            //Cuando ya no hay partes del cuerpo en fila para ser agregados al cuerpo
            SegmentosPendientes = 0;
            fmrSnake = FormSnake;
        }


        // Añade partes del cuerpo al 'Snake'

        // Número de partes o segmentos por agregar
        public void AddPartesCuerpo(int Number)
        {
            // Incrementa 'SegmentosPendientes' para que se procese y se añadan en los movimientos ''MoverJugador()''
            SegmentosPendientes += Number;
        }

        // Se mueve la serpiente y procesa cada segmento pendiente de ser creado. Llama cada marco (frame).

        public void MoverJugador()
        {
            //Agrega cada parte pendiente. Esto procesa UNA parte a la vez.
            // Si SegmentosPendientes es mayor a 1, va a requerir más de 1 marco (frame) para procesarlo completamente. 
            if (SegmentosPendientes > 0)
            {
                Puntos LastPos = SnakePartes.Last().GetPosicion(); // Agrega la nueva parte del cuerpo a la cola
                SnakePartes.Add(new ParteCuerpo(LastPos.X, LastPos.Y));
                SegmentosPendientes--;
            }

            SnakePartes[0].dir = DireccionMovida; // Asigna la dirección de la cabeza.

            // Mueve cada parte del 'Snake'.
            for (int i = SnakePartes.Count - 1; i >= 0; i--)
            {
                // Traslada la parte del cuerpo de acuerdo a la dirección
                switch (SnakePartes[i].dir)
                {
                    case Direccion.izquierda:
                        SnakePartes[i].AgregarPosicion(new Puntos(-20, 0));
                        break;
                    case Direccion.derecha:
                        SnakePartes[i].AgregarPosicion(new Puntos(20, 0));
                        break;
                    case Direccion.abajo:
                        SnakePartes[i].AgregarPosicion(new Puntos(0, 20));
                        break;
                    case Direccion.arriba:
                        SnakePartes[i].AgregarPosicion(new Puntos(0, -20));
                        break;
                    default:
                        break;
                }

                //Asigna la dirección de la siguiente parte para ser la dirección de la anterior.
                // Para el movimiento similar al 'Snake' original

                if (i > 0)
                    SnakePartes[i].dir = SnakePartes[i - 1].dir;
            }
            if (IsChoqueConsigoMismo()) // Verifica si chocó consigo mismo
                AlChocarConsigo(); // Si chocó consigo mismo, el juego se acaba
        }

        //Determina si choca consigo mismo
        public bool IsChoqueConsigoMismo()
        {
            // Comprueba cada parte del cuerpo del 'Snake' con cada otra parte del cuerpo
            for (int i = 0; i < SnakePartes.Count; i++)
            {
                for (int j = 0; j < SnakePartes.Count; j++)
                {
                    if (i == j)
                        continue;
                    ParteCuerpo part1 = SnakePartes[i];
                    ParteCuerpo part2 = SnakePartes[j];

                    // Lógica para el choque de paredes
                    if ((new Rectangle(part1.GetPosicion().X, part1.GetPosicion().Y, RadioCirculo, RadioCirculo)).IntersectsWith(
                        new Rectangle(part2.GetPosicion().X, part2.GetPosicion().Y, RadioCirculo, RadioCirculo)))
                        return true;
                }
            }
            return false;
        }

        public void SetDirection(Direccion Dir)
        {
            // Prohibe giros de 180 grados
            if (DireccionMovida == Direccion.izquierda && Dir == Direccion.derecha)
                return;

            if (DireccionMovida == Direccion.derecha && Dir == Direccion.izquierda)
                return;

            if (DireccionMovida == Direccion.arriba && Dir == Direccion.abajo)
                return;

            if (DireccionMovida == Direccion.abajo && Dir == Direccion.arriba)
                return;

            // Establece la dirección si el cambio de dirección rige dentro del rango
            DireccionMovida = Dir;
        }


        // Determina si hubo intersección de cualquier parte del cuerpo con el rectángulo dado

        public bool IsRectanguloIntersectado(Rectangle rect)
        {
            foreach (ParteCuerpo Part in SnakePartes) // Revisa cada parte del cuerpo actual
            {
                Puntos PosicionParte = Part.GetPosicion();

                // Revisa intersección de rectángulo con alguna parte del cuerpo
                if (rect.IntersectsWith(new Rectangle(PosicionParte.X, PosicionParte.Y, RadioCirculo, RadioCirculo)))
                    return true;
            }
            return false;
        }

        // Envía mensaje cuando el 'Snake' choca con PARED.

        public void AlChocarPared(Direccion pared)
        {
            fmrSnake.ActivarTiempo(); // El temporizador desaparece al perder el juego
            MessageBox.Show("¡Uh, eso debió doler! Ha perdido."); // Manda el mensaje
            fmrSnake.ReiniciarJuego();
        }


        // Llama cada marco (frame) para formar cada parte del 'Snake'

        public void Personalizar(Graphics canvas)
        {
            Brush ColorDeSnake = Brushes.Purple;
            List<Rectangle> Rects = GetRects(); // Consigue partes del 'Snake', representadas como rectángulos
            foreach (Rectangle Part in Rects) // Personaliza cada parte del cuerpo
            {
                canvas.FillEllipse(ColorDeSnake, Part); // Personaliza las partes del 'Snake' como elipses
            }
        }

        // Envía mensaje cuando el 'Snake' choca CONSIGO MISMO.

        public void AlChocarConsigo()
        {
            fmrSnake.ActivarTiempo(); // El temporizador desaparece al perder el juego
            MessageBox.Show("¡Auto colisión! Ha perdido el juego."); // Manda el mensaje
            fmrSnake.ReiniciarJuego();
        }


        // Consigue partes del 'Snake', representadas como rectángulos
        // Un lista de partes del 'Snake', representadas como rectángulos
        public List<Rectangle> GetRects()
        {
            List<Rectangle> Rects = new List<Rectangle>();
            foreach (ParteCuerpo Parte in SnakePartes) // Devuelve todas las partes del cuerpo
            {
                Puntos PartPos = Parte.GetPosicion();

                // En cada iteración agrega un rectángulo a la lista actual que representa la parte del cuerpo
                Rects.Add(new Rectangle(PartPos.X, PartPos.Y, RadioCirculo, RadioCirculo));
            }
            return Rects;
        }
    }
}
