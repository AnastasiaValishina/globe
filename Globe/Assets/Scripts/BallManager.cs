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

    public List<Ball> FindTouching(Ball ball)
    {
        List<Ball> nearBalls = new List<Ball>();
        foreach (Ball b in allBalls)
        {
            if (ball != null && b != null)
            {
                if (ball.col.IsTouching(b.col))
                {
                    if (!nearBalls.Contains(b))
                    {
                        nearBalls.Add(b);
                    }
                }
            }
        }
        allBalls.RemoveAll(item => item == null);
        return nearBalls;
    }
}
