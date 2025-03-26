namespace TerceraClase;

// TODO: Modularizar aún más las funciones
// TODO: Implementar sopa de letras con 3 palabras ubicadas en forma aleatoria (posiblemente en un nuevo programa clase-04)

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }
        static void EjemploFor()
    {
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();
        for(int i = 0; i < nombre.Length; i++)
        {
           Console.WriteLine(nombre[i]);
        }
    }
        static void EjemploForEach()
    {
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();
        foreach(char c in nombre)
        {
           Console.WriteLine(c);
        }
    }
        static void EjemploDoWhile()
    {
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();
        do{
           Console.WriteLine(nombre);
        }while(nombre == "Milena");
    }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Ejemplo For");
            Console.WriteLine("2. Ejemplo DoWhile");
            Console.WriteLine("3. Ejemplo ForEach");
            Console.WriteLine("4. Ejemplo ReadKey");
            Console.WriteLine("5. Ejemplo ReadKeyDos");
            Console.WriteLine("6. Ejemplo Vector");
            Console.WriteLine("7. Ejemplo Matriz");
            Console.WriteLine("8. Ejemplo Random");
            Console.WriteLine("9. Salir");
            Console.WriteLine();
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch(opcion)
            {
                case "1":
                    EjemploFor();
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "2":
                    EjemploDoWhile();
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "3":
                    EjemploForEach();
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "4":
                    Console.WriteLine(EjemploReadKey());
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "5":
                    EjemploReadKeyDos();
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "6":
                    EjemploVector();
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "7":
                    EjemploMatriz();
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "8":
                    EjemploRandom();
                    Console.Write("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "9":
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Menu();
                    break;
            }
        }
        // FIXME: No funciona porque se modificó para usar en otros ejemplos
        static int EjemploReadKey()
        {   
            string valor = "0";
            bool fin = false;
            //Console.WriteLine("Presione una tecla...");
            do {
                ConsoleKeyInfo k = Console.ReadKey(true);
                if ((int)k.KeyChar >= 48 && (int)k.KeyChar <= 57)
                {
                    Console.Write(k.KeyChar);
                    valor = valor + k.KeyChar;
                }
                else if (k.Key == ConsoleKey.Enter)
                {
                    fin = true;
                    //Console.WriteLine($"\nPresionó Enter. El valor es de: {valor}");
                }
                else
                {
                    Console.WriteLine("Presione una tecla numérica...");
                }
            } while (!fin);
            return int.Parse(valor);
        }
        static void EjemploReadKeyDos()
        {
            Console.Clear();
            Console.WriteLine("Usa las flechas para moverte. Enter para salir.");
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.Write("*");
            Console.SetCursorPosition(0, 2);
            bool fin = false;
            do{
                ConsoleKeyInfo k = Console.ReadKey(true);
                switch(k.Key)
                {
                    case ConsoleKey.UpArrow: // Arriba
                        if (Console.CursorTop > 2) // Evitar que se salga de la pantalla
                        {
                            Console.CursorTop--;
                        }
                        Console.Write("*");
                        Console.CursorLeft--; // Retroceder para que quede en la misma posición
                        break;
                    case ConsoleKey.DownArrow: // Abajo
                        Console.CursorTop++;
                        Console.Write("*");
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.LeftArrow: // Izquierda
                        if (Console.CursorLeft > 0) // Evitar que se salga de la pantalla
                        {
                            Console.CursorLeft--;
                            Console.Write("*");
                            Console.CursorLeft--;
                        }   
                        break;
                    case ConsoleKey.RightArrow: // Derecha
                        Console.CursorLeft++;
                        Console.Write("*");
                        Console.CursorLeft--;
                        break;
                    /* case ConsoleKey.Backspace: // Borrar
                        Console.Write(" ");
                        Console.CursorLeft--;
                        break; */
                    case ConsoleKey.Enter: // Enter (Salir)
                        Console.CursorVisible = true;
                        fin = true;
                        break;
                    default:
                        break;
                }
            } while (!fin);
        }
        static void EjemploVector()
        {
            Console.Clear();
            Console.Write("Ingrese el tamaño del vector: ");
            int x = int.Parse(Console.ReadLine());
            int[] v = new int[x];
            v[0] = 0;
            int max = int.MinValue; // Valor mínimo posible para un entero
            int min = int.MaxValue; // Valor máximo posible para un entero
            for (int i= 0; i < v.Length; i++)
            {
                Console.Write($"Ingrese un valor para la posición {i}: ");
                v[i] = EjemploReadKey();
                Console.WriteLine();
                if (v[i] > max)
                {
                    max = v[i];
                }
                if (v[i] < min)
                {
                    min = v[i];
                }
                Console.WriteLine($"El valor máximo es: {max}. El valor mínimo es: {min}.");
            }
        }
        static void EjemploMatriz()
        {
            Console.Clear();

            // Obtener tamaño de la matriz
            Console.Write("Ingrese cantidad de filas: ");
            int filas = int.Parse(Console.ReadLine());
            Console.Write("Ingrese cantidad de columnas: ");
            int columnas = int.Parse(Console.ReadLine());
            int[,] m = new int [filas,columnas];

            // Obtener los valores de la matriz
            Console.WriteLine();
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write($"Ingrese un valor para la posición {i},{j}: ");
                    m[i,j] = EjemploReadKey();
                    Console.WriteLine();
                }
            }

            // Mostrar la matriz
            Console.WriteLine();
            Console.WriteLine("Matriz resultante:\n");
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write($"{m[i,j]}\t");
                }
                Console.WriteLine();
            }
 
            // Mostrar la matriz traspuesta
            Console.WriteLine();
            Console.WriteLine("Matriz traspuesta:\n");
            for (int j = 0; j < columnas; j++)
            {
                for (int i = 0; i < filas; i++)
                {
                    Console.Write($"{m[i,j]}\t");
                }
                Console.WriteLine();
            }
        }
        static void EjemploRandom()
        {
            Console.Clear();
            // Generar matriz con valores random
            Random r = new Random();
            int filas = r.Next(1,9); // 1-8
            int columnas = r.Next(1,9);
            int[,] matriz = new int[filas,columnas];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i,j] = r.Next(1,99);
                }
            }
          
            // Mostrar matriz
            Console.WriteLine($"Matriz random de {matriz.GetLength(0)}x{matriz.GetLength(1)}:\n");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i,j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
}
