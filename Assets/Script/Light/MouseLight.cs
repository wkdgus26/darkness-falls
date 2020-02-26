using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLight : MonoBehaviour {

    RaycastHit2D hit;
    private Vector3 mousePosition;
    private Vector3 lightPosition;
    private Vector3 rockPosition;
    [SerializeField]
    private float dis = 5f;
    private int limit = 0;
    private int selecLayer = 5;
    private int beforeLayer = 0;
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
                if (hit.collider.tag == "rock" || hit.collider.tag == "keyRock")
                {
                    Debug.Log("돌");
                    rockPosition = hit.transform.position;
                    beforeLayer = hit.transform.GetComponent<SpriteRenderer>().sortingOrder;
                    hit.transform.position = new Vector2(hit.transform.position.x - 0.9f, hit.transform.position.y + 0.9f);
                    hit.transform.rotation = Quaternion.Euler(0, 0, 5f);
                    hit.transform.GetComponent<SpriteRenderer>().sortingOrder = selecLayer;
                    limit++;
                }

            }
            else if (limit != 0)
            {
                if (hit.collider.tag == "rock")
                {
                    hit.transform.position = rockPosition;
                    hit.transform.rotation = Quaternion.Euler(0, 0, 0f);
                    hit.transform.GetComponent<SpriteRenderer>().sortingOrder = beforeLayer;
                    limit--;
                }
            }
        }
	}
}
