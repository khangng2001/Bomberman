using System.Xml.Serialization;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rigidBody { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode inputLeft = KeyCode.A;

    public AnimatedSprite spriteUp;
    public AnimatedSprite spriteDown;
    public AnimatedSprite spriteLeft;
    public AnimatedSprite spriteRight;
    public AnimatedSprite spriteDeath;
    private AnimatedSprite activeSprite;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        activeSprite = spriteDown;
    }

    private void Update()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteUp);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteDown);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteLeft);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteRight);
        }
        else
        {
            SetDirection(Vector2.zero, activeSprite);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidBody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        rigidBody.MovePosition(translation + position);
    }
    private void SetDirection(Vector2 newDirection, AnimatedSprite sprite)
    {
        direction = newDirection;
        spriteUp.enabled = sprite == spriteUp;
        spriteDown.enabled = sprite == spriteDown;
        spriteLeft.enabled = sprite == spriteLeft;
        spriteRight.enabled = sprite == spriteRight;

        activeSprite = sprite;
        activeSprite.idle = direction == Vector2.zero;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteUp.enabled = false;
        spriteDown.enabled = false;
        spriteLeft.enabled = false;
        spriteRight.enabled = false;
        spriteDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckWinState();
    }
    public void DecreaseSpeed()
    {
        if (speed <= 5)
        {
            speed = 5;
        }
        else
        {
            speed--;
        }
        
    }
}