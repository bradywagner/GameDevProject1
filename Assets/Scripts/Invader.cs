using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{

    public Sprite[] animationSprties;

    public float animationTime = 1.0f;

    public System.Action killed;

    private SpriteRenderer _spriteRenderer;

    private int _animationFrame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= this.animationSprties.Length) {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprties[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser")) 
        {
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
