using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private ParabolaController pc;
    
    [SerializeField]
    private GameObject hopae;
    [SerializeField]
    private MouseEvent msEvent;
    public GuideManager gManager;

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
        if (transform.position.x < -9.5f && transform.position.x > -10.2f) 
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
        msEvent.isFly = false;
        gManager.isGuide = true;
        gManager.gNum++;
        gManager.time = 0;
    }
}
