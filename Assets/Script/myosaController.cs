using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myosaController : MonoBehaviour {
	/*
	 * 이거 실행 제대로되려면 맵에 collider박아줘서 hit값이 항상 찍혀야함
	 * 근대 그렇게되면 hit이 맵만 찍음
	 * 시발
	 */
	public GameObject player;
	public bool isFollow = false;
	private Vector2 targetPos;
	private Animator catAnim;
	public raykast ray;
	private float time = 0;
	// Use this for initialization
	void Start () {
		catAnim = GetComponent<Animator>();
	}

	//void LateUpdate()
	//{
	//	if (isFollow)
	//	{
	//		if (Input.GetMouseButtonDown(0))
	//		{
	//			catChangeMove();
	//		}
	//	}
	//}

	// Update is called once per frame
	void Update () {
		if (isFollow)
			catMove();

		if (Input.GetMouseButtonDown(0))
		{
			isFollow = true;
		}
	}

	void catMove()
	{
		if (player.transform.position.x > gameObject.transform.position.x + 1.2f)
		{
			gameObject.transform.position =
				new Vector2(player.transform.position.x - 1.2f, gameObject.transform.position.y);
			catState(false, false, true);
			if (ray.hit.point.x < gameObject.transform.position.x + 1.17f)
			{
				isFollow = false;
				catState(true, false, false);
			}
		}
		else if (player.transform.position.x < gameObject.transform.position.x - 1.2f)
		{
			gameObject.transform.position =
				new Vector2(player.transform.position.x + 1.2f, gameObject.transform.position.y);
			catState(false, true, false);
			if (ray.hit.point.x > gameObject.transform.position.x - 1.17f)
			{
				isFollow = false;
				catState(true, false, false);
			}
		}
	

	}

	//void catChangeMove()
	//{
	//	if (ray.hit.point.x < gameObject.transform.position.x && ray.hit.point.x > gameObject.transform.position.x)
	//	{
	//		catState(true, false, false);
	//		isFollow = false;
	//	}
	//}


	void catState(bool Idle,bool Lwalk, bool Rwalk)
	{
		catAnim.SetBool("isIdle", Idle);
		catAnim.SetBool("isLwalk", Lwalk);
		catAnim.SetBool("isRwalk", Rwalk);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
			isFollow = true;
		}
	}
}
