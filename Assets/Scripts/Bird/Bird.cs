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
            GameOver?.Invoke();
        }
        
        else if (interactable is Bullet)
        {
            GameOver?.Invoke();
        }
        
        else if (interactable is Ground)
        {
            GameOver?.Invoke();
        }
    }

    public void Reset()
    {
        _birdMover.Reset();
    }
}
