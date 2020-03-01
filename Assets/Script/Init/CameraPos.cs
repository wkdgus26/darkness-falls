using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour {
    public GameObject player;
    private GameObject Target;
    public float CameraZ = -10;

    void FixedUpdate() //실행순서 업데이트 다음에 실행함
    {
        Vector3 TargetPos = new Vector3(
            Mathf.Clamp(player.transform.position.x, -5.8f, 5.8f), //지금 x의 값이 
            Mathf.Clamp(player.transform.position.y, -1.1f, 1.05f), 
            CameraZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 1f); //움직일때 쓰는거 보간
    }
}
