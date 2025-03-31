using System;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    public event Action<EnemyBird> EnemyBirdCollisionHappened;
    public event Action<BirdShit> BulletCollisionHappened;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyBird enemyBird))
        {
            Debug.Log("enemy collided with remover");
            EnemyBirdCollisionHappened?.Invoke(enemyBird);
        }

        else if (other.TryGetComponent(out BirdShit bullet))
        {
            Debug.Log("shit collided with remover");
            BulletCollisionHappened?.Invoke(bullet);
        }
    }
}