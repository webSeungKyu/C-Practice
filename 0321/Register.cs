using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField id;
    public InputField pw;
    public InputField pw2;
    public Text alertText;
    int count;

    public void RegisterUser()
    {
        if (id.text.Equals("") || pw.text.Equals("") || pw2.text.Equals(""))
        {
            count++;
            alertText.text = $"���̵�� ��й�ȣ �Է� �ٶ�.. ��� {count}ȸ..";
            if (count > 10)
            {
                alertText.text = "�� �� �� ���� �� ���� ȭ������ ���ϴ�";
                if (count == 12)
                {
                    SceneManager.LoadScene("Login");
                }
            }


        }else
        {
            if(pw.text != pw2.text)
            {
                alertText.text = $" ��й�ȣ�� ���� �ٸ�.. �ٽ� �Է� �ٶ�....";
            }
            else
            {
                var reference = FirebaseDatabase.DefaultInstance.RootReference;
                User user = new User(id.text, pw.text);
                string userJson = JsonUtility.ToJson(user);
                reference.Child("users").Child(id.text).SetRawJsonValueAsync(userJson);
                Debug.Log(" ȸ������ ���� ");
                alertText.text = "ȸ�����Կ� �����Ͽ����ϴ�.. 3�� �� �α��� â���� �̵��մϴ�..";

                SceneManager.LoadScene("Login");

            }
        }





    }


}


