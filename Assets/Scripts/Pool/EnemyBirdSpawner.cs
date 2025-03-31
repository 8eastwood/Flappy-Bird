using System.Collections;
using UnityEngine;

public class EnemyBirdSpawner : PoolHandler<EnemyBird>
{
    [SerializeField] private ObjectRemover _objectRemover;
    [SerializeField] private Transform _container;
    [SerializeField] private ShitSpawner _bulletSpawner;
    [SerializeField] private float _upperBound = 9;
    [SerializeField] private float _lowerBound = -1;
    [SerializeField] private float _enemySpawnDelay = 2f;

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
        int count = 0;
        WaitForSeconds wait = new WaitForSeconds(_enemySpawnDelay);

        while (enabled)
        {
            yield return wait;

            GetEnemyBirdFromPool();
            count++;
            Debug.Log(count);
        }
    }

    private void GetEnemyBirdFromPool()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        EnemyBird enemy = _pool.Get();

        enemy.transform.parent = _container;
        enemy.transform.position = spawnPoint;

        // StartCoroutine(_bulletSpawner.SpawnBulletWithRate());
        enemy.SetBulletSpawner(_bulletSpawner);
    }

    private void ReleaseEnemyBird(EnemyBird enemy)
    {
        _pool.Release(enemy);
    }
}