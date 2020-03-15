using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFadeIn : MonoBehaviour {
    float time = 0;
    // Update is called once per frame
    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        if (time < 3f)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / 3);
        }
        time += Time.deltaTime;

    }
}
