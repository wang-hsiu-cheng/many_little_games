using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_3 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5, attackSpeed = 1000, degree_hor, degree_ver;
    [SerializeField] private int blood = 50, damage = 5;
    private bool isdead = false;
    static public Vector3 player_position;
    GameObject obj_weapon;
    // Start is called before the first frame update
    void Start()
    {
        obj_weapon = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Attack();
        if (blood <= 0) {
            Dead();
        }
    }

    void Walk()
    {
        player_position = GetComponent <Transform> ().position;
        if (Input.GetKey(KeyCode.S)) {
            if (Input.GetKey(KeyCode.A)) {
                transform.Translate(-moveSpeed * Time.deltaTime / (float)Math.Sqrt(2), 0, moveSpeed * Time.deltaTime / (float)Math.Sqrt(2));
            } else if (Input.GetKey(KeyCode.D)) {
                transform.Translate(-moveSpeed * Time.deltaTime / (float)Math.Sqrt(2), 0, -moveSpeed * Time.deltaTime / (float)Math.Sqrt(2));
            } else {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }
        } else if (Input.GetKey(KeyCode.W)) {
            if (Input.GetKey(KeyCode.A)) {
                transform.Translate(moveSpeed * Time.deltaTime / (float)Math.Sqrt(2), 0, moveSpeed * Time.deltaTime / (float)Math.Sqrt(2));
            } else if (Input.GetKey(KeyCode.D)) {
                transform.Translate(moveSpeed * Time.deltaTime / (float)Math.Sqrt(2), 0, -moveSpeed * Time.deltaTime / (float)Math.Sqrt(2));
            } else {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
        } else if (Input.GetKey(KeyCode.A)) {
            if (Input.GetKey(KeyCode.S)) {
                transform.Translate(-moveSpeed * Time.deltaTime / (float)Math.Sqrt(2), 0, moveSpeed * Time.deltaTime / (float)Math.Sqrt(2));
            } else if (Input.GetKey(KeyCode.W)) {
                transform.Translate(moveSpeed * Time.deltaTime / (float)Math.Sqrt(2), 0, moveSpeed * Time.deltaTime / (float)Math.Sqrt(2));
            } else {
                transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.D)) {
            if (Input.GetKey(KeyCode.S)) {
                transform.Translate(-moveSpeed * Time.deltaTime / (float)Math.Sqrt(2), 0, -moveSpeed * Time.deltaTime / (float)Math.Sqrt(2));
            } else if (Input.GetKey(KeyCode.W)) {
                transform.Translate(moveSpeed * Time.deltaTime / (float)Math.Sqrt(2), 0, -moveSpeed * Time.deltaTime / (float)Math.Sqrt(2));
            } else {
                transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
            }
        }
    }
    void Attack()
    {
        degree_hor = obj_weapon.GetComponent <Transform> ().eulerAngles.x;
        degree_ver = obj_weapon.GetComponent <Transform> ().eulerAngles.z;
        if (Input.GetKey(KeyCode.UpArrow) && (degree_ver >= 270 || degree_ver < 0)) {
            obj_weapon.transform.Rotate(0, 0, attackSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.DownArrow) && (degree_ver > 271 || degree_ver <= 1)) {
            obj_weapon.transform.Rotate(0, 0, -attackSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.LeftArrow) && (degree_hor >= 270 || degree_hor < 89)) {
            obj_weapon.transform.Rotate(attackSpeed * Time.deltaTime, 0, 0);
        } else if (Input.GetKey(KeyCode.RightArrow) && (degree_hor > 271 || degree_hor <= 90)) {
            obj_weapon.transform.Rotate(-attackSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            obj_weapon.transform.Translate(0, attackSpeed * Time.deltaTime, 0);
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            player_position = GetComponent <Transform> ().position;
            obj_weapon.transform.position = new Vector3 (0.6f, 0, -0.75f) + player_position;
        }
    }
    void Dead()
    {
        if (player_position.y < 5 && !isdead) {
            transform.Translate(0, 50f * Time.deltaTime, 0);
        } else if (player_position.y >= 5) {
            isdead = true;
        } else if (player_position.y <= 0.5f && isdead) {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "computer"){
            blood -= damage;
        }
    }

}
