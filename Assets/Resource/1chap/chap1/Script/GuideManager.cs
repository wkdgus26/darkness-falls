using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideManager : MonoBehaviour {

    [SerializeField]
    private MouseEvent msEvent;
    [SerializeField]
    private FadeOut fOut;
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject guide1;
    [SerializeField]
    private GameObject guide2;
    [SerializeField]
    private GameObject guide3;
    public int gNum = 0;
    public bool isGuide = false;

    private Vector3 mousePos;
    public float time=0;
    public RaycastHit2D hit;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isGuide)
        {
            time += Time.deltaTime;
            if (gNum == 0)
            {
                ground.SetActive(true);
                if(time >3.5)
                    guide1.SetActive(true);
            }
            else if (gNum == 1)
            {
                guide1.SetActive(false);
                guide2.SetActive(true);
            }
            else if (gNum == 2)
            {
                guide2.SetActive(false);
                fOut.enabled = true;
                if (time > 3)
                {
                    msEvent.isStart = true;
                    isGuide = false;
                    fOut.enabled = false;
                    ground.SetActive(false);
                }
            }
            else if (gNum == 3)
            {
                msEvent.isStart = false;
                ground.SetActive(true);
                if (time > 3.5)
                    guide3.SetActive(true);
            }
            else
            {
                guide3.SetActive(false);
                fOut.enabled = true;
                if (time > 3)
                {
                    msEvent.isStart = true;
                    isGuide = false;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Ray2D ray = new Ray2D(mousePos, Vector2.zero);
                hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit == true)
                {
                    if (hit.collider.tag == "cancel_button")
                    {
                        gNum++;
                        time = 0;
                    }
                }
            }

        }
	}

}
