namespace First;

class Program
{
    // Definición de la función para cambiar el color de la consola
    static void CambiarColorConsola(string color)
    {
        switch (color.ToLower())
        {
            case "1":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "2":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "3":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "4":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "5":
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case "6":
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White; // Color por defecto
                break;
        }
    }
    
    // Función para pedir el nombre al usuario
    static string PedirNombre()
    {
        Console.Write("Ingrese su nombre: ");
        return Console.ReadLine();
    }
    
    // Función para mostrar el menú de colores
    static string MostrarMenuColores()
    {
        string menu = (@"Colores:
1. Rojo
2. Verde
3. Azul
4. Amarillo
5. Cian
6. Magenta
Seleccione un color: ");
        
        Console.Write(menu);
        return Console.ReadLine();
    }
    
    // Función para dibujar el recuadro con el saludo
    static void DibujarRecuadro(string saludo)
    {
        // Línea superior
        Console.Write("╔");
        for (int i = 0; i < saludo.Length + 2; i++)
        {
            Console.Write("═");
        }
        Console.WriteLine("╗");
        
        // Línea del medio con el saludo
        Console.WriteLine($"║ {saludo} ║");
        
        // Línea inferior
        Console.Write("╚");
        for (int i = 0; i < saludo.Length + 2; i++)
        {
            Console.Write("═");
        }
        Console.WriteLine("╝");
    }
    
    static void Main(string[] args)
    {
        // Obtener el nombre usando la función
        string nombre = PedirNombre();
        
        // Mostrar menú y obtener color seleccionado
        string color = MostrarMenuColores();
        
        // Cambiar el color de la consola
        CambiarColorConsola(color);
        
        // Construir el mensaje de saludo
        string saludo = $"¡Hola {nombre}!";
        
        // Dibujar el recuadro con el saludo
        DibujarRecuadro(saludo);
        
        // Resetear el color de la consola
        Console.ForegroundColor = ConsoleColor.White;
    }
}