using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private RaycastHit2D hit;
    private Vector2 playPos;
    private Vector2 tarPos;
    private Camera cam;
    private Animator ani;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        ani = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            tarPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Ray2D ray = new Ray2D(tarPos, Vector2.zero);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            StopAllCoroutines();
            StartCoroutine(Movement());
        }
	}

    IEnumerator Movement()
    {
        if (gameObject.transform.position.x < tarPos.x)
        {
            aniState(false, false, true);
            while (gameObject.transform.position.x <= tarPos.x)
            {

                transform.position += Vector3.right * 2f * Time.deltaTime;
                if (gameObject.transform.position.x >= tarPos.x)
                {
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
