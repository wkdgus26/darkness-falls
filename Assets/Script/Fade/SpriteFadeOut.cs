using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFadeOut : MonoBehaviour {

    public float time = 3;

    // Update is called once per frame
    void Update()
    {
        if (time > 0f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / 3);
            time -= Time.deltaTime;
        }
    }
}
