using System;
using System.Linq;

namespace MenaxhimiRezultateve
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Mirësevini në sistemin e menaxhimit të rezultateve të studentëve!");

            int numStudent, numLende;


            Console.Write("Vendosni numrin e studentëve: ");
            numStudent = MerrNumer();

            Console.Write("Vendosni numrin e lëndëve: ");
            numLende = MerrNumer();

            int[,] notat = new int[numStudent, numLende];


            for (int i = 0; i < numStudent; i++)
            {
                for (int j = 0; j < numLende; j++)
                {
                    notat[i, j] = MerrNote($"Studenti {i + 1}, Lënda {j + 1}: ");
                }
            }

            Console.Clear();
            Console.WriteLine("\nMatrica e notave:");
            PrintoMatricen(notat);

            Console.WriteLine("\nShuma dhe mesatarja për çdo student:");
            ShumaMesatarja(notat);

            Console.Write("\nVendosni notën që kërkoni të gjeni: ");
            int notaKerkese = MerrNumer();
            GjejNoten(notat, notaKerkese);

            Console.Write("\nVendosni koeficientin për shumëzimin e matricës: ");
            double koeficienti = MerrKoeficient();
            int[,] matricaRe = ShumzoMatricen(notat, koeficienti);
            Console.WriteLine("\nMatrica pas shumëzimit:");
            PrintoMatricen(matricaRe);

            Console.WriteLine("\nNota maksimale dhe minimale për çdo student:");
            NotaMaxMin(notat);
        }


        static int MerrNumer()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int num) && num > 0)
                    return num;
                Console.Write("Gabim! Ju lutem shkruani një numër të vlefshëm: ");
            }
        }


        static int MerrNote(string mesazh)
        {
            int nota;
            do
            {
                Console.Write(mesazh);
            } while (!int.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 100);

            return nota;
        }


        static double MerrKoeficient()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double koef) && koef > 0)
                    return koef;
                Console.Write("Gabim! Ju lutem shkruani një koeficient të vlefshëm: ");
            }
        }


        static void PrintoMatricen(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        static void ShumaMesatarja(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int shuma = matrix.Cast<int>().Skip(i * matrix.GetLength(1)).Take(matrix.GetLength(1)).Sum();
                double mesatarja = (double)shuma / matrix.GetLength(1);
                Console.WriteLine($"Student {i + 1} - Shuma: {shuma}, Mesatarja: {mesatarja:F2}");
            }
        }


        static void GjejNoten(int[,] matrix, int nota)
        {
            bool eGjetur = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == nota)
                    {
                        Console.WriteLine($"Nota {nota} gjendet tek studenti {i + 1}, lënda {j + 1}.");
                        eGjetur = true;
                    }
                }
            }
            if (!eGjetur)
                Console.WriteLine($"Nota {nota} nuk u gjet në matricë.");
        }


        static int[,] ShumzoMatricen(int[,] matrix, double koef)
        {
            int[,] matricaRe = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matricaRe[i, j] = (int)(matrix[i, j] * koef);
                }
            }
            return matricaRe;
        }


        static void NotaMaxMin(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] notatStudentit = matrix.Cast<int>().Skip(i * matrix.GetLength(1)).Take(matrix.GetLength(1)).ToArray();
                Console.WriteLine($"Student {i + 1} - Nota më e madhe: {notatStudentit.Max()}, Nota më e vogël: {notatStudentit.Min()}");
            }
        }
    }
}

