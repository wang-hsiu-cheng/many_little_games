using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer_2 : MonoBehaviour
{
    public Rigidbody2D rb_computer;
    [SerializeField] private float _x, _y, x_v, y_v, x_ball, y_ball, x_v_ball, y_v_ball, t_0, t_1;
    [SerializeField] private char step = '0';
    [SerializeField] private Vector2 destination_ball, destination_computer, aimpoint = new Vector2(9, 0), delta;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _x = GetComponent <Transform> ().position.x;
        _y = GetComponent <Transform> ().position.y;
        if (ball.ball_position.x < 0) {
            x_ball = ball.ball_position.x;
            y_ball = ball.ball_position.y;
            x_v_ball = ball.rb_ball.velocity.x;
            y_v_ball = ball.rb_ball.velocity.y;

            if (x_v_ball < -0.5f && Math.Abs(y_v_ball/x_v_ball) < 0.7f) {
                switch (step) {
                    case '0': Calculate('0');break;
                    case '1': KickBall_0();break;
                    default: break;
                }
            } else if (x_v_ball < -0.5f && y_v_ball/x_v_ball >= 0.7f) {
                switch (step) {
                    case '0': Calculate('1');break;
                    case '1': KickBall_0();break;
                    default: break;
                }
            } else if (x_v_ball < -0.5f && y_v_ball/x_v_ball <= -0.7f) {
                switch (step) {
                    case '0': Calculate('2');break;
                    case '1': KickBall_0();break;
                    default: break;
                }
            } else if (x_v_ball >= -0.5f && x_v_ball <= 0) {
                switch (step) {
                    case '0': Calculate('3');break;
                    case '1': KickBall_0();break;
                    default: break;
                }
            }
            // else if (x_v_ball > 0 && x_v_ball < 1) {

            // }
        } else if (ball.ball_position.x > 0) {
            step = '0';
            Ready();
        }
    }
    void Calculate(char type)
    {
        t_0 = ((x_ball-_x)*(x_ball-_x)+(y_ball-_y)*(y_ball-_y)) / (2*((_x-x_ball)*x_v_ball + (_y-y_ball)*y_v_ball));
        if (type == '0') {destination_ball = new Vector2(x_v_ball * t_0 + x_ball, y_v_ball * t_0 + y_ball);Debug.Log("type_0");}
        else if (type == '1') {destination_ball = new Vector2((-3.2f - y_ball)/y_v_ball * x_v_ball + x_ball, -3.2f);Debug.Log("type_1");}
        else if (type == '2') {destination_ball = new Vector2((3.2f - y_ball)/y_v_ball * x_v_ball + x_ball, 3.2f);Debug.Log("type_2");}
        else if (type == '3') {destination_ball = new Vector2(x_ball, 0);Debug.Log("type_3");}
        delta = new Vector2((destination_ball.x - aimpoint.x) / (destination_ball - aimpoint).magnitude * 2, (destination_ball.y - aimpoint.y) / (destination_ball - aimpoint).magnitude * 2);
        destination_computer = destination_ball + delta;
        if (destination_computer.x > -8 && destination_computer.y < 4.5f && destination_computer.y > -4.5f) {
            if (type == '0') rb_computer.velocity = new Vector3((destination_computer.x - _x)/ t_0, (destination_computer.y - _y)/ t_0, 0);
            else if (type == '1') rb_computer.velocity = new Vector3((destination_computer.x - _x)/ ((-3.2f - y_ball)/y_v_ball), (destination_computer.y - _y)/ ((-3.2f - y_ball)/y_v_ball), 0);
            else if (type == '2') rb_computer.velocity = new Vector3((destination_computer.x - _x)/ ((3.2f - y_ball)/y_v_ball), (destination_computer.y - _y)/ ((3.2f - y_ball)/y_v_ball), 0);
            else if (type == '3') rb_computer.velocity = new Vector3((destination_computer.x - _x)/ t_0, (destination_computer.y - _y)/ t_0, 0);
            step = '1';
        } else {
            //rb_computer.velocity = new Vector3((destination_computer.x - _x)/ t_0, (destination_computer.y - _y)/ t_0, 0); ////////////
            step = '1';
        }
        if (_x > -0.8f) {
            rb_computer.velocity = new Vector3(0, 0, 0);
        }
    }
    void KickBall_0()
    {
        if ((new Vector2(_x, _y) - destination_computer).magnitude <= 0.2f) {
            rb_computer.velocity = new Vector3(0, 0, 0);
        }
        if ((new Vector2(x_ball, y_ball) - destination_ball).magnitude <= 0.2f) {
            rb_computer.velocity = new Vector3(-delta.x * 20, -delta.y * 20, 0);
            step = '1';
        }
        if (_x > -0.8f) {
            rb_computer.velocity = new Vector3(0, 0, 0);
        }
    }
    void Ready()
    {
        Vector3 direction = new Vector3(-3-_x, -_y, 0);
        if (direction.magnitude > 0.1f) {
            rb_computer.velocity = direction/direction.magnitude * 5;
        } else {
            rb_computer.velocity = new Vector3(0, 0, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullit" && step == '1') {
            step = '0';
            rb_computer.velocity = new Vector3(0, 0, 0);
        }
    }
}
