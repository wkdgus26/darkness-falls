using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour {
    private string[] samTalk = { "큰일이다. 네게 전해줄 호패를 개울에 빠뜨렸어..", "앙 기모찌"};
    private int cnt = 0;
    private bool ist = false;
    [SerializeField]
    private GameObject talkText;
    [SerializeField]
    private MouseEvent msEvent;
    void Start()
    {
    }
    void Update()
    {
        if (msEvent.isTalk && cnt < samTalk.Length)
        {
            talkText.SetActive(true);
            if (msEvent.hit == true)
            {
                if (Input.GetMouseButtonDown(0))
                    ist = true;
                if (msEvent.hit.collider.tag == "next_button")
                {
                    if (ist)
                    {
                        cnt++;
                        if (cnt < samTalk.Length)
                        {
                            talkText.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = samTalk[cnt];
                            ist = false;
                        }
                    }
                }
            }
        }
        else if (cnt >= samTalk.Length)
        {
            msEvent.isTalk = false;
            talkText.SetActive(false);
        }
    }
}
