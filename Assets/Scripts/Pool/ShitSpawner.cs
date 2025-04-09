using System.Collections;
using UnityEngine;

public class ShitSpawner : PoolHandler<BirdShit>
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

    private void ReleaseBullet(BirdShit bullet)
    {
        _pool.Release(bullet);
    }

    public void GetBulletFromPool(Vector3 bulletPosition, int direction)
    {
        BirdShit bullet = _pool.Get();

        bullet.transform.parent = _container;
        bullet.transform.position = bulletPosition;
        bullet.gameObject.SetActive(true);
        bullet.Move(direction);
    }
}