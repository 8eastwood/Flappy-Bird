using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdShit : MonoBehaviour, IInteractable
{
    [SerializeField] private float _force;
    [SerializeField] private float _delay = 2f;

    private Rigidbody2D _rigidbody2D;
    private float _directionChanger = -1;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        _rigidbody2D.velocity = _rigidbody2D.transform.right * (_force * _directionChanger);
    }
}