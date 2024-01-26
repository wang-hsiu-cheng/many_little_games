using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_control : MonoBehaviour
{
    private int child_number;
    // Start is called before the first frame update
    void Start()
    {
        child_number = gameObject.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            if (transform.GetChild(0).gameObject.GetComponent<Collider2D>() .enabled == true) {
                for (int i = 0; i < child_number; i++) {
                    transform.GetChild(i).gameObject.GetComponent<Collider2D>() .enabled = false;
                }
            } else {
                for (int i = 0; i < child_number; i++) {
                    transform.GetChild(i).gameObject.GetComponent<Collider2D>() .enabled = true;
                }
            }
        }
    }
}
