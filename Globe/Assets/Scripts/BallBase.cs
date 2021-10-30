using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer; 
    
    public ColorType _colorType;
    public Collider2D col;
    public BallManager ballManager;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        ballManager = FindObjectOfType<BallManager>();
    }

    public void SetColor(ColorType colorType)
    {
        _colorType = colorType;
        spriteRenderer.color = colorType.color;
    }
}

