using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _force;
        
    private Rigidbody2D _rigidbody2D;
     // private GameObject _player;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // _player = GameObject.FindGameObjectWithTag("Player");
        
        _rigidbody2D.velocity = _rigidbody2D.transform.right * (_force * -1);
    }
}
