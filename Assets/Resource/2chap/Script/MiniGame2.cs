using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MiniGame2 : MonoBehaviour {

	//[SerializeField]
	//private GameObject mGame2;
	public raykast ray;
	public StateManager state;
	public Text countText;
	public Vector2 targetPos;
	public int bugCount = 5;
	public GameObject fireDog;
	public PlayerMove playerScript;
	public float x, y;
	// Use this for initialization
	void Start () {
		countText.transform.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		catchBug();
	}


	void Update()
	{
		mouseControl();
		game();
	}

	void catchBug()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (ray.hit == true)
			{
				if (ray.hit.collider.tag == "key")
				{
					Destroy(ray.hit.transform.gameObject);
					bugCount -= 1;
				}
			}
		}
	}

	void mouseControl()
	{
		countText.text = bugCount.ToString();
		targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		countText.transform.position = new Vector2(targetPos.x + x, targetPos.y + y);
	}
	void game()
	{
		if (bugCount == 0)
		{

			playerScript.isClick = false;
			countText.transform.gameObject.SetActive(false);
			state.isMove = true;
			StateManager.isStory = false;
			fireDog.GetComponent<Animator>().SetBool("isRun", false);
			fireDog.GetComponent<DogManager>().StopAllCoroutines();
			Destroy(fireDog.GetComponent<DogManager>());
			Destroy(this);
		}
	}

}
