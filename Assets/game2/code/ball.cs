using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    Text score, reminder;
    static public Vector3 ball_position;
    static public Rigidbody2D rb_ball;
    [SerializeField] private int player_score = 0, computer_score = 0;
    private float timer;
    private char who_scored = '0';

    void Start()
    {
        GameObject ScoreText = GameObject.Find("score");
        GameObject RemindText = GameObject.Find("reminder");
        rb_ball = gameObject.GetComponent<Rigidbody2D>();
        score = ScoreText.GetComponent<Text>();
        reminder = RemindText.GetComponent<Text>();
    }

    void Update()
    {
        if (who_scored != '0') {
            Reminder();
        }
        ball_position = GetComponent <Transform> ().position;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") {
            rb_ball.velocity = new Vector3(0, 0, 0);
            computer_score += 1;
            timer = Time.time;
            who_scored = '1';
            score.text = computer_score.ToString("00") + "  :  " + player_score.ToString("00");
            Invoke("Respawn", 2);
        } else if (other.gameObject.tag == "computer") {
            rb_ball.velocity = new Vector3(0, 0, 0);
            player_score += 1;
            timer = Time.time;
            who_scored = '2';
            score.text = computer_score.ToString("00") + "  :  " + player_score.ToString("00");
            Invoke("Respawn", 2);
        }
    }
    void Reminder()
    {
        if (((Time.time - timer) >= 0.5f && (Time.time - timer) < 1) ||
            ((Time.time - timer) >= 1.5f && (Time.time - timer) < 2) || 
            ((Time.time - timer) >= 2.5f && (Time.time - timer) < 3)) {
            if (who_scored == '2') {
                reminder.text = "Player Scored One Point!";
            } else if (who_scored == '1') {
                reminder.text = "Computer Scored One Point!";
            }
        } else if ((Time.time - timer) >= 3) {
            reminder.text = " ";
            who_scored = '0';
        } else {
            reminder.text = " ";
        }
    }
    void Respawn()
    {
        if (who_scored == '2') {
            transform.position = new Vector3(2, 0, 0);
        } else if (who_scored == '1') {
            transform.position = new Vector3(-2, 0, 0);
        }
    }
}
