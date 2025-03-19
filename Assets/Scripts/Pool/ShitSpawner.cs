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
            yield return wait;
    
            GetBulletFromPool();
        }
    }

    private void GetBulletFromPool()
    {
        Debug.Log("bullet spawned ");
        BirdShit bullet = _pool.Get();
        
        bullet.transform.parent = _container;
        bullet.transform.position = _bulletPosition.position;
        
        _bullet = bullet;
    }

    private void ReleaseBullet(BirdShit bullet)
    {
        _pool.Release(bullet);
    }
}