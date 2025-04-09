using UnityEngine;

public class BirdCombat : MonoBehaviour
{
    [SerializeField] ShitSpawner _shitSpawner;
    
    private Vector3 _direction ;
    private float _offsetX = 2f;
    private int _directionChanger = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _direction = transform.position;
            _direction.x += _offsetX;
            
            Shoot();
        }
    }

    private void Shoot()
    {
        _shitSpawner.GetBulletFromPool(_direction, _directionChanger);
    }
}