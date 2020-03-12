using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    private Transform[] childrenObj;
    // Use this for initialization
    void Start () {
        childrenObj = this.GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponentInChildren<Rigidbody>().isKinematic = false;
        }
	}
}
