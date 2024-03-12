
class Player : GameObject
{
    public Player()
    {
        shape = 'P';
    }

    ~Player()
    {

    }

    public Player(int newX, int newY)
    {
        shape = 'P';
        x = newX;
        y = newY;
    }

    public override void Start()
    {

    }


    public override void Update()
    {
        
        if (Input.GetButton("left"))
        {
            x--;
        }
        if (Input.GetButton("right"))
        {
            x++;
        }
        if (Input.GetButton("up"))
        {
            y--;
        }
        if (Input.GetButton("down"))
        {
            y++;
        }

        x = Math.Clamp(x, 0, 80);
        y = Math.Clamp(y, 0, 80);


    }

}

