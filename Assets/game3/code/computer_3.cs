using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer_3 : MonoBehaviour
{
    GameObject LeftLeg, RightLeg, LeftArm, RightArm;
    private float timer;
    [SerializeField] private int i = 0, damage = 5, blood = 100;
    [SerializeField] private Vector3 computer_position;
    // Start is called before the first frame update
    void Start()
    {
        LeftLeg = transform.GetChild(1).gameObject;
        RightLeg = transform.GetChild(2).gameObject;
        LeftArm = transform.GetChild(3).gameObject;
        RightArm = transform.GetChild(4).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i")) {
            i = 1;
        }
        if (i != 0) {
            Walk();
        }

        if (Input.GetKeyDown("o")) {
            InvokeRepeating("FindEnemy", 0, 0.1f);
        }
        BeDamaged();
        // Walk();
    }
    void Walk()
    {
        computer_position = GetComponent <Transform> ().position;
        if (LeftLeg.transform.position.y - computer_position.y < 0 && LeftLeg.transform.position.x - computer_position.x >= 0 && i == 1) {
            LeftLeg.transform.Translate(0, 2 * Time.deltaTime, 0);
        } else if (LeftLeg.transform.position.y - computer_position.y >= 0 && LeftLeg.transform.position.x - computer_position.x > -2) {
            LeftLeg.transform.Translate(-2 * Time.deltaTime, 0, 0);
            i = 2;
        } else if (LeftLeg.transform.position.y - computer_position.y > -0.5f && LeftLeg.transform.position.x - computer_position.x <= -2 && i == 2) {
            LeftLeg.transform.Translate(0, -2 * Time.deltaTime, 0);
            i = 3;
        } else if (LeftLeg.transform.position.y - computer_position.y <= -0.5f && LeftLeg.transform.position.x - computer_position.x < 0 && i == 3) {
            LeftLeg.transform.Translate(2 * Time.deltaTime, 0, 0);
            i = 4;
        } else if (LeftLeg.transform.position.y - computer_position.y <= -0.5f && LeftLeg.transform.position.x - computer_position.x >= 0 && i == 4) {
            i = 0;
        }
    }
    void FindEnemy()
    {
        float _x = GetComponent <Transform> ().position.x;
        float _z = GetComponent <Transform> ().position.z;
        float degree_y = GetComponent <Transform> ().eulerAngles.y;
        if (degree_y > 180) degree_y -= 360;

        float aimdegree = (float)(Math.Atan((_z - player_3.player_position.z) / (player_3.player_position.x - _x)) / Math.PI * 180);
        if (aimdegree - degree_y >= 2) {
            transform.Rotate(0, 100f * Time.deltaTime, 0, Space.Self);
        } else if (degree_y - aimdegree >= 2) {
            transform.Rotate(0, -100f * Time.deltaTime, 0, Space.Self);
        }
    }
    void BeDamaged()
    {
        if (weapon.damage == true) {
            blood -= damage;
            weapon.damage = false;
        }
        if (blood <= 0) {
            Dead();
        }
    }
    void Dead()
    {
        float degree_z = GetComponent <Transform> ().eulerAngles.z;
        if (degree_z > 180) degree_z -= 360;

        if (degree_z > -90) {
            transform.Rotate(0, 0, -100f * Time.deltaTime, Space.Self);
        } else {
            Destroy(gameObject);
        }
    }
}
