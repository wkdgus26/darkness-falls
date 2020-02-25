using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLight : MonoBehaviour {

    RaycastHit2D hit;
    private Vector3 mousePosition;
    private Vector3 lightPosition;
    private Vector3 rockPosition;
    [SerializeField]
    private float dis = 6.2f;
    private int limit = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dis);
        lightPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = lightPosition;
        Debug.DrawRay(transform.position, Vector3.forward *10f, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (limit == 0)
            {
                Ray2D ray = new Ray2D(lightPosition, Vector2.zero);
                hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider.tag == "rock")
                {
                    Debug.Log("돌");
                    rockPosition = hit.transform.position;
                    hit.transform.position = new Vector2(hit.transform.position.x - 0.3f, hit.transform.position.y + 0.3f);
                    hit.transform.rotation = Quaternion.Euler(0, 0, 5f);
                    limit++;
                }
            }
            else if (limit != 0)
            {
                hit.transform.position = rockPosition;
                hit.transform.rotation = Quaternion.Euler(0, 0, 0f);
                limit--;
            }
        }
	}
}
