using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raykast : MonoBehaviour {
    public Vector2 targetPos;
    public RaycastHit2D hit;
    public PlayerMove playerScript;
    public talkScript tscript;
    private GameObject playerObject;
    void Start()
    {
        playerScript = GameObject.Find("player").GetComponent<PlayerMove>();
        tscript = GameObject.Find("GameManager").GetComponent<talkScript>();
        playerObject = GameObject.Find("player");
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if(!tscript.storyObj.activeSelf)
                playerScript.isClick = true;

            targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Ray2D ray = new Ray2D(targetPos, Vector2.zero);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit == true)
            {
                if(hit.collider.name == "npc" && !tscript.story1)
                {
                    if(playerObject.transform.position.x <= hit.transform.position.x - 1.2f &&
                        playerObject.transform.position.x >= hit.transform.position.x + 1.2f)
                        tscript.storyObj.SetActive(true);
                    else
                    {
                        Debug.Log((playerObject.transform.position.x) + " " + hit.transform.position.x);
                        playerScript.isClick = true;
                        targetPos = new Vector2(targetPos.x - 1f, targetPos.y);
                    }
                }
                if(hit.collider.name == "Next_Button" && !tscript.story1)
                {
                    if (tscript.talkCount >= tscript.storyTalk.Length)
                    {
                        tscript.storyObj.SetActive(false);
                        tscript.story1 = true;
                    }
                    else
                    {
                        (tscript.storyObj.transform.GetChild(2).GetChild(0).
                            GetComponent<Text>().text) = tscript.storyTalk[tscript.talkCount++];
                    }
                }
            }
        }
        if (playerScript.isAnime && !tscript.story1)
        {
            tscript.storyObj.SetActive(true);
            playerScript.isAnime = false;
        }
    }
}
