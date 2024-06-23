using System;
using System.Collections.Generic;

public class GiantKillerRobot
{
    public enum Intensity//nivelurile de intensitate a laserului ochiului robotului.
    {
        Low,
        Medium,
        High,
        Kill
    }
    
    public Intensity EyeLaserIntensity { get; set; }
    public List<string> TargetTypes { get; set; }
    public bool Active { get; private set; }
    public Entity CurrentTarget { get; private set; }

    public void Initialize()
    {
        Active = true;
        EyeLaserIntensity = Intensity.Kill;
        TargetTypes = new List<string> { "Animal", "Human", "Superhero" };
    }

    public void FireLaserAt(Entity target, Intensity intensity)
    
    {
        if (target != null && target.IsAlive)
        {
            Console.WriteLine($"Robotul trage cu laserul către {target.Name}...");

            // Scădem punctele de viață în funcție de intensitatea laserului
            switch (intensity)
            {
                case Intensity.Low:
                    target.Health -= 10;
                    break;
                case Intensity.Medium:
                    target.Health -= 20;
                    break;
                case Intensity.High:
                    target.Health -= 30;
                    break;
                case Intensity.Kill:
                    target.Health = 0;
                    break;
            }

           

            // Verificăm dacă entitatea a fost distrusă
            if (target.Health <= 0)
            {
                target.IsAlive = false;
              //  Console.WriteLine($" {target.Name} a fost distrusă!");
            }
        }
        else
        {
            Console.WriteLine("Nu există o țintă validă la care să tragem cu laserul.");
        }
    }


    public void AcquireNextTarget()
    {
        foreach (var targetType in TargetTypes)
        {
            Random random = new Random();
            int index = random.Next(TargetTypes.Count);
            string nextTarget = TargetTypes[index];
        }
    }
}
