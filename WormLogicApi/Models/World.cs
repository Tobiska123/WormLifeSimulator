public class World
{
    public Worm[] Worms { get; set; }
    public Food[] Food { get; set; }
}

public class Worm
{
    public string name { get; set; }
    public int lifeStrength { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}

public class Food
{
    public int expiresIn { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}

