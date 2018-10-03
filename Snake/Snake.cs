using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Snake
{
    public partial class Snake : Form, IMessageFilter
    {
        Jugador jugador;
        ComidaLogica AdminComida;
        Random r = new Random();
        private int puntaje = 0;
        public Snake()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
            jugador = new Jugador(this);
            AdminComida = new ComidaLogica(FondoJuego.Width, FondoJuego.Height);
            AdminComida.AnadirComidaAleatorio(10);
            txtPuntajeSnake.Text = puntaje.ToString();
        }

        public void ActivarTiempo()
        {
            Cronometro.Enabled = !Cronometro.Enabled;
        }

        public void ReiniciarJuego()
        {
            jugador = new Jugador(this);
            AdminComida = new ComidaLogica(FondoJuego.Width, FondoJuego.Height);
            AdminComida.AnadirComidaAleatorio(10);
            txtPuntajeSnake.Text = "0";
        }

        public bool PreFilterMessage(ref Message msg)
        {
            if (msg.Msg == 0x0101) // Tecla Arriba
                EntradaTeclado.SetKey((Keys)msg.WParam, false);
            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //´Método de C# para procesar tecleo
        {
            if (msg.Msg == 0x100) // Tecla Abajo
                EntradaTeclado.SetKey((Keys)msg.WParam, true);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Canvas_Color(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            jugador.Personalizar(canvas);
            AdminComida.Personalizar(canvas);
        }

        private void RevisarChoques()
        {
            if (jugador.IsRectanguloIntersectado(new Rectangle(-100, 0, 100, FondoJuego.Height)))
                jugador.AlChocarPared(Direccion.izquierda);

            if (jugador.IsRectanguloIntersectado(new Rectangle(0, -100, FondoJuego.Width, 100)))
                jugador.AlChocarPared(Direccion.arriba);

            if (jugador.IsRectanguloIntersectado(new Rectangle(FondoJuego.Width, 0, 100, FondoJuego.Height)))
                jugador.AlChocarPared(Direccion.derecha);

            if (jugador.IsRectanguloIntersectado(new Rectangle(0, FondoJuego.Height, FondoJuego.Width, 100)))
                jugador.AlChocarPared(Direccion.abajo);

            // Cuando agarra comida y se estira
            List<Rectangle> SnakeRects = jugador.GetRects();
            foreach (Rectangle rect in SnakeRects)
            {
                if (AdminComida.IsRectanguloIntersectado(rect, true))
                {
                    AdminComida.AnadirComidaAleaotoria();
                    jugador.AddPartesCuerpo(1);
                    puntaje++;
                    txtPuntajeSnake.Text = puntaje.ToString();
                }
            }
        }

        private void SetMovimientoJugador()
        {
            if (EntradaTeclado.IsTeclaAbajo(Keys.Left))
            {
                jugador.SetDirection(Direccion.izquierda);
            }
            else if (EntradaTeclado.IsTeclaAbajo(Keys.Right))
            {
                jugador.SetDirection(Direccion.derecha);
            }
            else if (EntradaTeclado.IsTeclaAbajo(Keys.Up))
            {
                jugador.SetDirection(Direccion.arriba);
            }
            else if (EntradaTeclado.IsTeclaAbajo(Keys.Down))
            {
                jugador.SetDirection(Direccion.abajo);
            }
            jugador.MoverJugador();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            SetMovimientoJugador();
            RevisarChoques();
            FondoJuego.Invalidate();
        }

        private void btnInicioPausa_Click(object sender, EventArgs e)
        {
            ActivarTiempo();
        }

        private void btnComidaExtra_Click(object sender, EventArgs e)
        {
            AdminComida.AnadirComidaAleatorio(20);
            FondoJuego.Invalidate();
        }
    }
}
