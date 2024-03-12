class Engine
{
    public Engine()
    {
        gameObjects = new List<GameObject>();
    }

    ~Engine()
    {

    }

    public List<GameObject> gameObjects;
    public bool isRunning = true;


    public void Init()
    {

    }
    public void LoadScene(string mapName)
    {


        /*string dir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        string[] map = File.ReadAllLines(dir + "/../data/level01.map");*/
        string[] map = File.ReadAllLines($"../../../data/{mapName}");

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '*')
                {
                    Instantiate(new Wall(x, y));
                }
                else if (map[y][x] == ' ')
                {
                    Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    Instantiate(new Player(x, y));
                }
                else if (map[y][x] == 'G')
                {
                    Instantiate(new Goal(x, y));
                }
                else if (map[y][x] == 'M')
                {
                    Instantiate(new Monster(x, y));
                }

            }
        }
        //Load();
    }

    public void Run()
    {
        while (isRunning)
        {
            Input();
            Update();
            Render();
        } //frame
    }

    public void Term()
    {
        gameObjects.Clear();
    }

    /*public GameObject Instanticate<T>() where : T GameObject
    {
        return new T();
    }*/

    public GameObject Instantiate(GameObject newGameObject)
    {
        gameObjects.Add(newGameObject);
        return newGameObject;
    }

    protected void Update()
    {

    }

    protected void Render()
    {
        /*for(int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].Render();
        }*/
        Console.Clear();
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Render();
        }
    }

    protected void Input()
    {
        Console.ReadKey();
    }
}

