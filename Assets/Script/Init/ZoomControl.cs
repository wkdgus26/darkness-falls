using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour {

    public float zoomSize = 5.4f;
    public GameObject target;
    private Vector3 TargetPos;
    //public Camera camera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        {
            TargetPos = new Vector3(
                 Mathf.Clamp(target.transform.position.x, -9.71f, 5.88f),
                 Mathf.Clamp(target.transform.position.y, -4.01f, 1.27f),
                 -10f);
            if (Input.GetKeyDown("1"))
            {
                StartCoroutine(ZoomInCoroutine());
            }
            if (Input.GetKeyDown("2"))
            {
                if (zoomSize < 10)
                {
                    zoomSize += 1f;
                }
            }
            GetComponent<Camera>().orthographicSize = zoomSize;
        }
    }

    IEnumerator ZoomInCoroutine()
    {
        int count=0;
        
        while (count <500)
        {
            if (count < 100)
            { transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime / 3f); }
            else if (count < 200)
            { transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime / 2f); }
            else
            { transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime); }
            
            if (zoomSize > 2)
            {
                zoomSize -= Time.deltaTime;
            }
            count += 1;
            yield return null;
        }
        transform.position = TargetPos;
        
    }
}
