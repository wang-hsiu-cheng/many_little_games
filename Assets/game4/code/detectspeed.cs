using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectspeed : MonoBehaviour
{
    static public Vector2 enemy_velocity;
    [SerializeField] private float last_x, last_y;
    void Start()
    {

    }
    void Update()
    {
        last_x = enemy._x;
        last_y = enemy._y;
        Debug.Log(Time.time);
        Invoke("minus", 1f);
    }
    void minus()
    {
        enemy_velocity = new Vector2((enemy._x - last_x), (enemy._y - last_y));
        Debug.Log(Time.time);
    }
}
