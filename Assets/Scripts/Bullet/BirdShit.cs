using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdShit : MonoBehaviour, IInteractable
{
    [SerializeField] private float _force;

    private Rigidbody2D _rigidbody2D;
    private float _directionChanger = -1;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(int direction)
    {
        _rigidbody2D.velocity = _rigidbody2D.transform.right * (_force * direction);
    }
}