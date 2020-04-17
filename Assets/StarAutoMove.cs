using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAutoMove : MonoBehaviour {

	public GameObject missionMap;
	GameObject star;
	bool isClone = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * 0.1f * Time.deltaTime;
		if (transform.position.x < 12.12f && !isClone)
		{
			isClone = true;
			star = Instantiate(gameObject);
			star.transform.parent = missionMap.transform;
			star.transform.position = new Vector2(49.06f, transform.position.y);
		}
		if (transform.position.x < -6.72f)
			Destroy(gameObject);
	}
}
