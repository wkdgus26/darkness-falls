using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScript : MonoBehaviour {
    private Animator ani;

    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EventTrig1")) {
            Debug.Log("Samjok5 Ani Scripts Trigger Excute!!");
            ani.SetBool("Landing", true);
        }
    }
}
