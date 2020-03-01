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
    void Update()
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
                Player.transform.position += Vector3.right * 2f * Time.deltaTime;
                yield return null;
            }
        }
        else if (gameObject.transform.position.x > msPos.x)
        {
            while (gameObject.transform.position.x >= msPos.x)
            {
                Player.transform.position += Vector3.left * 2f * Time.deltaTime;
                yield return null;
            }
        }
    }
}
