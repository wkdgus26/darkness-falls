using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private MouseEvent msEvent;
    [SerializeField]
    private GameObject hopae;
    [SerializeField]
    private TextManager textM;
    [SerializeField]
    private GameObject samjok;
    private CircleCollider2D hCCol;
    private Rigidbody2D hRigid;
    private float cXPosition = 0f;
    private Camera camera;
    private bool isT = false;
    public Animator ani;
    RaycastHit2D hit;
    public Rigidbody2D rigid;

    void Start()
    {
        hCCol = hopae.GetComponent<CircleCollider2D>();
        hRigid = hopae.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ani = GetComponent<Animator>();
        ani.SetBool("Idle", true);
    }
    // Update is called once per frame
    void Update()
    {
        if (msEvent.hit == true && !isT)
        {
            if (msEvent.hit.collider.tag == "samjok" && !msEvent.isTalk)
            {
                isT = true; 
                StopAllCoroutines();
                hRigid.gravityScale = 0;
                StartCoroutine(moveSamjokCoroutine());
            }
        }

        else if (!msEvent.isTalk && !msEvent.isFly && msEvent.isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("move");
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
            ani.SetBool("RightWalk", false);
            ani.SetBool("LefttWalk", false);
            ani.SetBool("Idle", true);
        }
        
        if (msEvent.isMGame1)
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
        Vector2 msPos = camera.ScreenToWorldPoint(Input.mousePosition);

        Ray2D ray = new Ray2D(msPos, Vector2.zero);
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (msEvent.isMGame1 && hit != false)
        {

            if (hit.collider.tag == "mGame1")
            {
                if (gameObject.transform.position.x < hopae.transform.position.x)
                {
                    ani.SetBool("LeftWalk", false);
                    ani.SetBool("Idle", false);
                    ani.SetBool("RightWalk", true);
                    while (gameObject.transform.position.x <= hopae.transform.position.x)
                    {rigid.freezeRotation = false;
                        transform.position += Vector3.right * 2f * Time.deltaTime;
                        if (gameObject.transform.position.x >= hopae.transform.position.x - 0.1f)
                        {
                            ani.SetBool("RightWalk", false);
                            ani.SetBool("Idle", true);
                        }

                        yield return null;
                    }
                }

                else if (gameObject.transform.position.x > hopae.transform.position.x)
                {

                    ani.SetBool("RightWalk", false);
                    ani.SetBool("Idle", false);
                    ani.SetBool("LeftWalk", true);
                    while (gameObject.transform.position.x >= hopae.transform.position.x)
                    {
                        transform.position += Vector3.left * 2f * Time.deltaTime;
                        if (gameObject.transform.position.x <= hopae.transform.position.x + 0.1f)
                        {
                            ani.SetBool("LeftWalk", false);
                            ani.SetBool("Idle", true);
                        }
                        yield return null;
                    }
                }
            }
        }

        else 
        {

            if (gameObject.transform.position.x < msPos.x)
            {
                ani.SetBool("LeftWalk", false);
                ani.SetBool("Idle", false);
                ani.SetBool("RightWalk", true);
                while (gameObject.transform.position.x <= msPos.x)
                {
                    rigid.freezeRotation = false;
                    transform.position += Vector3.right * 2f * Time.deltaTime;
                    if (gameObject.transform.position.x >= msPos.x - 0.1f)
                    {
                        ani.SetBool("RightWalk", false);
                        ani.SetBool("Idle", true);
                    }

                    yield return null;
                }
            }
            else if (gameObject.transform.position.x > msPos.x)
            {

                ani.SetBool("RightWalk", false);
                ani.SetBool("Idle", false);
                ani.SetBool("LeftWalk", true);
                while (gameObject.transform.position.x >= msPos.x)
                {
                    rigid.freezeRotation = false;
                    transform.position += Vector3.left * 2f * Time.deltaTime;
                    if (gameObject.transform.position.x <= msPos.x + 0.1f)
                    {
                        ani.SetBool("LeftWalk", false);
                        ani.SetBool("Idle", true);
                    }
                    yield return null;
                }
            }
        }
    }

    IEnumerator moveSamjokCoroutine()
    {
        Debug.Log("move samjok");
        if (gameObject.transform.position.x < samjok.transform.position.x - 1.5f)
        {
            ani.SetBool("LeftWalk", false);
            ani.SetBool("Idle", false);
            ani.SetBool("RightWalk", true);
            while (gameObject.transform.position.x <= samjok.transform.position.x - 1.5f)
            {
                rigid.freezeRotation = false;
                transform.position += Vector3.right * 2f * Time.deltaTime;
                if (gameObject.transform.position.x >= samjok.transform.position.x - 1.6f)
                {
                    //ani.SetBool("RightWalk", false);
                    //ani.SetBool("Idle", true);
                }

                yield return null;
            }
        }
        
        else if (gameObject.transform.position.x > samjok.transform.position.x - 1.5f)
        {

            ani.SetBool("RightWalk", false);
            ani.SetBool("Idle", false);
            ani.SetBool("LeftWalk", true);
            while (gameObject.transform.position.x >= samjok.transform.position.x - 1.5f)
            {
                rigid.freezeRotation = false;
                transform.position += Vector3.left * 2f * Time.deltaTime;
                if (gameObject.transform.position.x <= samjok.transform.position.x - 1.4f)
                {
                    ani.SetBool("LeftWalk", false);
                    ani.SetBool("RightWalk", true);
                    //ani.SetBool("Idle", true);
                }
                yield return null;
            }
        }
        msEvent.isTalk = true;

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
}
