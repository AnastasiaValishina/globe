using System.Collections.Generic;
using UnityEngine;

public class Ball : BallBase
{
    public Collider2D col;
    BallManager ballManager;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        ballManager = FindObjectOfType<BallManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "bullet")
        {            
            Destroy(collision.gameObject);
            DestroyThisBall();
        }
    }

    public void DestroyThisBall()
    {
        ballManager.allBalls.Remove(this);
        List<Ball> nearBalls = ballManager.FindTouching(this);
        foreach (Ball b in nearBalls)
        {
            if (!b) return;
            if (b._colorType.ballKind == this._colorType.ballKind)
            {
                b.DestroyThisBall();
            }
        }
        Destroy(this.gameObject);
    }
}
