using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour {
    public GameObject player;
    private GameObject Target;
    public float CameraZ = -10;
    void FixedUpdate()
    {
        Camera.main.orthographicSize = Screen.height;

        Vector3 TargetPos = new Vector3(
<<<<<<< Updated upstream
            Mathf.Clamp(player.transform.position.x, -7.75f, 7.75f), 
            Mathf.Clamp(player.transform.position.y, -2.18f, 2.18f), 
=======
            Mathf.Clamp(player.transform.position.x, -3.43f, 3.43f), 
            Mathf.Clamp(player.transform.position.y, -1.27f, 1.27f), 
>>>>>>> Stashed changes
            CameraZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 1f);
    }
}
