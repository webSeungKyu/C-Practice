using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseExample : MonoBehaviour
{
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        //데이터 베이스에서 데이터를 읽는 방법
        //FirebaseDatabase에 대한 인스턴스가 요구됩니다

        WriteUserDataToDatabase("0", "Mcdonald's");
        WriteUserDataToDatabase("1", "Lotteria");
        WriteUserDataToDatabase("2", "BurgerKing");
        WriteUserDataToDatabase("3", "FrankBurger");
        WriteUserDataToDatabase("4", "KFC");
    }

    void WriteUserDataToDatabase(string _userId, string _userName)
    {
        //데이터베이스 쪽에 값을 전달해주는 기능
        reference.Child("users").Child(_userId).Child("userName").SetValueAsync(_userName);

        //실행 시 데이터 베이스에 다음과 같이 저장됩니다.
        //database 이름
        //users
        //> _userId > userName

        Debug.Log($"_userId / {_userId}, _userName / {_userName}이 데이터 베이스에 등록되었습니다");
    }

    void ReadUserDataToDatabase()
    {
        //데이터베이스에 저장되어 있는 값을 읽어내는 기능
        //파이어베이스로부터 인스턴스를 통해 값을 얻어옵니다 이 작업은 메인스레드에서 계속 작업을 진행합니다

        //이 코드에 대한 더 정확한 이해를 위해 알아둘 개념
        //1 스레드 프로세스 내에서 실행되는 흐름의 단위, 둘 이상 실행일 경우 멀티 쓰레드라고 부름
        //2. 태스크 : 스레드를 통한 비동기 작업에 사용되는 데이터
        //3 무명 메소드(annoymous method) : 주로 delegate 등에서 많이 사용되고 한 번 쓰고 다시 쓸 일 없는 기능에 대한 표현으로 사용함
        //4. 람다식(Lamda Experssion)
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            //태스크가 오류일 경우
            if (task.IsFaulted)
            {
                //오류에 대한 핸들링 작업을 진행합니다
            }
            else if (task.IsCompleted)
            {
                DataSnapshot dataSnapshot = task.Result;

                for (int i = 0; dataSnapshot.ChildrenCount > i; i++)
                {
                    Debug.Log(dataSnapshot.Child(i.ToString()).Child("userName").Value);
                }
            }
        });
    }
}
