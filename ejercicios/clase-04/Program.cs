namespace clase_04;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("SOPA DE LETRAS\n");
        DibujarMatriz();
    }
    static void DibujarMatriz()
    {
        int filas = 7;
        int columnas = 7;
        int[,] matriz = new int [filas,columnas];
        Random r = new Random();

        // Generar matriz
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i,j] = r.Next(65,91);
            }
        }

        // Mostrar matriz
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Console.Write($"{(char)matriz[i,j]} ");
            }
            Console.WriteLine();
        }
    }
}
