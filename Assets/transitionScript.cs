using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*내최선이다 시부랄거 더좋은코드있으면 해주셈*/
public class transitionScript : MonoBehaviour {
    public StateManager state;
    public GameObject[] fade;
    private bool isTransition = false;
    private bool isDelay = false;
    private float delay=0;
	// Update is called once per frame
	void Update () {
        Transition();
        Delay();
	}

    void Delay()
    {
        if (isDelay)
            delay += Time.deltaTime;
    }
    void Transition()
    {
        if (delay > 3 && isTransition)
        {
            isDelay = false;
            isTransition = false;
            delay = 0;
            GameObject.Find("player").transform.position = new Vector3(13.69f, -3.26f, 0);
            Camera.main.transform.position = new Vector3(20.26f, 0, -10f);
            fade[0].SetActive(false);
            fade[1].SetActive(true);
            GameObject.Find("player").transform.GetComponent<SpriteRenderer>().sortingOrder = 4;
            //StopAllCoroutines();
            //StartCoroutine(fadeTime());
            //fade[1].SetActive(false);
        }
        else if (delay > 3)
        {
            isDelay = false;
            delay = 0;
            fade[1].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (state.nextMap)
            {
                fade[0].SetActive(true);
                isDelay = true;
                isTransition = true;
                //StartCoroutine(fadeTime());
            }
        }
    }

    //IEnumerator fadeTime()
    //{
    //    yield return new WaitForSeconds(3f);
    //    isTransition = true;
    //}
    
}
