using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Projectitle _laserPrefab;
    [SerializeField] private float _speed = 5;

    private bool _laserActive;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!_laserActive)
        {
            Projectitle projectitle = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            projectitle.OnDestroyEvent += OnDestroyed;
            _laserActive = true;
        }

    }

    private void OnDestroyed()
    {
        _laserActive = false;
    }
}
