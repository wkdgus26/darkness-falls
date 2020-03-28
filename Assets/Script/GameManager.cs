using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private StateManager state;
    public talkScript ts;
    private GameObject playerObject;
    public raykast ray;
    public PlayerMove playerScript;
    public GameObject hopae;
    public GameObject npc;
    // Use this for initialization
    void Start () {
        //ts = GameObject.Find("ScriptManager").GetComponent<talkScript>();
        //state = GameObject.Find("StateManager").GetComponent<StateManager>();
        playerObject = GameObject.Find("player");
        //playerScript = GameObject.Find("player").GetComponent<PlayerMove>();
    }
	
	// Update is called once per frame
	void Update () {

        if (ray.hit == true)
        {
            if (ts.story1) // 첫번째 스토리
            {
                Debug.Log(ray.targetPos);
                if (ray.hit.collider.tag == "npc" && !talkScript.isStory)
                {
                    if (playerObject.transform.position.x <= ray.hit.transform.position.x - 1.2f &&
                        playerObject.transform.position.x >= ray.hit.transform.position.x + 1.2f)
                        ts.storyObj.SetActive(true);
                    else
                    {
                        playerScript.isClick = true;
                    }
                }
                else if (ray.hit.collider.name == "Next_Button" && !talkScript.isStory)   //나중에 미션2를 위해 수정해야 할듯
                {
                    ts.storyObj.SetActive(false);
                    talkScript.isStory = true;

                    if (talkScript.talkCount > 1)
                    {
                        npc.GetComponent<BoxCollider2D>().enabled = false;
                        talkScript.isStory = false;
                        state.nextMap = true;
                        ts.story1 = false;
                        talkScript.talkCount = 0;
                        StartCoroutine(MoveNpc());
                    } 
                    else if (talkScript.talkCount < talkScript.storyTalk1.Length)
                        (ts.storyObj.transform.GetChild(2).GetChild(0).
                                        GetComponent<Text>().text) = talkScript.storyTalk1[talkScript.talkCount++];
                }
                else if (ray.hit.collider.tag == "hopae" && talkScript.isStory)
                {
                    state.isMove = false;
                    StartCoroutine(FadewaitTime());
                }
            }

            else if (!ts.story1) // 두번째 스토리
            {
                Debug.Log(talkScript.talkCount);
                if (ray.hit.collider.tag == "npc" && !talkScript.isStory)
                {
                    ts.storyObj.SetActive(true);
                    if (playerObject.transform.position.x <= ray.hit.transform.position.x - 2f &&
                        playerObject.transform.position.x >= ray.hit.transform.position.x + 2f)
                    {
                        Debug.Log("2");
                        //ts.storyObj.SetActive(true);
                    }
                    else
                    {
                        playerScript.isClick = true;
                    }

                    (ts.storyObj.transform.GetChild(2).GetChild(0).
                                    GetComponent<Text>().text) = talkScript.storyTalk2[talkScript.talkCount];
                }

                else if (ray.hit.collider.name == "Next_Button" && !talkScript.isStory)   //나중에 미션2를 위해 수정해야 할듯
                {
                    //ts.storyObj.SetActive(false);
                    //talkScript.isStory = true;
                    if (talkScript.talkCount > 3)
                    {
                        npc.GetComponent<BoxCollider2D>().enabled = false;
                        state.nextMap = true;
                        ts.story1 = false;
                    }
                    if (talkScript.talkCount < talkScript.storyTalk2.Length)
                        (ts.storyObj.transform.GetChild(2).GetChild(0).
                                        GetComponent<Text>().text) = talkScript.storyTalk2[talkScript.talkCount++];
                }
            }
        }
        if (playerScript.isAnime && !talkScript.isStory)
        {

            ts.storyObj.SetActive(true);
            playerScript.isAnime = false;
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
        hopae.GetComponent<SpriteFadeOut>().enabled = true;
        yield return new WaitForSeconds(3f);
        talkScript.isStory = false;
        Destroy(hopae);
        state.isMove = true;
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
}
