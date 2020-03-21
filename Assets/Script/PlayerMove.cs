using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public bool isClick = false;
    private Vector2 playPos;
    private Vector2 tarPos;
    public raykast ray;
    private Animator ani;
    public bool isAnime = false;
	// Use this for initialization
	void Start () {
        ray = GameObject.Find("RayCastObject").GetComponent<raykast>();
        ani = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isClick) {
            isClick = false;
            tarPos = ray.targetPos;
            
            StopAllCoroutines();
            StartCoroutine(Movement());
        }

    }

    IEnumerator Movement()
    {
        playPos = transform.position;
        if (gameObject.transform.position.x < tarPos.x)
        {
            aniState(false, false, true);
            while (gameObject.transform.position.x <= tarPos.x)
            {
                transform.position += Vector3.right * 2f * Time.deltaTime;
                if (gameObject.transform.position.x >= tarPos.x)
                {
                    isAnime = true;
                    aniState(false, true, false);
                }

                yield return null;
            }
        }
        else if (gameObject.transform.position.x > tarPos.x)
        {
            aniState(true, false, false);
            while (gameObject.transform.position.x >= tarPos.x)
            {

                transform.position += Vector3.left * 2f * Time.deltaTime;
                if (gameObject.transform.position.x <= tarPos.x)
                {
                    isAnime = true;
                    aniState(false, true, false);
                }
                yield return null;
            }
        }
    }

    void aniState(bool lWalk, bool Idle, bool rWalk)
    {
        ani.SetBool("LeftWalk", lWalk);
        ani.SetBool("Idle", Idle);
        ani.SetBool("RightWalk", rWalk);
    }

}
