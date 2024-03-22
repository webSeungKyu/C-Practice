using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

//����Ƽ���� ����� �� �ִ� �븮�� ����
//1. Action : ����Ƽ���� ��ȯ ���� ���� ���� void ������ �븮��
//2. Func : ����Ƽ���� ��ȯ ���� �ִ� ������ �븮��
//3. UnityEvent : �ν����Ϳ��� �̺�Ʈ�� ���� ����, �Ҵ��� �� �ְ� ���ִ� ����
public class UnityDelegate : MonoBehaviour
{
    #region Action
    Action testAction01;

    void Method01() { }
    void Method02() { }
    void Method03() { }
    int Method04() { return 1; }

    Action<int> testAction02; // �׼��� <> �ȿ� �ִ� ���� delegate�� ȣ���� �Լ��� �Ű������Դϴ�

    void Method05(int i) { }
    void Method06(int i) { }
    void Method07(int i) { }
    #endregion
    #region Func
    Func<bool> testFunc01;

    bool Method08() { return true; }
    bool Method09() { return false; }

    Func<int, int, int> testFunc02;
    //�� �������� ������� Ÿ�� int�� return Ÿ��
    //�� �տ� ������ ��� �Ű����� ó���մϴ�

    int Method10(int a, int b) { return a + b; }
    int Method11(int a, int b) { return a - b; }


    #endregion
    #region UnityEvent
    public UnityEvent onDead;

    public void Awake()
    {
        onDead.AddListener(Dead); //��ũ��Ʈ�� ���� onDead��  �̺�Ʈ �Լ� ���
    }
    void Dead()
    {
        Debug.Log("�׾���");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            onDead?.Invoke();
        }
    }
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        #region Action
        testAction01 += Method01;
        testAction01 += Method02;
        testAction01 += Method03;
        //testAction01 += Method04; ���� > 04�� ��ȯ ���� ����
        testAction02 += Method05;
        testAction02 += Method06;
        testAction02 += Method07;
        testAction02(10); // �븮�� ȣ��
        testAction02?.Invoke(5); // �븮���� Invoke ��� ����
        //�Ʒ��� �ڵ�� ?�� ���� NULL üũ�� ������ �� �־� NullReferenceException�� ����
        //��Ȳ�� ���� �� �ֽ��ϴ�
        #endregion
        #region Func
        testFunc01 += Method08;
        testFunc01 += Method09;

        if(testFunc01?.Invoke() == true)
        {
            Debug.Log("�۾� ����");
        }

        testFunc02 += Method10;
        testFunc02 += Method11;
        Debug.Log(testFunc02?.Invoke(1, 2));
        #endregion
    }

}
