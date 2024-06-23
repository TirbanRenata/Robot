public class Entity
{
    public string Name { get; set; }
    public bool IsAlive { get; set; }
    public int Health { get; set; } 

    public Entity(string name)
    {
        Name = name;
        IsAlive = true;
        Health = 100; // Setăm punctele de viață inițiale la 100
    }
}
