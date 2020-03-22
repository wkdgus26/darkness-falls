using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkScript : MonoBehaviour {
    public static bool story1 = false;
    public static string[] storyTalk;
    public static byte talkCount = 1;
    public GameObject storyObj;
    void Start()
    {
        storyTalk = new string[2] {"호패를 보여라.", "상급 신선의 호패군. 들어가도 좋다." };
    }
}
