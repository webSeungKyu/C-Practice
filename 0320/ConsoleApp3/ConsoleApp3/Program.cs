namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.MathClamp(40, 0, 80);
        }
    }

    public class Singleton
    {
        private Singleton() { }
        private static Singleton? instance = null;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        /// <summary>
        /// x가 min보다 작다면 min 출력
        /// x가 max보다 크다면 max 출력
        /// x가 min보다 작지도 크지도 않다면 x 출력
        /// </summary>
        /// <param name="x">검사가 필요한 값</param>
        /// <param name="min">최소값</param>
        /// <param name="max">최대값</param>
        public void MathClamp(int x, int min, int max)
        {
            Console.WriteLine(Math.Clamp(x, min, max));
        }
        

    }
}
