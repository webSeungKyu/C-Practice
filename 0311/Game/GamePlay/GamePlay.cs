using System;
/*우리는 새로운 게임을 만들려고 합니다.
플레이어가 하나 있고 플레이어는 이동하고 공격할 수 있습니다.
이 세상에서는 몬스터가 3종 있습니다.
몬스터는 슬라임, 고블린, 멧돼지가 있습니다.
몬스터는 이동하고 공격을 할 수 있습니다. 공격을 많이 받으면
몬스터는 죽고 Gold를 남깁니다.*/
class GamePlay
{
    static void Main()
    {
        Slime slime = new Slime();
        Player player = new Player();
        Boar boar = new Boar();
        Goblin goblin = new Goblin();
    }
}