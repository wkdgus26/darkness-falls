using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour {
    private float startpos;
    public GameObject player;
    public float parallaxEffect;
    
	// Use this for initialization
	void Start () {
        startpos = transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float dist = (player.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos - dist, transform.position.y, transform.position.z);
	}
}
