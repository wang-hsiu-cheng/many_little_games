using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Math.Abs(gameObject.transform.position.x) >= 10 || Math.Abs(gameObject.transform.position.y) >= 5){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
