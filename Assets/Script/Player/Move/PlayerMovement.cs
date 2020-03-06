using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private MouseEvent msEvent;
    private float cXPosition = 0f;
    private Camera camera;
    private Animator ani;
    

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ani = GetComponent<Animator>();
        ani.SetBool("Idle", true);
    }
    // Update is called once per frame
    void Update()
    {
        if (!msEvent.isTalk)
        {
            if (Input.GetMouseButtonDown(0) )
            {
                StopAllCoroutines();
                StartCoroutine("playerMove");
            }
        }
    }

    IEnumerator playerMove()
    {
        Vector2 speed = Vector2.zero;
        Vector2 msPos = camera.ScreenToWorldPoint(Input.mousePosition);

        if (gameObject.transform.position.x < msPos.x)
        {
            ani.SetBool("LeftWalk", false);
            ani.SetBool("Idle", false);
            ani.SetBool("RightWalk", true);   
            while (gameObject.transform.position.x <= msPos.x)
            { 
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
