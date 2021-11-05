using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalItem : MonoBehaviour
{
    [SerializeField] private Text count;
    public Image image;

    public void SetCounter(int c)
    {
        count.text = c.ToString();
        //Debug.Log("Set number " + c);
    }
    
    public void SetColor(ColorType colorType)
    {
        image.color = colorType.color;
        //Debug.Log("Set color " + colorType.ballKind);
    }
}
