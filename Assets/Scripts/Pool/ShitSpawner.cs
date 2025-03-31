using System.Collections;
using UnityEngine;

public class ShitSpawner : PoolHandler<BirdShit>
{
    [SerializeField] private ObjectRemover _objectRemover;
    [SerializeField] private Transform _container;
    // [SerializeField] private float _shootDelay = 2;

    private Transform _bulletPosition;
    private BirdShit _bullet;

    // public BirdShit Bullet => _bullet;

    private void OnEnable()
    {
        _objectRemover.BulletCollisionHappened += ReleaseBullet;
    }

    private void OnDisable()
    {
        _objectRemover.BulletCollisionHappened -= ReleaseBullet;
    }
    
    public void GetBulletFromPool(Vector3 bulletPosition)
    {
        Debug.Log("bullet spawned ");
        BirdShit bullet = _pool.Get();

        bullet.transform.parent = _container;
        bullet.transform.position = bulletPosition;

        _bullet = bullet;
        
        bullet.Move();
    }

    private void ReleaseBullet(BirdShit bullet)
    {
        _pool.Release(bullet);
    }
}