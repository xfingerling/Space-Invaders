using System;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] private Sprite[] _animationSprites;
    [SerializeField] private float _animationTime = 1f;

    public event Action OnKilledEvent;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), _animationTime, _animationTime);
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= _animationSprites.Length)
            _animationFrame = 0;

        _spriteRenderer.sprite = _animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            OnKilledEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
