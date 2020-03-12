using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    float time = 0;
    /*
    string rock = "rock";
    public GameObject[] kk;

    private void Start()
    {
        for (int i = 1; i <= 30; i++)
        {
            kk[i] = GameObject.Find(rock + i);
        }

    }
    */
    // Update is called once per frame
    void Update()
    {
        if (time < 3f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / 3);
        }
        time += Time.deltaTime;

    }
}
