using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raykast : MonoBehaviour {
    public Vector2 targetPos;
    public RaycastHit2D hit;
    public PlayerMove playerScript;
    public talkScript ts;
    private GameObject playerObject;
    public GameObject hopae;

    void Start()
    {
        playerScript = GameObject.Find("player").GetComponent<PlayerMove>();
        ts = GameObject.Find("GameManager").GetComponent<talkScript>();
        playerObject = GameObject.Find("player");
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
            if(hit == true)
            {
                if(hit.collider.name == "npc" && !talkScript.story1)
                {
                    if(playerObject.transform.position.x <= hit.transform.position.x - 1.2f &&
                        playerObject.transform.position.x >= hit.transform.position.x + 1.2f)
                        ts.storyObj.SetActive(true);
                    else
                    {
                        targetPos = new Vector2(targetPos.x - .5f, targetPos.y);
                        playerScript.isClick = true;
                    }
                }
                if(hit.collider.name == "Next_Button" && !talkScript.story1)
                {
                    if (talkScript.talkCount >= talkScript.storyTalk.Length)
                    {
                        ts.storyObj.SetActive(false);
                        talkScript.story1 = true;
                    }
                    else
                    {
                        //호패를 부모에게서 떼어냄
                        hopae.transform.parent = null;
                        hopae.SetActive(false);
                        hopae.transform.position = new Vector3(0, 0, 0);
                        hopae.transform.localScale = new Vector3(2, 2, 1);
                        StartCoroutine(FadewaitTime());
                        

                        
                    }
                }
                else
                {
                    playerScript.isAnime = false;
                }
            }
            else
            {
                playerScript.isAnime = false;
            }
        }
        /*
         * 
         * playerObject.transform.position.x <= hit.transform.position.x - 1.2f &&
         * playerObject.transform.position.x >= hit.transform.position.x + 1.2f
        */
        if (playerScript.isAnime && !talkScript.story1)
        {

            ts.storyObj.SetActive(true);
            playerScript.isAnime = false;
        }
    }
    IEnumerator FadewaitTime()
    {
        hopae.SetActive(true);
        hopae.GetComponent<SpriteFadeIn>().enabled = true;
        yield return new WaitForSeconds(3f);
        hopae.GetComponent<SpriteFadeIn>().enabled = false;
        hopae.GetComponent<SpriteFadeOut>().enabled = true;
        yield return new WaitForSeconds(3f);
        hopae.GetComponent<SpriteFadeOut>().gameObject.SetActive(false);
        Destroy(hopae);
        (ts.storyObj.transform.GetChild(2).GetChild(0).
                            GetComponent<Text>().text) = talkScript.storyTalk[talkScript.talkCount++];
    }
}
