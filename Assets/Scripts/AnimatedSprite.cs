using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    AudioSource audioData;   
    private SpriteRenderer spriteRenderer;
    public float animationTime = 0.25f;
    private int animationFrame;

    public Sprite[] sprites;
    public Sprite idleSprite;

    public bool loop = true;
    public bool idle = true;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
        
    }

    private void NextFrame()
    {
        animationFrame++;
        if (loop & animationFrame >= sprites.Length)
        {
            animationFrame = 0;
        }
        else if (idle)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else if (animationTime >=0 && animationFrame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[animationFrame];
        }
    }
}
