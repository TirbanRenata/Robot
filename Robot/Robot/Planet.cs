using System.Collections.Generic;

public class Planet
{
    public bool ContainsLife { get; set; }
    public List<Entity> Entities { get; private set; }

    public Planet()
    {
        Entities = new List<Entity>();

        // Adăugăm animale pe planetă
        Entities.Add(new Entity("Oaia"));
        Entities.Add(new Entity("Capră"));
        Entities.Add(new Entity("Porcul"));
        Entities.Add(new Entity("Porcul"));
        Entities.Add(new Entity("Cal"));
        Entities.Add(new Entity("Vaca"));

        // Adăugăm oameni pe planetă
        for (int i = 0; i < 1; i++)
        {
            Entities.Add(new Entity("Persoană " + (i + 1)));
        }

        // Adăugăm supereroi pe planetă
        for (int i = 0; i < 3; i++)
        {
            Entities.Add(new Entity("Supererou " + (i + 1)));
        }
    }
}
