using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raykast : MonoBehaviour
{
    [SerializeField]
    private StateManager state;
    public Vector2 targetPos;
    public RaycastHit2D hit;
    public PlayerMove playerScript;
    public talkScript ts;
    private GameObject playerObject;
    public GameObject hopae;
    public GameObject npc;

    void Start()
    {
        playerScript = GameObject.Find("player").GetComponent<PlayerMove>();
        ts = GameObject.Find("ScriptManager").GetComponent<talkScript>();
        state = GameObject.Find("StateManager").GetComponent<StateManager>();
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
                if (hit.collider.name == "npc" && !talkScript.story1)
                {
                    if (playerObject.transform.position.x <= hit.transform.position.x - 1.2f &&
                        playerObject.transform.position.x >= hit.transform.position.x + 1.2f)
                        ts.storyObj.SetActive(true);
                    else
                    {
                        targetPos = new Vector2(targetPos.x - 1f, targetPos.y);
                        playerScript.isClick = true;
                    }
                }
                else if (hit.collider.name == "Next_Button" && !talkScript.story1)   //나중에 미션2를 위해 수정해야 할듯
                {
                    ts.storyObj.SetActive(false);
                    talkScript.story1 = true;
                    if (talkScript.talkCount > 1)
                    {
                        npc.GetComponent<BoxCollider2D>().enabled = false;
                        state.nextMap = true;
                        StartCoroutine(MoveNpc());
                    }
                }
                else if (hit.collider.tag == "hopae" && talkScript.story1)
                {
                    state.isMove = false;
                    talkScript.story1 = false;
                    StartCoroutine(FadewaitTime());
                }
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

    //npc 움직이는거
    IEnumerator MoveNpc()
    {
        while (npc.transform.position.x < 3.723)
        {
            npc.transform.position += Vector3.right * 1f * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator FadewaitTime()
    {
        //호패를 부모에게서 떼어냄
        hopae.transform.parent = null;
        // 플레이어가 호패클릭했을때 멈추고 정면보기
        playerScript.StopAllCoroutines();
        playerScript.aniState(false, true, false);
        hopae.SetActive(false);
        hopae.transform.position = new Vector3(0, 0, 0);
        hopae.transform.localScale = new Vector3(2, 2, 1);
        hopae.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        hopae.SetActive(true);
        hopae.GetComponent<SpriteFadeIn>().enabled = true;
        yield return new WaitForSeconds(3f);
        hopae.GetComponent<SpriteFadeIn>().enabled = false;
        yield return new WaitForSeconds(1f);
        /*
         * 맘에 안들면 아래 두줄 지우고
         * 시작
         */

        if (talkScript.talkCount < talkScript.storyTalk.Length)
            (ts.storyObj.transform.GetChild(2).GetChild(0).
                            GetComponent<Text>().text) = talkScript.storyTalk[talkScript.talkCount++];

        hopae.GetComponent<SpriteFadeOut>().enabled = true;
        yield return new WaitForSeconds(3f);
        Destroy(hopae);
        state.isMove = true;

    }
}
