using System;
using UnityEngine;
using System.Collections;

public class EnemyBird : MonoBehaviour, IInteractable
{
    private ShitSpawner _shitSpawner;

    private float _shootDelay = 2f;
    private bool _isShooting;

    private void Awake()
    {
        _isShooting = true;
    }

    private void Start()
    {
        StartCoroutine(SpawnBulletWithRate());
    }

    public void SetBulletSpawner(ShitSpawner spawner)
    {
        _shitSpawner = spawner;
        // Debug.Log(_shitSpawner);

    }
    
    public IEnumerator SpawnBulletWithRate()
    {
        WaitForSeconds wait = new WaitForSeconds(_shootDelay);
        
        while (_isShooting)
        {
            _shitSpawner.GetBulletFromPool(transform.position);

            yield return wait;
        }
    }
}
