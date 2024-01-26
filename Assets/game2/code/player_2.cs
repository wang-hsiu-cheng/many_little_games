using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class player_2 : MonoBehaviour
{    
    Vector3 offset;
    [SerializeField] private Vector3 curPosition;
    private bool start = false;
    public Rigidbody2D rb;
    void Update()
    {
        if (start) {
            Control();
        }
        if ((float)Math.Abs(curPosition.magnitude - transform.position.magnitude) > 1 
            && curPosition.x > 0.8 && curPosition.x < 8.2f && curPosition.y < 4.3f && curPosition.y > -4.3f) {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = curPosition;
        }
    }
    //滑鼠拖曳物體
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        start = true;
    }
    void Control() //OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 lastPosition = curPosition;
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        Vector3 distant = curPosition - lastPosition;
        if (curPosition.x > 0.8f && curPosition.x < 8.2f && curPosition.y < 4.3f && curPosition.y > -4.3f) {
            rb.velocity = distant / Time.deltaTime;
        } else {
            rb.velocity = new Vector3 (0, 0, 0);
        }
    }
}
