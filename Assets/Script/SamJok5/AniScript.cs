using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScript : MonoBehaviour {
    private Animator ani;
    private bool stat = false;
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Breathe"))
        {
            // Do something
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Debug.Log("false");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EventTrig1")) {
            ani.SetBool("Landing", true);
            stat = true;
        }else if (other.gameObject.CompareTag("EventTrig2"))    //삼족오가 호패 떨어트릴때
        {
            GameObject ob = transform.GetChild(0).gameObject;
            ob.SetActive(true);
            ob.transform.parent = null;
            ob.transform.position = Vector3.Lerp(ob.transform.position, 
                new Vector3(ob.transform.position.x, -4f, 0), 
                Time.deltaTime * 1f);

        }
    }
}
