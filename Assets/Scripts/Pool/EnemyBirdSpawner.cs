using System.Collections;
using UnityEngine;

public class EnemyBirdSpawner : PoolHandler<EnemyBird>
{
    [SerializeField] private ObjectRemover _objectRemover;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Transform _container;
    [SerializeField] private float _enemySpawnDelay = 2f;
    [SerializeField] private float _upperBound = 9;
    [SerializeField] private float _lowerBound = -1;

    private void Start()
    {
        StartCoroutine(SpawnEnemyBirdWithRate());
    }

    private void OnEnable()
    {
        _objectRemover.EnemyBirdCollisionHappened += ReleaseEnemyBird;
    }

    private void OnDisable()
    {
        _objectRemover.EnemyBirdCollisionHappened -= ReleaseEnemyBird;
    }

    private IEnumerator SpawnEnemyBirdWithRate()
    {
        WaitForSeconds wait = new WaitForSeconds(_enemySpawnDelay);

        while (enabled)
        {
            yield return wait;

            GetEnemyBirdFromPool();
        }
    }

    private void GetEnemyBirdFromPool()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        EnemyBird enemy = _pool.Get();
        
        enemy.transform.parent = _container;
        enemy.transform.position = spawnPoint;
        enemy.SetBulletSpawner(_bulletSpawner);
        enemy.gameObject.SetActive(true);
        
        enemy.Destroyed += ReleaseEnemyBird;
    }
    
    private void ReleaseEnemyBird(EnemyBird enemy)
    {
        enemy.Destroyed -= ReleaseEnemyBird;
        _pool.Release(enemy);
    }
}