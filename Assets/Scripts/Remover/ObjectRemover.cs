using System;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    public event Action<EnemyBird> EnemyBirdCollisionHappened;
    public event Action<Bullet> BulletCollisionHappened;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyBird enemyBird))
        {
            EnemyBirdCollisionHappened?.Invoke(enemyBird);
        }

        else if (other.TryGetComponent(out Bullet bullet))
        {
            BulletCollisionHappened?.Invoke(bullet);
        }
    }
}