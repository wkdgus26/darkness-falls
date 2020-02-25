using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour {
    private Vector3 mousePosition;
    private Vector3 objPosition;
    public float dis = -5f;
	void OnMouseDrag()
    {
        mousePosition = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, dis);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(objPosition);
        }
    }

    
}
