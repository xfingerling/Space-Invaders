using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action OnShootEvent;

    private float _speed = 10;

    private void Update()
    {
        Shoot();
        CheckingPosition();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnShootEvent?.Invoke();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * Time.deltaTime * -_speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
        }
    }

    private void CheckingPosition()
    {
        if (transform.position.x >= SceneBorder.Right)
        {
            transform.position = new Vector2(SceneBorder.Right, transform.position.y);
        } else if (transform.position.x <= SceneBorder.Left)
        {
            transform.position = new Vector2(SceneBorder.Left, transform.position.y);
        }
    }
}
