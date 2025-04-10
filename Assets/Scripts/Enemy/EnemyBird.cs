using System;
using UnityEngine;
using System.Collections;

public class EnemyBird : MonoBehaviour, IInteractable
{
    [SerializeField] EnemyBirdCollisionHandler _enemyCollisionHandler;

    private BulletSpawner _bulletSpawner;
    private Vector3 _bulletPosition;
    private float _shootDelay = 2f;
    private float _offsetX = -2f;
    private int _directionChanger = -1;
    public event Action<EnemyBird> Destroyed;

    private void OnEnable()
    {
        StartCoroutine(SpawnBulletWithRate());
        
        _enemyCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _enemyCollisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void Update()
    {
        _bulletPosition = transform.position;
        _bulletPosition.x += _offsetX;
    }

    public void SetBulletSpawner(BulletSpawner spawner)
    {
        _bulletSpawner = spawner;
    }

    public IEnumerator SpawnBulletWithRate()
    {
        WaitForSeconds wait = new WaitForSeconds(_shootDelay);

        while (enabled)
        {
            _bulletSpawner.GetBulletFromPool(_bulletPosition, _directionChanger);

            yield return wait;
        }
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Bullet)
        {
            Destroyed?.Invoke(this);
        }
    }

    private void Death()
    {
        Destroy(this);
    }
}