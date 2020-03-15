using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private MouseEvent msEvent;
    [SerializeField]
    private GameObject hopae;
    [SerializeField]
    private GameObject samjok;
    private BoxCollider2D sBCol;
    private CircleCollider2D hCCol;
    private Rigidbody2D hRigid;
    private float cXPosition = 0f;
    private Camera camera;
    private bool isT = false;
    public Animator ani;
    RaycastHit2D hit;
    public Rigidbody2D rigid;
    [SerializeField]
    private ScriptManager sM;
    [SerializeField]
    private SceneController sceneM;

    void Start()
    {
        sBCol = samjok.GetComponent<BoxCollider2D>();
        hCCol = hopae.GetComponent<CircleCollider2D>();
        hRigid = hopae.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ani = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Ray2D ray = new Ray2D(mousePos, Vector2.zero);
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit == true && (!msEvent.isMGame1 || msEvent.isMGameEnd))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.tag == "samjok" && !msEvent.isTalk)
                {
                    StopAllCoroutines();
                    if(hRigid == true) hRigid.gravityScale = 0;
                    StartCoroutine(moveSamjokCoroutine());
                }
            }
            
        }

        else if (!msEvent.isTalk && !msEvent.isFly && msEvent.isStart && !msEvent.isMStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopAllCoroutines();
                StartCoroutine("playerMove");
            }
            else if (gameObject.transform.rotation.z > 0.4 || gameObject.transform.rotation.z < -0.4)
            {
                rigid.freezeRotation = true;
                StartCoroutine("limitRotation");
            }
        }
        if(msEvent.isFly)
        {
            StopAllCoroutines();
            anistop(false, true, false);
        }
        
        if (msEvent.isMGame1 && sceneM.isChapEnd == false)
        {
            GameZone();
        }
    }
    
    private void GameZone()
    {
        if (transform.position.x < hopae.transform.position.x + 0.2f && transform.position.x > hopae.transform.position.x - 0.2f)
        {
            hCCol.enabled = true;
            msEvent.isGame = true;
        }
        else
        {
            hCCol.enabled = false;
            msEvent.isGame = false;
        }
    }
    IEnumerator playerMove()
    {
        Vector2 speed = Vector2.zero;
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        Ray2D ray = new Ray2D(mousePos, Vector2.zero);
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (msEvent.isMGame1 && hit != false)
        {

            if (hit.collider.tag == "mGame1")
            {
                rigid.freezeRotation = false;
                if (gameObject.transform.position.x < hopae.transform.position.x)
                {
                    anistop(false, false, true);
                    while (gameObject.transform.position.x <= hopae.transform.position.x)
                    {
                        transform.position += Vector3.right * 2f * Time.deltaTime;
                        if (gameObject.transform.position.x >= hopae.transform.position.x - 0.1f)
                        {
                            anistop(false, true, false);

                        }

                        yield return null;
                    }
                }

                else if (gameObject.transform.position.x > hopae.transform.position.x)
                {
                    anistop(true, false, false);
                    while (gameObject.transform.position.x >= hopae.transform.position.x)
                    {
                        transform.position += Vector3.left * 2f * Time.deltaTime;
                        if (gameObject.transform.position.x <= hopae.transform.position.x + 0.1f)
                        {
                            anistop(false, true, false);
                        }
                        yield return null;
                    }
                }
            }
        }

        else 
        {
            rigid.freezeRotation = false;
            if (gameObject.transform.position.x < mousePos.x)
            {
                anistop(false, false, true);
                while (gameObject.transform.position.x <= mousePos.x)
                {
                    
                    transform.position += Vector3.right * 2f * Time.deltaTime;
                    if (gameObject.transform.position.x >= mousePos.x - 0.1f)
                    {
                        anistop(false, true, false);
                    }

                    yield return null;
                }
            }
            else if (gameObject.transform.position.x > mousePos.x)
            {
                anistop(true, false, false);
                while (gameObject.transform.position.x >= mousePos.x)
                {
                    
                    transform.position += Vector3.left * 2f * Time.deltaTime;
                    if (gameObject.transform.position.x <= mousePos.x + 0.1f)
                    {
                        anistop(false, true, false);
                    }
                    yield return null;
                }
            }
        }
    }

    IEnumerator moveSamjokCoroutine()
    {
        rigid.freezeRotation = false;
        if (gameObject.transform.position.x < samjok.transform.position.x - 1.5f)
        {
            anistop(false, false, true);
            while (gameObject.transform.position.x <= samjok.transform.position.x - 1.5f)
            {
                
                transform.position += Vector3.right * 2f * Time.deltaTime;
                if (gameObject.transform.position.x >= samjok.transform.position.x - 1.6f)
                {
                    anistop(false, true, false);
                }

                yield return null;
            }

        }
        
        else if (gameObject.transform.position.x > samjok.transform.position.x - 1.5f)
        {
            anistop(true, false, false);
            while (gameObject.transform.position.x >= samjok.transform.position.x - 1.5f)
            {
                
                transform.position += Vector3.left * 2f * Time.deltaTime;
                if (gameObject.transform.position.x <= samjok.transform.position.x - 1.4f)
                {
                    anistop(false, false, true);
                }
                yield return null;
            }

        }
        
        sBCol.enabled = false;
        msEvent.isTalk = true;
        if (msEvent.isMGameEnd)
        {
            sceneM.isChapEnd = true;
            Debug.Log("samjok ani");
        }
        else
        {
            msEvent.isMGame1 = true;
        }
    }

    IEnumerator limitRotation()
    {
        if (gameObject.transform.rotation.z > 0.35)
        {
            while (gameObject.transform.rotation.z >= 0.35)
            {
                rigid.freezeRotation = false;
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(0, 0, 35f), Time.deltaTime);
                
                yield return null;
            }
        }
    }
    void anistop(bool l, bool i, bool r)
    {
        ani.SetBool("LeftWalk", l);
        ani.SetBool("Idle", i);
        ani.SetBool("RightWalk", r);
    }
}
