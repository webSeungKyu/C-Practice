using System;

public class Boar : Monster
{
    string name = "멧돼지";
    public override void Move()
    {
        Console.WriteLine($"{name} 뛴다");
    }
}