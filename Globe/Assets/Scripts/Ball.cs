using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public ColorType _colorType;
    public Collider2D col;
    BallManager ballManager;

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
            ballManager.DestroyGroup(this);
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }
}
