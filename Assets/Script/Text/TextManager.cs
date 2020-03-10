using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {

    [SerializeField]
    private MouseEvent msEvent;
    [SerializeField]
    private GameObject textPop;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Talk();

    }

    public void Talk()
    {
        if (msEvent.isTalk)
        {
            textPop.SetActive(true);
            if (msEvent.hit == true)
            {
                if (msEvent.hit.collider.tag == "next_button")
                {
                    Debug.Log("Next Button!");
                }
            }
        }
        
    }
}
