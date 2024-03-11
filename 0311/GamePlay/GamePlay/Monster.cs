
public class Monster
{
    protected string? name = "몬스터 이름";

    public virtual void Move()
    {
        Console.WriteLine($"{name} 움직인다");
    }
}

