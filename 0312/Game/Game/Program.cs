class Program
{
    static void Main(string[] args)
    {
        Engine engine = new Engine();
        engine.Init();//초기화
        engine.LoadScene("level01.map");
        engine.Run();//실행
        engine.Term();//종료
    }
}

