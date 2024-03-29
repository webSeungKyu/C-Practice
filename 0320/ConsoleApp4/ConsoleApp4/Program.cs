﻿using static ConsoleApp4.CodePractice;
//using System.Collections.Generic;
namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //03.20 오후 5시 41분까지 완료
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

        /// <summary>
        /// queries 의 첫번째 인덱스인 query[i,j]의 숫자가 0, 3 이라면, arr배열의 0번째 인덱스와 3번째 인덱스의 위치를 서로 바꾼다
        /// </summary>
        /// <param name="arr">위치가 바뀌는 개체이자, 기준정보</param>
        /// <param name="queries">query 의 집합체정보 (query를 묶은 정보일 뿐)</param>
        /// query : queries에 속해져있는 인덱스 별 개체 [i , j]
        /// <returns></returns>
        public int[] QueryChange(int[] arr, int[,] queries)
        {
            int[] answer = arr;
            int temp1;
            int temp2;
            for (int i = 0; i < queries.GetLength(0); i++)
            {
                temp1 = arr[queries[i, 0]];
                temp2 = arr[queries[i, 1]];
                arr[queries[i, 0]] = temp2;
                arr[queries[i, 1]] = temp1;
            }
            return answer;
        }




    }


}
