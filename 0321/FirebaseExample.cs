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
        //������ ���̽����� �����͸� �д� ���
        //FirebaseDatabase�� ���� �ν��Ͻ��� �䱸�˴ϴ�

        WriteUserDataToDatabase("0", "Mcdonald's");
        WriteUserDataToDatabase("1", "Lotteria");
        WriteUserDataToDatabase("2", "BurgerKing");
        WriteUserDataToDatabase("3", "FrankBurger");
        WriteUserDataToDatabase("4", "KFC");
    }

    void WriteUserDataToDatabase(string _userId, string _userName)
    {
        //�����ͺ��̽� �ʿ� ���� �������ִ� ���
        reference.Child("users").Child(_userId).Child("userName").SetValueAsync(_userName);

        //���� �� ������ ���̽��� ������ ���� ����˴ϴ�.
        //database �̸�
        //users
        //> _userId > userName

        Debug.Log($"_userId / {_userId}, _userName / {_userName}�� ������ ���̽��� ��ϵǾ����ϴ�");
    }

    void ReadUserDataToDatabase()
    {
        //�����ͺ��̽��� ����Ǿ� �ִ� ���� �о�� ���
        //���̾�̽��κ��� �ν��Ͻ��� ���� ���� ���ɴϴ� �� �۾��� ���ν����忡�� ��� �۾��� �����մϴ�

        //�� �ڵ忡 ���� �� ��Ȯ�� ���ظ� ���� �˾Ƶ� ����
        //1 ������ ���μ��� ������ ����Ǵ� �帧�� ����, �� �̻� ������ ��� ��Ƽ �������� �θ�
        //2. �½�ũ : �����带 ���� �񵿱� �۾��� ���Ǵ� ������
        //3 ���� �޼ҵ�(annoymous method) : �ַ� delegate ��� ���� ���ǰ� �� �� ���� �ٽ� �� �� ���� ��ɿ� ���� ǥ������ �����
        //4. ���ٽ�(Lamda Experssion)
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
                    Debug.Log(dataSnapshot.Child(i.ToString()).Child("userName").Value);
                }
            }
        });
    }
}
