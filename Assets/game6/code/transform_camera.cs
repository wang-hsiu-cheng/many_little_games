using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform_camera : MonoBehaviour
{
    public GameObject player;
    Vector3 location = new Vector3(0, 0, -10);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf) {
            location = GameObject.Find("player").transform.position;
        }
        else
            location = new Vector3(0, 0, -10);
        gameObject.transform.position = new Vector3(location.x, location.y, -10);
    }
}
