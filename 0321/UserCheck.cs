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
            alertText.text = $"���̵�� ��й�ȣ �Է� �ٶ�.. ��� {count}ȸ..";
            if (count > 10)
            {
                alertText.text = "�� �� �� ���� �� ���� ȭ������ ���ϴ�";
                if (count == 12)
                {
                    SceneManager.LoadScene("Title");
                }
            }
        }
        else
        {
            Debug.Log("�α��� �õ�..");
            FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                //�½�ũ�� ������ ���
                if (task.IsFaulted)
                {
                    //������ ���� �ڵ鸵 �۾��� �����մϴ�
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
