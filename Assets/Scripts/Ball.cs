using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string colName = col.gameObject.name;

        //leftPaddle or rightPaddle
        if ((colName == "RightPaddle") ||
           (colName == "LeftPaddle"))
        {
            HandlePaddleHit(col);
        }

        //WallBottom or WallTop
        if ((colName == "WallTop") ||
            (colName == "WallBottom"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallHit);
        }

        //GoalLeft or GoalRight
        if ((colName == "RightGoal") ||
            (colName == "LeftGoal"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goal);

            if(colName == "LeftGoal") {
                IncreaseTextUIScore("RightScoreUI");
            } else if (colName == "RightGoal") {
                IncreaseTextUIScore("LeftScoreUI");
            }

            transform.position = new Vector2(0, 0);
        }
    }

    void HandlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(transform.position,
                                     col.transform.position,
                                     col.collider.bounds.size.y);
        Vector2 dir = new Vector2();

        if (col.gameObject.name == "LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }
        else
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.paddleHit);
    }

    float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }

    void IncreaseTextUIScore(string textUIName) {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();

        int score = int.Parse(textUIComp.text);
        score++;

        textUIComp.text = score.ToString();
    }
}
