using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student
{
    public string sName;
    public string email;

    public Student(string sName, string email)
    {
        this.sName = sName;
        this.email = email;
    }

    public Dictionary<string, object> ToDictionay()
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        result["sName"] = sName;
        result["email"] = email;

        return result;
    }

    


    /*
     SetValueAsync() 통해 지정한 참조에 데이터를 저장하고 해당 경로의 기존 데이터로 변경하는 작업
     string, long, double, bool Dictionary<string, Object>, List<Object>
     */
}



public class FirebaseExample2 : MonoBehaviour
{
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

       // StudentRegister("240321_002", "Seung Kyu", "KingSeungKyu@King.com");
        StudentUpdate("240321_002", "UpdateKingKyu");
    }

    /// <summary>
    /// 데이터베이스에 학생 클래스에 대한 정보를 추가하는 코드
    /// </summary>
    /// <param name="_id">학생 고유 식별 코드(학번)</param>
    /// <param name="_name">학생 이름</param>
    /// <param name="_email">학생 이메일</param>
    private void StudentRegister(string _id, string _name, string _email)
    {
        //1. 클래스에 대한 생성
        Student student = new Student(_name, _email);

        //2. 해당 클래스를 Json 형태로 바꿔준다 (string)
        string StudentJson = JsonUtility.ToJson(student);

        //3. 레퍼런스에 값 설정
        reference.Child("students").Child(_id).SetRawJsonValueAsync(StudentJson);

        Debug.Log($"{_id} / {_name} / {_email} ");
    }

    private void StudentUpdate(string _id, string _name)
    {
        reference.Child("students").Child(_id).Child("sName").SetValueAsync(_name);
        Debug.Log("이름이 변경되었습니다");

    }


    void Sample()
    {
        Student s = new Student("a", "abc@abc.net");
        var sJson = JsonUtility.ToJson(s);
        Dictionary<string, object> update = s.ToDictionay();

        var key = reference.Child("students").Push().Key;
        reference.Child("students").Child("20004").SetRawJsonValueAsync(sJson);

    }
}
