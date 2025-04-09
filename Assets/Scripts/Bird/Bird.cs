using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    private BirdCollisionHandler _handler;
    private BirdMover _birdMover;

    public event Action GameOver;

    private void Awake()
    {
        _handler = GetComponent<BirdCollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
    }
    
    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is EnemyBird)
        {
            Debug.Log("touched the enemy");
            GameOver?.Invoke();
        }
        
        else if (interactable is BirdShit)
        {
            Debug.Log("touched the bullet");
            GameOver?.Invoke();
        }
        
        else if (interactable is Ground)
        {
            Debug.Log("Touched the ground");
            GameOver?.Invoke();
        }
    }

    public void Reset()
    {
        _birdMover.Reset();
    }
}
