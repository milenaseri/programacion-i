using System;

namespace Utilidades
{
    public static class Recuadro
    {
        /// <summary>
        /// Dibuja un recuadro alrededor del texto proporcionado
        /// </summary>
        /// <param name="texto">El texto que se mostrará dentro del recuadro</param>
        public static void Dibujar(string texto)
        {
            // Línea superior
            Console.Write("╔");
            for (int i = 0; i < texto.Length + 2; i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╗");
            
            // Línea del medio con el texto
            Console.WriteLine($"║ {texto} ║");
            
            // Línea inferior
            Console.Write("╚");
            for (int i = 0; i < texto.Length + 2; i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╝");
        }
    }
}
