namespace CuartaClase;

// TODO: Agregar palabras seleccionadas a la matriz
// TODO: Agregar función para moverse por la matriz y seleccionar palabras con una tecla
// TODO: Implementar validación de palabras encontradas
// TODO: Separar recuadro en otra función y agregarle color
// IDEA: Agregar sistema de puntos

class Program
{
    static void Main(string[] args)
    {
        // Seleccionar tamaño de la sopa de letras
        (int filas, int columnas) = SeleccionarTamanoMatriz();
        
        // Seleccionar cantidad de palabras en función del tamaño
        int cantidadPalabras = (filas == 9) ? 5 : (filas == 12) ? 8 : 12;
        string[] misPalabras = ElegirPalabras(cantidadPalabras);

        // Mostrar palabras en una lista
        ListarPalabras(misPalabras);

        // Generar matriz del tamaño deseado
        int[,] miMatriz = GenerarMatriz(filas, columnas);

        // Dibujar matriz en la consola
        DibujarMatriz(miMatriz);
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
        Console.Clear();
        Console.WriteLine("S O P A   D E   L E T R A S");
        Console.WriteLine(); // Línea en blanco
        Console.WriteLine("Palabras a encontrar:");
        Console.WriteLine(); // Línea en blanco

        for (int i = 0; i < palabrasParaMostrar.Length; i++)
        {
            Console.WriteLine($"{i+1}. {palabrasParaMostrar[i]}");
        }

        Console.WriteLine(); // Línea en blanco
    }

    static (int filas, int columnas) SeleccionarTamanoMatriz()
    {
        Console.Clear();
        Console.WriteLine("S O P A   D E   L E T R A S");
        Console.WriteLine(); // Línea en blanco
        Console.WriteLine("Seleccione el tamaño de la sopa de letras:");
        Console.WriteLine(); // Línea en blanco
        Console.WriteLine("1. Pequeña - 9x9 (5 palabras)");
        Console.WriteLine("2. Mediana - 12x12 (8 palabras)");
        Console.WriteLine("3. Grande - 15x15 (12 palabras)");
        Console.WriteLine(); // Línea en blanco

        int opcion;
        bool esValido;

        do
        {
            Console.Write("Ingrese su opción (1-3): ");
            esValido = int.TryParse(Console.ReadLine(), out opcion); // Intentar convertir a entero y guardar la opción

            // Opción no válida o fuera de rango
            if (!esValido || opcion < 1 || opcion > 3)
            {
                Console.WriteLine(); // Línea en blanco
                Console.WriteLine("Opcion no válida. Intente nuevamente.");
                Console.WriteLine(); // Línea en blanco
                esValido = false;
            }
        } while (!esValido);
        
        // Devolver dimensiones según la opción
        switch (opcion)
        {
            case 1: return (9, 9);   // 9x9
            case 2: return (12, 12); // 12x12
            case 3: return (15, 15); // 15x15
            default: return (12, 12);
        }
    }

    static int[,] GenerarMatriz(int filas, int columnas)
    {
        int[,] matriz = new int [filas,columnas];
        Random r = new Random();

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i,j] = r.Next(65,91); // ASCII 65-90 (A-Z)
            }
        }

        return matriz;
    }

    static void DibujarMatriz(int[,] matriz)
    {
        int filas = matriz.GetLength(0);
        int columnas = matriz.GetLength(1);

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
