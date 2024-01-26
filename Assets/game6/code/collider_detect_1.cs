using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_detect_1 : MonoBehaviour
{
    static public bool collid = false, change = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        change = true;
        collid = true;
    }
    void OnCollisionStay2D(Collision2D other)
    {
        collid = true;
        Debug.Log("collid1=true");
    }
    void OnCollisionExit2D(Collision2D other)
    {
        collid = false;
        // change = false;
    }
}
