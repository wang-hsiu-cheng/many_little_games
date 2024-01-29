using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4, blood = 100;
    static public float _x, _y;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += speed * Time.deltaTime;
        transform.position = new Vector3(2 * (float)Math.Sin(timer * 1.5), 2 * (float)Math.Sin(timer/* + Math.PI/2*/), 0);
        _x = GetComponent <Transform> ().position.x;
        _y = GetComponent <Transform> ().position.y;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullit") {
            blood -= 1;
        }
        if (blood <= 0) {
            Destroy(this.gameObject);
        }
    }
}
