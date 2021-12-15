﻿public class World
{
    public Worm[] Worms { get; set; }
    public Food[] Foods { get; set; }
    public int Step { get; set; }
}

public class Worm : Field
{
    public string name { get; set; }
    public int Life { get; set; }
}

public class Food: Field
{
    public int expiresIn { get; set; }
}
public class Field
{
    public int X { get; set; }
    public int Y { get; set; }
}


