using UnityEngine;

public class Invaders : MonoBehaviour
{
    [SerializeField] private Invader[] _prefabs;
    [SerializeField] private int _rows = 5;
    [SerializeField] private int _columns = 11;

    private void Awake()
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
}
