using UnityEngine;

public class Invaders : MonoBehaviour
{
    [SerializeField] private Invader[] _prefabs;
    [SerializeField] private int _rows = 5;
    [SerializeField] private int _columns = 11;
    [SerializeField] private float _speed = 1f;

    private Vector3 _direction = Vector2.right;

    private void Awake()
    {
        SpawnInvaders();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
                continue;

            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1))
                AdvanceRow();
            else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1))
                AdvanceRow();

        }
    }

    private void SpawnInvaders()
    {
        for (int row = 0; row < _rows; row++)
        {
            float width = 2f * (_columns - 1);
            float height = 2f * (_rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);

            Vector3 rowPosition = new Vector3(centering.x, centering.y + row * 2f, 0);

            for (int column = 0; column < _columns; column++)
            {
                Invader invader = Instantiate(_prefabs[row], transform);
                Vector3 position = rowPosition;
                position.x += column * 2f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1;

        Vector3 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }
}
