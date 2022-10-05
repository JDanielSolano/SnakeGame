using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{

    // Esta clase maneja la entrada del teclado para jugar

    class EntradaTeclado
    {
        // Almacena un rastreo de las teclas en donde sean presionadas.
        private static Dictionary<Keys, bool> Teclas = new Dictionary<Keys, bool>();

        // Obtiene si una tecla es pulsada.
        // Teclas es para comprobar si la tecla fue presionada -Thanks StackOverflow jaja
        public static bool IsTeclaAbajo(Keys key)
        {
            bool EstadoDeTecla;
            if (Teclas.TryGetValue(key, out EstadoDeTecla))
            {
                return EstadoDeTecla;
            }
            return false;
        }

        // Establece una tecla de teclado a ser presionado o liberado
        // Tecla para asignar valor 'true' si fue presionado
        public static void SetKey(Keys key, bool IsAbajo)
        {
            Teclas[key] = IsAbajo;
        }
    }
}
