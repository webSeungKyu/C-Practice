namespace GamePlay
{
    public class GamePlay
    {
/*        static void GenericClassTest<T, Y>(T a, Y b) where T : Monster
        {
            a.Move();
            Console.WriteLine(b);
        }*/

        static void Main(string[] args)
        {

/*            GenericClassTest(new Slime(), new Goblin());
            return;
            List<Monster> list = new List<Monster>();*/

            int monsterCount = new Random().Next(1, 11);
            /*Monster[] monsters = new Monster[monsterCount];*/
            List<Monster> monsterList = new List<Monster>();

            for (int i = 0; i < monsterCount; i++)
            {
                int temp = new Random().Next(1, 4);
                switch (temp)
                {
                    case 1:
                        monsterList.Add(new Slime());
                        break;
                    case 2:
                        monsterList.Add(new Goblin());
                        break;
                    case 3:
                        monsterList.Add(new Boar());
                        break;
                }
            }

            foreach (Monster monster in monsterList)
            {
                monster.Move();
            }
            Console.WriteLine("================");
            foreach (var i in monsterList)
            {
                i.Move();
            }

            Dictionary<int, string> wp = new Dictionary<int, string>();
            wp.Add(1, "knife");
            wp[3] = "gun";
            wp[322] = "sword";
            wp.Add(5,"gunAndSword");
            wp.Add(6, monsterList[0].ToString());
            wp.Add(7, Convert.ToString(monsterList[0]));


            foreach (var i in wp)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("==========");
            Dictionary<int, string> wp2 = new Dictionary<int, string>();
            for (int i = 0; i < monsterList.Count ; i++)
            {
                wp2.Add(i, monsterList[i].ToString());
                Console.WriteLine(wp2[i]);
            }
            Console.WriteLine($"wp2 사이즈 === : {wp2.Count}");
            foreach (var i in wp2)
            {
                Console.WriteLine(i);
            }


        }

    }
}
