using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPool : MonoBehaviour
{
    private Player _player;

    [SerializeField] private int _poolCount = 5;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Shot _shotPrefab;

    private PoolMono<Shot> _pool;

    private void Awake()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>(); ;
    }

    private void Start()
    {
        _pool = new PoolMono<Shot>(_shotPrefab, _poolCount, transform);
        _pool.AutoExpand = _autoExpand;       
    }

    private void OnEnable()
    {
        _player.OnShootEvent += OnShoot;
    }

    private void OnDisable()
    {
        _player.OnShootEvent -= OnShoot;
    }

    private void OnShoot()
    {
        var shot = _pool.GetFreeElement();
        shot.transform.position = _player.transform.position;
    }
}
