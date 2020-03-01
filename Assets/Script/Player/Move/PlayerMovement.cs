using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float cXPosition = 0f;
    private GameObject Player;
    private Camera camera;
    
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Player = gameObject;
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            StartCoroutine("playerMove");
        }
    }
    
    IEnumerator playerMove()
    {
        Vector2 speed = Vector2.zero;

        Vector2 msPos = camera.ScreenToWorldPoint(Input.mousePosition);

        if (gameObject.transform.position.x < msPos.x)
        {
            while (gameObject.transform.position.x <= msPos.x)
            {
                if (gameObject.transform.position.x == msPos.x)
                    Debug.Log("OH");
                Player.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(msPos.x, gameObject.transform.position.y), Time.smoothDeltaTime * 2.5f);
                //Player.transform.position = Vector2.Lerp(gameObject.transform.position, new Vector2 (msPos.x, gameObject.transform.position.y), Time.smoothDeltaTime * 3f);
                //msPos.x += 0.1f;
                yield return null;
            }
        }
        else if (gameObject.transform.position.x > msPos.x)
        {
            while (gameObject.transform.position.x >= msPos.x)
            {
                if (gameObject.transform.position.x == msPos.x)
                    Debug.Log("OH");
                Player.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(msPos.x, gameObject.transform.position.y), Time.smoothDeltaTime * 3f);
                yield return null;
            }
        }
        
       // Debug.Log(msPos);
       // yield return null;
    }
}

