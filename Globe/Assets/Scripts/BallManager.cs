using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BallKind
{
    Blue,
    Yellow,
    Green,
    Orange,
    Purple,
    Red
}

[System.Serializable] public class ColorType
{
    public BallKind ballKind;
    public Color color;
}
public class BallManager : MonoBehaviour
{
    public List<Ball> allBalls = new List<Ball>();

    private List<Ball> FindSameColor(Ball ball)
    {
        List<Ball> sameTypeBalls = new List<Ball>();
        foreach (Ball b in allBalls)
        {
            if (ball.col.IsTouching(b.col) && ball._colorType.ballKind == b._colorType.ballKind)
            {
                if (!sameTypeBalls.Contains(b))
                {
                    sameTypeBalls.Add(b);                  
                }
            }
        }
        
        return sameTypeBalls;
    }

    public void DestroyGroup(Ball ball)
    {
        List<Ball> sameTypeBalls = FindSameColor(ball);
        foreach (Ball b in sameTypeBalls)
        {
            Destroy(b.gameObject);
        }
    }
}
