using static ConsoleApp4.CodePractice;
//using System.Collections.Generic;
namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class CodePractice
    {
        #region 싱글톤 생성
        private CodePractice() { }
        private static CodePractice? instance = null;
        public static CodePractice Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CodePractice();
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// int 배열을 주면 앞 뒤 숫자를 비교하여 WASD 중 맞는 값을 저장하여 리턴
        /// </summary>
        /// <param name="numLog">int 배열</param>
        /// <returns></returns>
        public string WASD(int[] numLog)
        {
            /*
            [0, 1, 0, 10, 0, 1, 0, 10, 0, -1, -2, -1]
            "wsdawsdassw"
            "w" : 수에 1을 더한다.
            "s" : 수에 1을 뺀다.
            "d" : 수에 10을 더한다.
            "a" : 수에 10을 뺀다.
            numLog[0]에서부터 시작해 조작을 하면 numLog의 값과 순서대로 일치합니다. 따라서 "wsdawsdassw"를 return 합니다.
            */
            string answer = "";
            List<int> list = new List<int>(numLog);
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    break;
                }
                if (list[i] < list[i + 1])
                {
                    if (list[i] + 2 < list[i + 1])
                    {
                        answer += "d";

                    }
                    else
                    {
                        answer += "w";
                    }

                }
                else if (list[i] > list[i + 1])
                {
                    if (list[i] - 2 > list[i + 1])
                    {
                        answer += "a";

                    }
                    else
                    {
                        answer += "s";
                    }
                }
            }
            return answer;
        }




    }


}
