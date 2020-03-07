using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour {
    private Vector3 mousePos;
    RaycastHit2D hit;
    public bool isTalk = false;
    public bool isFly = false;
    public bool isMGame1 = false;
    public bool isGame = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isFly)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Ray2D ray = new Ray2D(mousePos, Vector2.zero);
                hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit != false)
                {
                    if (hit.collider.tag == "samjok")
                    {
                        Debug.Log("samjok5 hi");
                        isTalk = true;
                    }
                    else if (hit.collider.tag == "hopae")
                    {
                        Debug.Log("hopae hi");
                    }
                }
            }
        }
    }
}
