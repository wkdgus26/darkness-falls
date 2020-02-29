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
            StartCoroutine("playerMove");
        

    }
    
    IEnumerator playerMove()
    {
        Vector2 speed = Vector2.zero;

        Vector2 msPos = camera.ScreenToWorldPoint(Input.mousePosition);
        while (gameObject.transform.position.x <= msPos.x)
        {

            if (gameObject.transform.position.x == msPos.x)
                Debug.Log("OH");
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position
                    , msPos, Time.smoothDeltaTime * 3f);
            msPos.x += 0.1f;
            yield return null;
        }
        
    }
}

