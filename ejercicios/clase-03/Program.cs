namespace TerceraClase;

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
            Console.WriteLine("6. Salir");
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
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Menu();
                    break;
            }
        }
        static int EjemploReadKey()
        {   
            string valor = "0";
            bool fin = false;
            Console.WriteLine("Presione una tecla...");
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
                    Console.WriteLine($"\nPresionó Enter. El valor es de: {valor}");
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
}
