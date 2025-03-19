using System.Collections;
using UnityEngine;

public class EnemyBirdGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;

    private void Start()
    {
        StartCoroutine(GenerateEnemyBirds());
    }

    private IEnumerator GenerateEnemyBirds()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        
        var enemyBird = _pool.GetObject();
        
        enemyBird.gameObject.SetActive(true);
        enemyBird.transform.position = spawnPoint;
    }
}
