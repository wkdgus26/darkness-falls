using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkList : MonoBehaviour {
	private Queue<string> textList;

	// Use this for initialization
	void Start () {
		textList = new Queue<string>();
	}
}
