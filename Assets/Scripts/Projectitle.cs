using System;
using UnityEngine;

public class Projectitle : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    public event Action OnDestroyEvent;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnDestroyEvent?.Invoke();
        Destroy(gameObject);
    }
}
