using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BallBase
{
    [SerializeField] float speed = 10f;
    public bool canShoot;

    void Update()
    {
        if (canShoot)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "wheel" && tag == "bullet")
        {
            Ball newBall = GetComponent<Ball>();
            newBall._colorType = this._colorType;
            tag = "ball";
            gameObject.AddComponent<Rigidbody2D>();
            transform.parent = collision.transform;
            col.isTrigger = false;
            ballManager.allBalls.Add(newBall);
            Destroy(this);
        }
    }
}

