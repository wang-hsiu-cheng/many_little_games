using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player6_move : MonoBehaviour
{
    Color black = new Color(225, 225, 225, 225), white = new Color(0, 0, 0, 225);
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>() .gravityScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (collider_detect_2.collid) {
            gameObject.GetComponent<Rigidbody2D>() .gravityScale = 0;
        } else if (collider_detect_3.collid) {
            gameObject.GetComponent<Rigidbody2D>() .gravityScale = 0;
        } else if (collider_detect_0.collid && !collider_detect_2.collid && !collider_detect_3.collid) {
            gameObject.GetComponent<Rigidbody2D>() .gravityScale = 1;
        } else if (collider_detect_1.collid && !collider_detect_2.collid && !collider_detect_3.collid) {
            gameObject.GetComponent<Rigidbody2D>() .gravityScale = -1;
        } else {
            gameObject.GetComponent<Rigidbody2D>() .gravityScale = 1;
        }

        if (Input.GetKey("a")) {
            if (collider_detect_0.collid && !collider_detect_2.collid && !collider_detect_3.collid) {
                transform.Translate(-12*Time.deltaTime, 0, 0);
                if (!collider_detect_0.collid) {
                    gameObject.transform.position += new Vector3(0.1f, -0.3f, 0);
                }
            } else if (collider_detect_1.collid && !collider_detect_2.collid && !collider_detect_3.collid) {
                transform.Translate(-12*Time.deltaTime, 0, 0);
                if (!collider_detect_1.collid) {
                    gameObject.transform.position += new Vector3(0.1f, 0.3f, 0);
                }
            } else if ((collider_detect_0.collid && !collider_detect_1.collid) && (collider_detect_2.collid || collider_detect_3.collid)) {
                gameObject.transform.position += new Vector3(0, 0.1f, 0);
            } else if ((!collider_detect_0.collid && collider_detect_1.collid) && (collider_detect_2.collid || collider_detect_3.collid)) {
                gameObject.transform.position += new Vector3(0, -0.1f, 0);
            }
        }
        if (Input.GetKey("d")) {
            if (collider_detect_0.collid && !collider_detect_2.collid && !collider_detect_3.collid) {
                transform.Translate(12*Time.deltaTime, 0, 0);
                if (!collider_detect_0.collid) {
                    gameObject.transform.position += new Vector3(0, -0.1f, 0);
                }
            } else if (collider_detect_1.collid && !collider_detect_2.collid && !collider_detect_3.collid) {
                transform.Translate(12*Time.deltaTime, 0, 0);
                if (!collider_detect_1.collid) {
                    gameObject.transform.position += new Vector3(0, 0.1f, 0);
                }
            } else if (collider_detect_0.collid && (collider_detect_2.collid || collider_detect_3.collid)) {
                gameObject.transform.position += new Vector3(0, 0.1f, 0);
            } else if (collider_detect_1.collid && (collider_detect_2.collid || collider_detect_3.collid)) {
                gameObject.transform.position += new Vector3(0, -0.1f, 0);
            }
        }
        if (Input.GetKey("w")) {
            if ((collider_detect_2.collid || collider_detect_3.collid) && !collider_detect_0.collid && !collider_detect_1.collid) {
                transform.Translate(0, 12*Time.deltaTime, 0);
            } else if ((collider_detect_2.collid && !collider_detect_3.collid) && (collider_detect_0.collid || collider_detect_1.collid)) {
                gameObject.transform.position += new Vector3(-0.1f, 0, 0);
            } else if ((!collider_detect_2.collid && collider_detect_3.collid) && (collider_detect_0.collid || collider_detect_1.collid)) {
                gameObject.transform.position += new Vector3(0.1f, 0, 0);
            }
        }
        if (Input.GetKey("s")) {
            if ((collider_detect_2.collid || collider_detect_3.collid) && !collider_detect_0.collid && !collider_detect_1.collid) {
                transform.Translate(0, -12*Time.deltaTime, 0);
            } else if ((collider_detect_2.collid && !collider_detect_3.collid) && (collider_detect_0.collid || collider_detect_1.collid)) {
                gameObject.transform.position += new Vector3(-0.1f, 0, 0);
            } else if ((!collider_detect_2.collid && collider_detect_3.collid) && (collider_detect_0.collid || collider_detect_1.collid)) {
                gameObject.transform.position += new Vector3(0.1f, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.Space)) {
            // transform.position += new Vector3(0 ,-1, 0);
            if (transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color == white)
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = black;
            else 
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = white;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        
    }
}
