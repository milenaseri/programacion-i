namespace SegundaClase;
class Program
{
    static void Main(string[] args)
    {
        //======================================================================
        // CONFIGURACIÓN INICIAL
        //======================================================================
        // Obtener el ancho de la consola para crear un separador visual
        int anchoConsola = Console.WindowWidth;
        string separador = new string('=', anchoConsola);

        //======================================================================
        // PANTALLA 1: BIENVENIDA
        //======================================================================
        Console.WriteLine("¡Hola, mundo!");
        Console.WriteLine(separador);
        Console.Write("Presione cualquier tecla para continuar... ");
        Console.ReadKey();

        //======================================================================
        // PANTALLA 2: CAPTURA DE DATOS PERSONALES (STRING)
        //======================================================================
        // Configuración de colores: fondo amarillo, texto verde
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear(); // Limpiar la consola y aplicar los nuevos colores
        
        // Mostrar colores actuales
        Console.WriteLine("Esta pantalla tiene fondo amarillo y texto verde.");
        Console.WriteLine(separador);

        // Obtener nombre y apellido
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese su apellido: ");
        string apellido = Console.ReadLine();

        //======================================================================
        // PANTALLA 3: CAPTURA DE DATOS PERSONALES (INT/DOUBLE)
        //======================================================================
        // Configuración de colores: fondo azul, texto rojo
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();

        // Mostrar colores actuales
        Console.WriteLine("Esta pantalla tiene fondo azul y texto rojo.");
        Console.WriteLine(separador);

        // Obtener edad y altura
        Console.Write("Ingrese su edad: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese su altura: ");
        double altura = double.Parse(Console.ReadLine());

        //======================================================================
        // PANTALLA 4: PRESENTACIÓN DE DATOS BÁSICA 
        //======================================================================
        // Configuración de colores: fondo cian, texto verde
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();

        // Mensaje informativo sobre los colores actuales
        Console.WriteLine("Esta pantalla tiene fondo cian y texto verde.");
        Console.WriteLine(separador);

        // Mostrar resumen de datos ingresados
        Console.WriteLine($"Hola {nombre} {apellido}. Nació en {DateTime.Now.Year - edad} y mide {altura} m.");
        Console.WriteLine(separador);
        Console.Write("Presione cualquier tecla para continuar... ");
        Console.ReadKey();

        //======================================================================
        // PANTALLA 5: PRESENTACIÓN DE DATOS ADICIONALES 
        //======================================================================
        // Restaurar colores originales de la consola
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        // Mostrar colores actuales
        Console.WriteLine("Color original.");
        Console.WriteLine(separador);
        
        // Mostrar cantidad de caracteres del nombre
        Console.WriteLine($"Su nombre tiene {nombre.Length} caracteres.");
        
        // Generar apellido invertido
        string apellidoInvertido = "";
        for (int i = apellido.Length - 1; i >= 0; i--) // Recorrer el apellido de atrás hacia adelante
        {
            apellidoInvertido += $"{apellido[i]}"; // Concatenar cada caracter al nuevo apellido
        }
        
        // Mostrar apellido invertido
        Console.WriteLine($"Su apellido al revés es \"{apellidoInvertido}\".");
        
        // Mostrar una tabla con el nombre en mayúsculas, apellido, edad, altura, iniciales.
        string datos = ($@"Datos:
- Nombre: {nombre.ToUpper()}
- Apellido: {apellido}
- Edad: {edad}
- Altura: {altura} m
- Iniciales: {nombre[0]}{apellido[0]}");
        Console.WriteLine(datos);

        // Salir del programa
        Console.WriteLine(separador);
        Console.Write("Presione cualquier tecla para salir... ");
        Console.ReadKey();
        Console.WriteLine("¡Gracias por usar este programa!");
        Console.Clear();
    }
}