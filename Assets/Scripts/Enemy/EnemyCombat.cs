using UnityEngine;

public class EnemyCombat : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletPosition;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 2)
        {
            _timer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _bulletPosition.position, Quaternion.identity);
    }
}
