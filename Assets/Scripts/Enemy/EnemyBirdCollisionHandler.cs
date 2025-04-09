using System;
using UnityEngine;

public class EnemyBirdCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out IInteractable interactable))
        {
            Debug.Log("enemy Bird Collided");
            CollisionDetected?.Invoke(interactable);
        }
    }
}
