using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchor : MonoBehaviour
{
    [SerializeField] GameObject[] B;
    [SerializeField] Vector2 enemy_velocity;
    [SerializeField] private float degree, aimdegree, timer, input_speed, _x, _y, last_x, last_y, distsec;
    private int bulletfrequence = 30;
    private bool auto = false, Timecounter = false;
    // Start is called before the first frame update
    void Start()
    {
        _x = GetComponent <Transform> ().position.x;
        _y = GetComponent <Transform> ().position.y;
        last_x = enemy._x;
        last_y = enemy._y;
    }

    // Update is called once per frame
    void Update()
    {
        degree = GetComponent <Transform> ().eulerAngles.z;
        Vector3 speed = new Vector3(input_speed * (float)Math.Cos((double)degree/180 * Math.PI), input_speed * (float)Math.Sin((double)degree/180 * Math.PI), 0);
        Vector3 offset = new Vector3(1.5f * (float)Math.Cos((double)degree/180 * Math.PI), 1.5f * (float)Math.Sin((double)degree/180 * Math.PI), 0);
        if (Input.GetKeyDown("x")) {
            if (auto) {
                auto = false;
            } else {
                auto = true;
            }
        }
        if (auto == false) {
            if (degree - 1f > 1f) {
                if (Input.GetKey("d")) {
                    transform.Rotate(0, 0, -100f * Time.deltaTime, Space.Self);
                }
            }
            if (180f - degree > 1f) {
                if (Input.GetKey("a")) {
                    transform.Rotate(0, 0, 100f * Time.deltaTime, Space.Self);
                }
            }
        } else {
            AutoAim();
        }

        if (Input.GetKey("w")) {
            if(bulletfrequence % 30 == 0){
                GameObject bullit = Instantiate(B[0], transform.position + offset, Quaternion.Euler (0, 0, degree));
                Rigidbody2D rb = bullit.GetComponent<Rigidbody2D>();
                rb.velocity = speed;
                Timecounter = true;
                timer = 0;
            }
            bulletfrequence += 1;
        }
        if(Timecounter){ //計時器(Timecounter為計時器啟動開關) 當兩次扣板機時間(timer)大於定值 則冷卻時間(bulletfrequence)重置
            timer += Time.deltaTime;
            if(timer >= 0.7){
                bulletfrequence = 30;
                timer = 0;
                Timecounter = false;
            }
        }
    }

    void AutoAim()
    {
        DetectSpeed();
        aimdegree = (float)(Math.Atan((enemy._y + (enemy_velocity.y) - _y) / (enemy._x + (enemy_velocity.x) - _x)) / Math.PI * 180);
        if (aimdegree < 0) aimdegree += 180; //if calculate result is negative, we have to convert it to reasonable value(positive degree value)
        if (degree - aimdegree >= 2) {
            transform.Rotate(0, 0, -100f * Time.deltaTime, Space.Self);
        } else if (aimdegree - degree >= 2) {
            transform.Rotate(0, 0, 100f * Time.deltaTime, Space.Self);
        }
    }

    void DetectSpeed()
    {
        distsec = (float)Math.Sqrt(Math.Pow(enemy._y - _y, 2) + Math.Pow(enemy._x - _x, 2)) / input_speed;
        if ((Time.time * 10) % 1 <= 0.1f) {
            enemy_velocity = new Vector2((enemy._x - last_x) * 10 * distsec, (enemy._y - last_y) * 10 * distsec);
            last_x = enemy._x;
            last_y = enemy._y;
            Debug.Log(Time.time);
        }
    }
}
