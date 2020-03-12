using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopaeController : MonoBehaviour {

    private CircleCollider2D hopCol;
    [SerializeField]
    private GameObject player;
	// Use this for initialization
	void Start () {
        hopCol = gameObject.GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("map"))
        {
            StartCoroutine(delayCoroutine());
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void hopaeMove()
    {
        StartCoroutine(moveCoroutine());
    }

    IEnumerator moveCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        float count = 0;
        while (count < 100)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
            yield return null;
            count++;
        }
        
    }

    IEnumerator delayCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        hopCol.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

}
