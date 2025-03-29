namespace CuartaClase;

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
        
        // La longitud máxima de palabra debe ser igual al tamaño máximo de la matriz
        int longitudMaxima = Math.Min(filas, columnas);
        
        // Seleccionar cantidad de palabras en función del tamaño
        int cantidadPalabras = (filas == 9) ? 5 : (filas == 12) ? 8 : 12;
        
        // Pasar la longitud máxima como parámetro
        string[] misPalabras = ElegirPalabras(cantidadPalabras, longitudMaxima);

        // Mostrar palabras en una lista
        ListarPalabras(misPalabras);

        // Generar matriz del tamaño deseado
        char[,] miMatriz = GenerarMatriz(filas, columnas);

        // Ubicar palabras en la matriz
        UbicarPalabrasEnMatriz(misPalabras, miMatriz);

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
            "PROGRAMA",
            "INSTRUCCION",
            "PROGRAMADOR",
            "COMPILADOR",
            "INTERPRETE",
            "ENSAMBLADOR",
            "DESARROLLO",
            "MATRIZ",
            "ARREGLO",
            "CODIFICACION",
            "PSEUDOCODIGO"
        };

    // Elige un subconjunto aleatorio de palabras con un límite de longitud
    static string[] ElegirPalabras(int cantidadDeseada, int longitudMaxima)
    {
        // Filtrar palabras que cumplen con la longitud máxima
        List<string> palabrasValidas = new List<string>();
        foreach (string palabra in palabras)
        {
            if (palabra.Length <= longitudMaxima)
            {
                palabrasValidas.Add(palabra);
            }
        }
        
        // Si hay menos palabras válidas que las deseadas, usar todas las que hay
        int cantidadFinal = Math.Min(cantidadDeseada, palabrasValidas.Count);
        
        // Elegir palabras aleatoriamente
        string[] palabrasElegidas = new string[cantidadFinal];
        Random r = new Random();
        
        for (int i = 0; i < cantidadFinal; i++)
        {
            int indice = r.Next(0, palabrasValidas.Count);
            palabrasElegidas[i] = palabrasValidas[indice];
            palabrasValidas.RemoveAt(indice);
        }
        
        return palabrasElegidas;
    }

    // Muestra una lista con las palabras a encontrar
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

    // Permite seleccionar el tamaño de la matriz a través de un menú con tamaños predefinidos
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

    // Genera una matriz de i filas y n columnas pasadas por parámetro
    static char[,] GenerarMatriz(int filas, int columnas)
    {
        char[,] matriz = new char[filas, columnas];
        Random r = new Random();
 
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i,j] = ' ';
            }
        }
 
        return matriz;
    }

    // Selecciona posición inicial de la palabra en la matriz según la dirección
    static (int fila, int columna) SeleccionarPosicionInicial(int direccion, string palabra, int filas, int columnas)
    {
        Random r = new Random();
        int fila = 0;
        int columna = 0;

        switch (direccion)
        {
            case 0: // Horizontal
            {
                fila = r.Next(0, filas); // Cualquier fila
                columna = r.Next(0, columnas - palabra.Length + 1);
                break;
            }
            case 1: // Horizontal invertida
            {
                fila = r.Next(0, filas); // Cualquier fila
                columna = r.Next(palabra.Length - 1, columnas);
                break;
            }
            case 2: // Vertical
            {
                fila = r.Next(0, filas - palabra.Length + 1);
                columna = r.Next(0, columnas); // Cualquier columna
                break;
            }
            case 3: // Vertical invertida
            {
                fila = r.Next(palabra.Length - 1, filas);
                columna = r.Next(0, columnas); // Cualquier columna
                break;
            }
        }
        
        return (fila, columna);
    }

    // Ubica las palabras en la matriz
    static void UbicarPalabrasEnMatriz(string[] palabras, char[,] matriz)
    {
        Random r = new Random();
        int filas = matriz.GetLength(0);
        int columnas = matriz.GetLength(1);
        int[] direccion = new int[palabras.Length];
        int[] filaInicial = new int[palabras.Length];
        int[] columnaInicial = new int[palabras.Length];
        bool posicionValida = false;

        // Recorrer las palabras 
        for (int p = 0; p < palabras.Length; p++)
        {
            // Mientras no encuentre una posición válida, seguir intentando
            do {
                // Asignar una dirección aleatoria
                direccion[p] = r.Next(0, 4);

                // Buscar una posición inicial aleatoria válida para la dirección elegida
                (filaInicial[p], columnaInicial[p]) = SeleccionarPosicionInicial(direccion[p], palabras[p], filas, columnas);

                // TODO: Modularizar esta parte en una función ValidarPosicion
                // Verificar que la posición elegida sea válida
                int posicionesValidas = 0;

                // Sentido en el que voy a moverme por la matriz para hacer las validaciones, normal(+) / invertido(-)
                int sentido = (direccion[p] == 0 || direccion[p] == 2) ? 1 : -1;
                
                // Movimiento horizontal
                if (direccion[p] == 0 || direccion[p] == 1)
                {
                    for (int i = 0; i < palabras[p].Length; i++)
                    {
                        // Posición disponible o caracteres coincidentes => La posición actual es válida
                        if ((matriz[filaInicial[p], columnaInicial[p] + i * sentido] == ' ') ||
                            (matriz[filaInicial[p], columnaInicial[p] + i * sentido] == palabras[p][i]))
                        {
                            posicionesValidas++;
                        }
                        // La primer posición ocupada que encuentre cancela el intento de ubicarla
                        else
                        {
                            posicionesValidas = 0;
                            break;
                        }
                    }
                    // Si todas las posiciones son válidas
                    if (posicionesValidas == palabras[p].Length)
                    {
                        // Iterar sobre los caracteres
                        for (int i = 0; i < palabras[p].Length; i++)
                        {
                            // Ubicar caracter actual en la posición correspondiente
                            matriz[filaInicial[p], columnaInicial[p] + i * sentido] = palabras[p][i];
                        }
                        posicionValida = true;
                    }
                }
                // Movimiento vertical
                else
                {
                    for (int i = 0; i < palabras[p].Length; i++)
                    {
                        // Posición disponible o caracteres coincidentes => La posición actual es válida
                        if ((matriz[filaInicial[p] + i * sentido, columnaInicial[p]] == ' ') ||
                            (matriz[filaInicial[p] + i * sentido, columnaInicial[p]] == palabras[p][i]))
                        {
                            posicionesValidas++;
                        }
                        // La primer posición ocupada que encuentre cancela el intento de ubicarla
                        else
                        {
                            posicionesValidas = 0;
                            break;
                        }
                        
                    }
                    // Si todas las posiciones son válidas
                    if (posicionesValidas == palabras[p].Length)
                    {
                        // Iterar sobre los caracteres
                        for (int i = 0; i < palabras[p].Length; i++)
                        {
                            // Ubicar caracter actual en la posición correspondiente
                            matriz[filaInicial[p] + i * sentido, columnaInicial[p]] = palabras[p][i];
                        }
                        posicionValida = true;
                    }
                }
            } while (posicionValida == false);

            // Reincio el booleano para validar la siguiente palabra
            posicionValida = false;
        }

        // Llenar espacios en blanco con letras aleatorias
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (matriz[i, j] == ' ')
                {
                    matriz[i, j] = (char)r.Next(65,91);
                }
            }
        }
    }

    static void DibujarMatriz(char[,] matriz)
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

                 Console.Write($"{matriz[i, j]} ");
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
