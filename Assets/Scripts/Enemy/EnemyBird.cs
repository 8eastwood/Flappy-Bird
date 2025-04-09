using UnityEngine;
using System.Collections;

public class EnemyBird : MonoBehaviour, IInteractable
{
    [SerializeField] EnemyBirdCollisionHandler _enemyCollisionHandler;

    private ShitSpawner _shitSpawner;
    private Vector3 _direction;
    private float _shootDelay = 2f;
    private float _offsetX = -2f;
    private int _directionChanger = -1;

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
        _direction = transform.position;
        _direction.x += _offsetX;
    }

    public void SetBulletSpawner(ShitSpawner spawner)
    {
        _shitSpawner = spawner;
    }

    public IEnumerator SpawnBulletWithRate()
    {
        WaitForSeconds wait = new WaitForSeconds(_shootDelay);

        while (enabled)
        {
            _shitSpawner.GetBulletFromPool(_direction, _directionChanger);

            yield return wait;
        }
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is BirdShit)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(this);
    }
}