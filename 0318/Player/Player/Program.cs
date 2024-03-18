using System.Linq.Expressions;

class Player
{

    public List<IItem> inventory = new List<IItem>();

    public Player()
    {

    }

    ~Player() { }

    public void Pickup(IItem item)
    {
        inventory.Add(item);
    }

    public virtual void Use(int index)
    {
        inventory[index].Use();
        
        
    }


}

interface IItem
{
    public abstract void Use();
}

class Sword : IItem
{
    public Sword() { }
    ~Sword() { }

    public void Use()
    {
        Console.WriteLine("칼을 휘두른다");
    }
}

class Axe : IItem
{
    public Axe() { }
    ~Axe() { }

    public void Use()
    {
        Console.WriteLine("도끼를 휘두른다");
    }
}

class Portion : IItem
{
    public Portion() { }
    ~Portion() { }

    public void Use()
    {
        Console.WriteLine("포션을 먹는다");
    }


}



class Program
{
    static void Main(string[] args)
    {
        /*Player player = new Player();
        player.Pickup(new Portion());
        player.Use(0);*/

        try
        {
            Console.WriteLine("예외 처리 전");
            int a = 0;
            int b = 0;
            int c = a / b;
            Console.WriteLine("예외 처리 후");

        }
        catch (Exception ex)
        {
            //에러 발생 시
            Console.WriteLine("오류 : " + ex.Message);
            Console.WriteLine($"어디가 오류인지.. :{ex.StackTrace}");
        }finally
        {
            //에러 처리 후 무조건 해야하는 것
            Console.WriteLine("최종 처리...");
        }
        


    }
}

