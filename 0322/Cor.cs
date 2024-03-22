using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Cor : MonoBehaviour
{
    public Text myText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextGoGo("축하합니다! 100번째 유저입니다!\n이벤트에 당첨되었습니다!"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TextGoGo(string text)
    {
        myText.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            myText.text += text[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
