using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionScript : MonoBehaviour {
    public GameObject[] fade;
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "player")
        {
            if(talkScript.story1)
            {
                fade[0].SetActive(true);
                StartCoroutine(fadeTime());
                GameObject.Find("player").transform.position = new Vector3(13.69f, -3.26f, 0);
                Camera.main.transform.position = new Vector3(20.26f, 0, -10f);
                fade[0].SetActive(false);
                fade[1].SetActive(true);
                StopAllCoroutines();
                StartCoroutine(fadeTime());
                fade[1].SetActive(false);
            }
        }
    }
    IEnumerator fadeTime()
    {
        yield return new WaitForSecondsRealtime(3f);
    }
}
