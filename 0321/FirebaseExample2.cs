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
     SetValueAsync() ���� ������ ������ �����͸� �����ϰ� �ش� ����� ���� �����ͷ� �����ϴ� �۾�
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
    /// �����ͺ��̽��� �л� Ŭ������ ���� ������ �߰��ϴ� �ڵ�
    /// </summary>
    /// <param name="_id">�л� ���� �ĺ� �ڵ�(�й�)</param>
    /// <param name="_name">�л� �̸�</param>
    /// <param name="_email">�л� �̸���</param>
    private void StudentRegister(string _id, string _name, string _email)
    {
        //1. Ŭ������ ���� ����
        Student student = new Student(_name, _email);

        //2. �ش� Ŭ������ Json ���·� �ٲ��ش� (string)
        string StudentJson = JsonUtility.ToJson(student);

        //3. ���۷����� �� ����
        reference.Child("students").Child(_id).SetRawJsonValueAsync(StudentJson);

        Debug.Log($"{_id} / {_name} / {_email} ");
    }

    private void StudentUpdate(string _id, string _name)
    {
        reference.Child("students").Child(_id).Child("sName").SetValueAsync(_name);
        Debug.Log("�̸��� ����Ǿ����ϴ�");

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
