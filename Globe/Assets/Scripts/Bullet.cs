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

}

