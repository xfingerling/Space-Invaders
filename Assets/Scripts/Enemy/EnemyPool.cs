using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 5;
    [SerializeField] private Enemy _enemyPrefab;

    private PoolMono<Enemy> _pool;

    private int _column = 0;
    private int _row = 0;

    private float _moveSpeed = 1;

    private void Start()
    {
        _pool = new PoolMono<Enemy>(_enemyPrefab, _poolCount, transform);

        ActivateEnemy();
        Move();
    }

    private void Move()
    {
        while (true)
        {
            StartCoroutine(Tick());
        }
        
    }
    IEnumerator Tick()
    {

        yield return new WaitForSeconds(_moveSpeed);
        transform.position = transform.position + Vector3.up;
    }

    private void ActivateEnemy()
    {
        for (int i = 0; i < _poolCount; i++)
        {
            var enemy = _pool.GetFreeElement();

            SetPosition(enemy);
        }
    }

    private void SetPosition(Enemy enemy)
    {
        if(_column == 7)
        {
            _column = 0;
            _row += 1;
        }
       
        enemy.transform.position = transform.position + new Vector3(_column, _row, 0);
        _column += 1;
    }
}
