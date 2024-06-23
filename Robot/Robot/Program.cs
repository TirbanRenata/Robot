using System;
using static GiantKillerRobot;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("       .--.");
        Console.WriteLine("      |o_o |");
        Console.WriteLine("      |:_/ |");
        Console.WriteLine("     //   \\ \\");
        Console.WriteLine("    (|     | )");
        Console.WriteLine("   /'\\_   _/`\\");
        Console.WriteLine("   \\___)=(___/");

        GiantKillerRobot robot = new GiantKillerRobot();
        robot.Initialize();

        Console.WriteLine("Robot initializat!");

        Planet earth = new Planet();
        earth.ContainsLife = true;

        bool continueSearching = true;
        Random random = new Random();
        Entity currentTarget = null;

        while (continueSearching)
        {
            // Solicităm utilizatorului să introducă intensitatea laserului
            Console.WriteLine("Introduceti intensitatea laserului (Low, Medium, High sau Kill):");
            string intensityInput = Console.ReadLine();

            if (Enum.TryParse(intensityInput, true, out Intensity laserIntensity))
            {
                // Afișăm intensitatea laserului ales
                Console.WriteLine($"Robotul trage cu laserul la intensitatea: {laserIntensity}");

                if (currentTarget == null || !currentTarget.IsAlive)
                {
                    // Alegem aleatoriu o entitate de pe planetă care nu a fost deja țintită
                    do
                    {
                        int index = random.Next(earth.Entities.Count);
                        currentTarget = earth.Entities[index];
                    } while (!currentTarget.IsAlive);
                }

                // Tragem cu laserul către entitate
                robot.FireLaserAt(currentTarget, laserIntensity);

                // Afișăm viata entității țintă
                Console.WriteLine($"Viata ramasa pentru {currentTarget.Name}: {currentTarget.Health}%");

                // Verificăm dacă entitatea a fost distrusă
                if (!currentTarget.IsAlive)
                {
                    Console.WriteLine($"{currentTarget.Name} a fost distrus!");
                    Console.WriteLine("Trecem la urmatoare entitate");

                    // Alegem o altă entitate de pe planetă care nu a fost deja țintită
                    do
                    {
                        int index = random.Next(earth.Entities.Count);
                        currentTarget = earth.Entities[index];
                    } while (!currentTarget.IsAlive);

                    // Continuăm căutarea
                    continue;
                }

                // Întrebăm utilizatorul dacă dorește să continue căutarea sau să tragă în aceeași entitate
                Console.WriteLine("Continuam sa gasim entitati? (da/nu):");
                string continueInput = Console.ReadLine();
                continueSearching = (continueInput.ToLower() == "da");

                if (!continueSearching)
                {
                    Console.WriteLine("Continuam sa tragem in aceeasi entitate? (da/nu):");
                    string continueTargetInput = Console.ReadLine();
                    if (continueTargetInput.ToLower() == "da")
                    {
                        continueSearching = true; // Setăm continuarea căutării pentru a permite trageri în aceeași entitate
                    }
                }
            }
            else
            {
                Console.WriteLine("Intensitatea laserului introdusă nu este validă. Încercați din nou.");
            }
        }

    }
}
