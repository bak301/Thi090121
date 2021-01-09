using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] float lifetime;
    [SerializeField] float speed;

    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        counter = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < 0)
        {
            SimplePool.Despawn(gameObject);
        } else
        {
            counter -= Time.deltaTime;
        }

        Move(speed);
    }

    private void Move(float speed)
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bird")
        {
            GameManager.score += 1;
        }
    }
}
