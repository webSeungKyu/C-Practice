using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*
event(이벤트) : 개체에게 작업 실행을 알리기 위해 보내는 메세지
이벤트는 외부 가입자(Subscriber)에게 특정 일을 알려주는 기능을 가집니다.

Event Handler(이벤트 핸들러) : 구독자가 이벤트를 발생할 경우 어떤 명령을 실행할 지 지정해주는 것
+=을 통해 이벤트에 대한 추가가 가능하며, -=을 통해 이벤트를 제거하는 것도 가능합니다.
이벤트 발생 시 추가된 핸들러는 순차적으로 호출됩니다
 */

class ClickEvent
{
    public event EventHandler click;

    public void MouseButtonDown()
    {
        if (click != null)
        {
            click(this, EventArgs.Empty);
            //EventArgs 이벤트 받을 때 파라미터로 데이터를 받고 싶을 경우 해당 클래스를 상속받아 사용합니다
            //EventArgs는 이벤트 발생과 관련된 정보를 가지고 있습니다.
            //이벤트 핸들러가 사용하는 파라미터 값입니다
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
        Debug.Log("버튼 클릭");
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
