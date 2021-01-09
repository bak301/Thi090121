using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D bird;
    [SerializeField] float jumpForce;
    [SerializeField] float interval;
    [SerializeField] ScoreTrigger trigger;
    [SerializeField] Text scores;
    [SerializeField] Image gameover;

    private float counter;
    internal static int score;
    internal static string state;
    private System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        gameover.enabled = false;
        state = "play";
        score = 0;
        counter = interval;
        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "lose")
        {
            Time.timeScale = 0;
            gameover.enabled = true;
        }

        scores.text = "Score: " + score;
        if (counter < 0)
        {
            SpawnPipe();
            counter = interval;
        } else
        {
            counter-= Time.deltaTime;
        }
    }

    private void SpawnPipe()
    {
        SimplePool.Spawn(trigger, new Vector3(4, ((float)rnd.Next(-15, 20)) / 10, 0), Quaternion.identity);
    }

    private void OnMouseDown()
    {
        Debug.Log("TAP");
        Debug.Log(bird.velocity);

        bird.velocity = new Vector2(0, jumpForce);
    }
}
