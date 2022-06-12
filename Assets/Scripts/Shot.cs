using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private float _speed = 10;

    private void FixedUpdate()
    {
        Move();

        if (transform.position.y > SceneBorder.Top)
            Deactivate();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _speed);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
