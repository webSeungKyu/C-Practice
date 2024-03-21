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
            alertText.text = $"아이디와 비밀번호 입력 바람.. 경고 {count}회..";
            if (count > 10)
            {
                alertText.text = "한 번 더 누를 시 이전 화면으로 갑니다";
                if (count == 12)
                {
                    SceneManager.LoadScene("Login");
                }
            }


        }else
        {
            if(pw.text != pw2.text)
            {
                alertText.text = $" 비밀번호가 서로 다름.. 다시 입력 바람....";
            }
            else
            {
                var reference = FirebaseDatabase.DefaultInstance.RootReference;
                User user = new User(id.text, pw.text);
                string userJson = JsonUtility.ToJson(user);
                reference.Child("users").Child(id.text).SetRawJsonValueAsync(userJson);
                Debug.Log(" 회원가입 성공 ");
                alertText.text = "회원가입에 성공하였습니다.. 3초 뒤 로그인 창으로 이동합니다..";

                SceneManager.LoadScene("Login");

            }
        }





    }


}


