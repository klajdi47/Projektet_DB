using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int numriPerTuGjetur = random.Next(1, 101);
        int tentativa = 0;
        int zgjedhja;

        Console.WriteLine("Gjeje numrin midis 1 dhe 100!");

        do
        {
            Console.Write("Shkruaj numrin tend: ");
            if (int.TryParse(Console.ReadLine(), out zgjedhja))
            {
                tentativa++;

                if (zgjedhja < numriPerTuGjetur)
                {
                    Console.WriteLine("Numri eshte me i madh! Provo perseri.");
                }
                else if (zgjedhja > numriPerTuGjetur)
                {
                    Console.WriteLine("Numri eshte me i vogel! Provo perseri.");
                }
                else
                {
                    Console.WriteLine($"Urime! E gjete numrin pas {tentativa} tentativash.");
                }
            }
            else
            {
                Console.WriteLine("Ju lutem shkruani nje numer te vlefshem!");
            }
        } while (zgjedhja != numriPerTuGjetur);
    }
}