using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*
event(�̺�Ʈ) : ��ü���� �۾� ������ �˸��� ���� ������ �޼���
�̺�Ʈ�� �ܺ� ������(Subscriber)���� Ư�� ���� �˷��ִ� ����� �����ϴ�.

Event Handler(�̺�Ʈ �ڵ鷯) : �����ڰ� �̺�Ʈ�� �߻��� ��� � ����� ������ �� �������ִ� ��
+=�� ���� �̺�Ʈ�� ���� �߰��� �����ϸ�, -=�� ���� �̺�Ʈ�� �����ϴ� �͵� �����մϴ�.
�̺�Ʈ �߻� �� �߰��� �ڵ鷯�� ���������� ȣ��˴ϴ�
 */

class ClickEvent
{
    public event EventHandler click;

    public void MouseButtonDown()
    {
        if (click != null)
        {
            click(this, EventArgs.Empty);
            //EventArgs �̺�Ʈ ���� �� �Ķ���ͷ� �����͸� �ް� ���� ��� �ش� Ŭ������ ��ӹ޾� ����մϴ�
            //EventArgs�� �̺�Ʈ �߻��� ���õ� ������ ������ �ֽ��ϴ�.
            //�̺�Ʈ �ڵ鷯�� ����ϴ� �Ķ���� ���Դϴ�
        }
    }
}

public class UnityEventExample : MonoBehaviour
{
    ClickEvent clickEvent;
    // Start is called before the first frame update
    void Start()
    {
        ClickEvent clickEvent = new ClickEvent();
        clickEvent.click += new EventHandler(ButtonClick);
    }

    void ButtonClick(object sender, EventArgs e)
    {
        Debug.Log("��ư Ŭ��");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            clickEvent.MouseButtonDown();
        }
    }
}
