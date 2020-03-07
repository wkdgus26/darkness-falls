using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private ParabolaController pc;
    
    [SerializeField]
    private GameObject hopae;
    [SerializeField]
    private MouseEvent msEvent;

    // Use this for initialization
    void Start () {
        msEvent.isFly = true;
        pc = GetComponent<ParabolaController>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            pc.ParabolaRoot = GameObject.Find("ParabolaRoot2");
        }
        if (transform.position.x < -6.5f && transform.position.x > -7.2f) 
        {
            hopae.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EventTrig1"))
        {
            
            StartCoroutine(delayCoroutine());
        }
    }

    IEnumerator delayCoroutine()
    {
        yield return new WaitForSeconds(1f);
        msEvent.isMGame1 = true;
        msEvent.isFly = false;
    }
}
