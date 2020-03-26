using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : MonoBehaviour {

	private Animator dAnim; //개새끼 애니메이션
	private bool isIdel= false;
	private bool isCo = false;
	// Use this for initialization
	void Start () {
		dAnim = gameObject.GetComponent<Animator>();
		dAnim.SetBool("isRun", true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Move();
	}

	void Move() {
		dAnim.SetBool("isRun", true);
		this.transform.position += Vector3.left * 1f * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log(col.tag);
		if (col.tag == "EventTrig1")
		{
			this.transform.rotation = Quaternion.Euler(0,180f,0);
			StopAllCoroutines();
			StartCoroutine(RMoveCoroutine());
		}

		else if (col.tag == "EventTrig2")
		{
			this.transform.rotation = Quaternion.Euler(0, 0f,0);
			StopAllCoroutines();
			StartCoroutine(LMoveCoroutine());
		}
	}

	IEnumerator RMoveCoroutine()
	{
		while (true)
		{
			if (!isIdel)
				this.transform.position += Vector3.right * 1f * Time.deltaTime;
			yield return null;
			if (!isCo)
				StartCoroutine(IdelCoroutine());
		}
	}

	IEnumerator LMoveCoroutine()
	{
		while (true)
		{
			if (!isIdel)
				this.transform.position += Vector3.left * 1f * Time.deltaTime;
				yield return null;
			if(!isCo)
				StartCoroutine(IdelCoroutine());
		}
	}

	IEnumerator IdelCoroutine()
	{
		isCo = true;
		Debug.Log("co");
		yield return new WaitForSecondsRealtime(5f);
		Debug.Log("5second");
		dAnim.SetBool("isRun", false);
		isIdel = true;
		yield return new WaitForSeconds(3f);
		dAnim.SetBool("isRun", true);
		isIdel = false;
		isCo = false;
	}


}
