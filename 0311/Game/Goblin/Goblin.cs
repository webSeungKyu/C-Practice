﻿public class Goblin
    {
    public int gold = 0;
    public string name = "고블린";
    public void Move()
    {
        Console.WriteLine($"{name} 이동한다");
    }

    public void Attack()
    {
        Console.WriteLine($"{name}이 공격한다");
    }

    public void Dead()
    {
        Console.WriteLine($"{name}이 죽고 {gold}를 떨어뜨렸다. ");
    }
}
