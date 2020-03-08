using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour {
    private Vector3 mousePos;
    RaycastHit2D hit;
    [SerializeField]
    private PlayerMovement playermove;
    public bool isTalk = false;
    public bool isFly = false;
    public bool isMGame1 = false;
    public bool isGame = false;
    public bool isStart = false;
    public GameObject miniGame;
    private Camera camera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isFly)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Ray2D ray = new Ray2D(mousePos, Vector2.zero);
                hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit != false)
                {
                    if (hit.collider.tag == "samjok")
                    {
                        StartCoroutine(moveSamjokCoroutine());
                        isTalk = true;
                        isMGame1 = true;
                    }
                    else if (hit.collider.tag == "hopae" && isGame)
                    {
                        miniGame.SetActive(true);
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                isTalk = false;
            }
        }
    }

    IEnumerator moveSamjokCoroutine()
    {
        if (gameObject.transform.position.x < mousePos.x)
        {
            playermove.ani.SetBool("LeftWalk", false);
            playermove.ani.SetBool("Idle", false);
            playermove.ani.SetBool("RightWalk", true);
            while (gameObject.transform.position.x <= mousePos.x)
            {
                playermove.rigid.freezeRotation = false;
                transform.position += Vector3.right * 2f * Time.deltaTime;
                if (gameObject.transform.position.x >= mousePos.x - 0.1f)
                {
                    playermove.ani.SetBool("RightWalk", false);
                    playermove.ani.SetBool("Idle", true);
                }

                yield return null;
            }
        }
        else if (gameObject.transform.position.x > mousePos.x)
        {

            playermove.ani.SetBool("RightWalk", false);
            playermove.ani.SetBool("Idle", false);
            playermove.ani.SetBool("LeftWalk", true);
            while (gameObject.transform.position.x >= mousePos.x)
            {
                playermove.rigid.freezeRotation = false;
                transform.position += Vector3.left * 2f * Time.deltaTime;
                if (gameObject.transform.position.x <= mousePos.x + 0.1f)
                {
                    playermove.ani.SetBool("LeftWalk", false);
                    playermove.ani.SetBool("Idle", true);
                }
                yield return null;
            }
        }
    }
}
