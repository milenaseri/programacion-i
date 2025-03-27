namespace CuartaClase;

// TODO: Separar responsabilidades de generación y dibujo de la matriz
// TODO: Agregar palabras seleccionadas a la matriz
// TODO: Agregar función para moverse por la matriz y seleccionar palabras con una tecla
// TODO: Implementar validación de palabras encontradas
// TODO: Separar recuadro en otra función y agregarle color
// IDEA: Permitir al usuario seleccionar el tamaño de la matriz
// IDEA: Agregar sistema de puntos

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("S O P A   D E   L E T R AS\n");
        string[] misPalabras = ElegirPalabras(5);
        ListarPalabras(misPalabras);
        DibujarMatriz();
    }

    // Lista de posibles palabras
    static readonly string[] palabras = new string[]
        {
            "ALGORITMO",
            "VARIABLE",
            "CONSTANTE",
            "ATRIBUTO",
            "ASCII",
            "CLASE",
            "FUNCION",
            "OBJETO",
            "PARADIGMA",
            "METODO",
            "POLIMORFISMO",
            "HERENCIA",
            "ENCAPSULAMIENTO",
            "ABSTRACCION",
            "INSTANCIA",
            "INTERFAZ",
            "CONSTRUCTOR",
            "LENGUAJE",
            "SENTENCIA",
            "DATOS",
            "ESTRUCTURAS",
            "CONTROL",
            "SOFTWARE",
            "CODIGO",
            "COMPILADOR",
            "INTERPRETE",
            "ENSAMBLADOR",
            "DESARROLLO",
            "MATRIZ",
            "ARREGLO",
            "CODIFICACION",
            "PSEUDOCODIGO"
        };

    static string[] ElegirPalabras(int cantidadDeseada)
    {
        // Crear una copia del array original
        string[] palabrasDisponibles = palabras.ToArray();
        string[] palabrasElegidas = new string[cantidadDeseada];
        Random r = new Random();

        for (int i = 0; i < cantidadDeseada; i++)
        {
            // Generar un índice aleatorio entre 0 y la cantidad de palabras disponibles
            int indiceAleatorio = r.Next(0, palabrasDisponibles.Length - 1 - i);
            
            // Guardar la palabra elegida
            palabrasElegidas[i] = palabrasDisponibles[indiceAleatorio];
            
            // Mover la última palabra al lugar de la que acabamos de elegir
            palabrasDisponibles[indiceAleatorio] = palabrasDisponibles[palabrasDisponibles.Length - 1 - i];
        }

        return palabrasElegidas;
    }

    static void ListarPalabras(string[] palabrasParaMostrar)
    {
        Console.WriteLine("Palabras a encontrar:\n");
        for (int i = 0; i < palabrasParaMostrar.Length; i++)
        {
            Console.WriteLine($"{i+1}. {palabrasParaMostrar[i]}");
        }
        Console.WriteLine();
    }

    static void DibujarMatriz()
    {
        int filas = 13;
        int columnas = 13;
        int[,] matriz = new int [filas,columnas];
        Random r = new Random();

        // Generar matriz
        for (int i = 0; i < filas; i++)
        {
            //Console.CursorLeft = Console.CursorLeft + 2;
            for (int j = 0; j < columnas; j++)
            {
                matriz[i,j] = r.Next(65,91); // ASCII 65-90 (A-Z)
            }
        }

        // Línea superior
        Console.Write("╔");
        for (int i = 0; i < (columnas * 2) + 1; i++)
        {
        Console.Write("═");
        }
        Console.WriteLine("╗");

        // Mostrar matriz
        for (int i = 0; i < filas; i++)
        {
            Console.Write("║ "); // Línea izquierda
            for (int j = 0; j < columnas; j++)
            {
                Console.Write($"{(char)matriz[i,j]} ");
            }
            Console.Write("║"); // Línea derecha
            Console.WriteLine();
        }

        // Línea inferior
        Console.Write("╚");
        for (int i = 0; i < (columnas * 2) + 1; i++)
        {
        Console.Write("═");
        }
        Console.WriteLine("╝");
        Console.WriteLine();
    }
}
