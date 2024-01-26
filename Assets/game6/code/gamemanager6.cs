using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager6 : MonoBehaviour
{
    public GameObject player6;
    bool restart = false;
    // Start is called before the first frame update
    void Start()
    {
        player6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (game_manager.game_start && !restart) {
            player6.SetActive(true);
            player6.transform.position = new Vector3(0.2f, 0, 0);
            restart = true;
        }
    }
}
