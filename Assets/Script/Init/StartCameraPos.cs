using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraPos : MonoBehaviour {

    [SerializeField]
    private GameObject menu;
    public float speed = 6;
	// Use this for initialization
	void Start () {
        StartCoroutine(StartCameraCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator StartCameraCoroutine()
    {
        if (transform.position.y > -0.5f)
        {
            while (gameObject.transform.position.y >= -0.5f)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;

                yield return null;
            }
        }
        menu.SetActive(true);
    }
}
