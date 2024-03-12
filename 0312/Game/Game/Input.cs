class Input
{
    public Input()
    {

    }

    ~Input()
    {

    }

    public static void Init()
    {
        inputMapping["up"] = ConsoleKey.UpArrow;
        inputMapping["down"] = ConsoleKey.DownArrow;
        inputMapping["left"] = ConsoleKey.LeftArrow;
        inputMapping["right"] = ConsoleKey.RightArrow;

    }
    public static Dictionary<string, ConsoleKey> inputMapping = new Dictionary<string, ConsoleKey>();

    public static ConsoleKeyInfo keyInfo;
    public static bool GetButton(string buttonName)
    {

        return (keyInfo.Key == inputMapping[buttonName]);
    }
}

