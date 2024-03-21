using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserCheek : MonoBehaviour
{
    public InputField id;
    public InputField pw;
    public Text alertText;
    int count;



    public void Login()
    {
        if (id.text.Equals("") || pw.text.Equals(""))
        {
            count++;
            alertText.text = $"아이디와 비밀번호 입력 바람.. 경고 {count}회..";
            if (count > 10)
            {
                alertText.text = "한 번 더 누를 시 이전 화면으로 갑니다";
                if (count == 12)
                {
                    SceneManager.LoadScene("Title");
                }
            }
        }
        else
        {
            Debug.Log("로그인 시도..");
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


                        Debug.Log(
                        dataSnapshot.Child(i.ToString()).Child("id").Value.ToString()
                        );

                    }
                }
            });
        }



    }


}
