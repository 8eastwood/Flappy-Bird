using UnityEngine;

public class BirdCombat : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private InputReader _inputReader;

    private Vector3 _bulletPosition;
    private float _offsetX = 2f;
    private int _directionChanger = 1;

    private void OnEnable()
    {
        _inputReader.ShotFired += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.ShotFired -= Shoot;
    }

    private void Shoot()
    {
        _bulletPosition = transform.position;
        _bulletPosition.x += _offsetX;

        _bulletSpawner.GetBulletFromPool(_bulletPosition, _directionChanger);
    }
}