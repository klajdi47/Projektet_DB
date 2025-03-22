using System;
using System.Linq;

namespace SistemiINotave
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Ky program do të marrë notat dhe do të analizojë ato.");
            Console.Write("Sa nota dëshironi të fusni? ");
            int numriNoteve = MerrNumer();

            int[] notat = new int[numriNoteve];
            int pragKalimi = 60;

            // Marrja e notave nga përdoruesi
            for (int i = 0; i < numriNoteve; i++)
            {
                notat[i] = MerrNote($"Vendos Notën {i + 1}: ");
            }

            Console.Clear();
            Console.WriteLine("Notat e futura janë:");
            foreach (var (nota, index) in notat.Select((v, i) => (v, i + 1)))
            {
                Console.WriteLine($"Nota {index}: {nota}");
            }

            Console.WriteLine();
            Console.WriteLine($"Nota maksimale: {notat.Max()}");
            Console.WriteLine($"Nota minimale: {notat.Min()}");
            Console.WriteLine($"Nota mesatare: {notat.Average():F2}");
            Console.WriteLine($"Numri i notave mbi {pragKalimi}: {NumroNotatMbiPragun(notat, 0, pragKalimi)}");
        }

        // Merr një numër të vlefshëm nga përdoruesi
        static int MerrNumer()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int num) && num > 0)
                    return num;
                Console.Write("Gabim! Ju lutem shkruani një numër të vlefshëm: ");
            }
        }

        // Merr një notë të vlefshme nga përdoruesi
        static int MerrNote(string mesazh)
        {
            int nota;
            do
            {
                Console.Write(mesazh);
            } while (!int.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 100);

            return nota;
        }

        // Rekursivisht numëron sa nota janë mbi pragun e caktuar
        static int NumroNotatMbiPragun(int[] notat, int index, int prag)
        {
            if (index >= notat.Length) return 0;
            return (notat[index] > prag ? 1 : 0) + NumroNotatMbiPragun(notat, index + 1, prag);
        }
    }
}
