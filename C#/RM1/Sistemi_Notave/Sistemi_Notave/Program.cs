using System;

namespace SistemiINotave
{
    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("  Miresevini ne Sistemin e Notave!");
                Console.WriteLine("====================================\n");

                double piketDetyra = MerrPiket("detyrat");
                double piketKuiz = MerrPiket("kuizet");
                double piketProvim = MerrPiket("provimin");

                Console.WriteLine("\nLlogaritja e notes mesatare...\n");

                double notaMesatare = (piketDetyra + piketKuiz + piketProvim) / 3;
                string notaFinale = GjejNoten(notaMesatare);

                Console.WriteLine($"Nota mesatare: {notaMesatare:F2}");
                Console.WriteLine($"Nota perfundimtare: {notaFinale}");

                if (notaMesatare >= 60)
                    Console.WriteLine("Urime! Ju keni kaluar kursin.");
                else
                    Console.WriteLine("Fatkeqësisht, ju nuk e kaluat kursin.");

                Console.Write("\nDeshironi te llogarisni noten per nje student tjeter? (po/jo): ");
            } while (Console.ReadLine().Trim().ToLower() == "po");

            Console.WriteLine("\nFaleminderit qe perdoret sistemin e notave!");
        }

        static double MerrPiket(string lenda)
        {
            double piket;
            while (true)
            {
                Console.Write($"Shkruani piket per {lenda}: ");
                if (double.TryParse(Console.ReadLine(), out piket) && piket >= 0 && piket <= 100)
                    return piket;
                Console.WriteLine("Gabim! Ju lutem shkruani nje numer nga 0 deri ne 100.");
            }
        }

        static string GjejNoten(double mesatare)
        {
            return mesatare switch
            {
                >= 90 and <= 100 => "A",
                >= 80 and < 90 => "B",
                >= 70 and < 80 => "C",
                >= 60 and < 70 => "D",
                _ => "F",
            };
        }
    }
}
