using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private ParabolaController pc;

	// Use this for initialization
	void Start () {
        pc = GetComponent<ParabolaController>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            pc.ParabolaRoot = GameObject.Find("ParabolaRoot2");
        }
    }
}
