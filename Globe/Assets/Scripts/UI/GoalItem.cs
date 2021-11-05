using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalItem : MonoBehaviour
{
    [SerializeField] private Text count;
    [SerializeField] private Image image;

    public void SetCounter(int c)
    {
        if (c >= 0)
        {
            count.text = c.ToString();
        }
        else
        {
            0.ToString();
        }
    }
    
    public void SetColor(ColorType colorType)
    {
        image.color = colorType.color;
    }
}
