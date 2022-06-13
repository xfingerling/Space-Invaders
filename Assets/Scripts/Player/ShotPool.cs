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


}
