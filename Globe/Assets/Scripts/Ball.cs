using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public ColorType _colorType;
    public Collider2D col;
    BallManager ballManager;
    //List<Ball> nearBalls = new List<Ball>();

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        ballManager = FindObjectOfType<BallManager>();
    }
    public void SetColor(ColorType colorType)
    {
        _colorType = colorType;
        spriteRenderer.color = colorType.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "bullet")
        {            
            Destroy(collision.gameObject);
            DestroyBall();
        }
    }

    public void DestroyBall()
    {
        ballManager.allBalls.Remove(this);
        List<Ball> nearBalls = ballManager.FindTouching(this);
        foreach (Ball b in nearBalls)
        {
            if (!b) return;
            if (b._colorType.ballKind == this._colorType.ballKind)
            {
                b.DestroyBall();
            }
        }
        Destroy(this.gameObject);
    }
}
