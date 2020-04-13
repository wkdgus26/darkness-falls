using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raykast : MonoBehaviour
{

    public Vector2 targetPos;
    public RaycastHit2D hit;
    public PlayerMove playerScript;
    public talkScript ts;
    [SerializeField]
    private StateManager state;
    void Start()
    {
        playerScript = GameObject.Find("player").GetComponent<PlayerMove>();
        ts = GameObject.Find("ScriptManager").GetComponent<talkScript>();
    }
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            if(!ts.storyObj.activeSelf)
                playerScript.isClick = true;

            targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Ray2D ray = new Ray2D(targetPos, Vector2.zero);
            hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                if (hit.collider.tag == "npc")
                    targetPos = new Vector2(hit.transform.position.x - 1f, hit.transform.position.y);
            }
        }
        if (state.isHit == true) // 레이캐스트 초기화
        {
            targetPos = new Vector2(0, 0);
            Ray2D ray = new Ray2D(targetPos, Vector2.zero);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            state.isHit = false;
        }
        /*
         * 
         * playerObject.transform.position.x <= hit.transform.position.x - 1.2f &&
         * playerObject.transform.position.x >= hit.transform.position.x + 1.2f
        */

    }
}