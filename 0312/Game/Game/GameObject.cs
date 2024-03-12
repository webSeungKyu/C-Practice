﻿
class GameObject
{
    public int x;
    public int y;

    public GameObject()
    {
        x = 0;
        y = 0;
    }

    ~GameObject()
    {

    }

    public GameObject(int newX, int newY)
    {
        x = newX;
        y = newY;
    }

    public virtual void Start()
    {

    }


    public virtual void Update()
    {

    }

    public virtual void Render()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(shape);
    }

    public char shape;

}
