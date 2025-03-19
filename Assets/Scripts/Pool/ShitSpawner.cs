using System.Collections;
using UnityEngine;

public class ShitSpawner : PoolHandler<BirdShit>
{
    [SerializeField] private ObjectRemover _objectRemover;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private Transform _container;
    [SerializeField] private float _shootDelay = 2;

    private BirdShit _bullet;

    public BirdShit Bullet => _bullet;

    private void OnEnable()
    {
        _objectRemover.BulletCollisionHappened += ReleaseBullet;
    }

    private void OnDisable()
    {
        _objectRemover.BulletCollisionHappened -= ReleaseBullet;
    }

    // public BirdShit TransferBullet()
    // {
    //     return _bullet;
    // }

    public IEnumerator SpawnBulletWithRate()
    {
        WaitForSeconds wait = new WaitForSeconds(_shootDelay);
        
        while (enabled)
        {
            GetBulletFromPool();

            yield return wait;
        }
    }

    private void GetBulletFromPool()
    {
        Debug.Log("bullet spawned ");
        BirdShit bullet = _pool.Get();

        bullet.transform.parent = _container;
        bullet.transform.position = _bulletPosition.position;

        _bullet = bullet;
        
        bullet.Move();

        if (Bullet != null)
        {
            Debug.Log("bullet spawned ");
        }
        else
        {
            Debug.Log(Bullet);
        }
    }

    private void ReleaseBullet(BirdShit bullet)
    {
        _pool.Release(bullet);
    }
}