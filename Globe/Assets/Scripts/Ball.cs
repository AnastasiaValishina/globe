using System.Collections.Generic;
using UnityEngine;

public class Ball : BallBase
{

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "bullet")
        {
            BallBase bullet = collision.GetComponent<BallBase>();
            if (bullet._colorType.ballKind == this._colorType.ballKind)
            {
                Destroy(collision.gameObject);
                DestroyThisBall();
            }
        }
    }

    public void DestroyThisBall()
    {
        ballManager.allBalls.Remove(this);
        // переделать на список
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
