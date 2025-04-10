using System.Collections;
using UnityEngine;

public class BulletSpawner : PoolHandler<Bullet>
{
    [SerializeField] private ObjectRemover _objectRemover;
    [SerializeField] private Transform _container;

    private Transform _bulletPosition;

    private void OnEnable()
    {
        _objectRemover.BulletCollisionHappened += ReleaseBullet;
    }

    private void OnDisable()
    {
        _objectRemover.BulletCollisionHappened -= ReleaseBullet;
    }

    public void GetBulletFromPool(Vector3 bulletPosition, int direction)
    {
        Bullet bullet = _pool.Get();

        bullet.transform.parent = _container;
        bullet.transform.position = bulletPosition;
        bullet.gameObject.SetActive(true);
        bullet.Move(direction);
    }

    private void ReleaseBullet(Bullet bullet)
    {
        _pool.Release(bullet);
    }
}